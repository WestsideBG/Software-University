namespace VaporStore.DataProcessor
{
    using Data;
    using Data.Models;
    using Dtos.Import;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
            List<Game> games = new List<Game>();
            StringBuilder sb = new StringBuilder();
		    var gamesDto = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

		    foreach (var gameDto in gamesDto)
		    {
		        if (!IsValid(gameDto) || gameDto.Tags.Count == 0)
		        {
		            sb.AppendLine("Invalid Data");
                    continue;
		        }

		        var game = new Game
		        {
		            Name = gameDto.Name,
		            Price = gameDto.Price,
		            ReleaseDate = DateTime.ParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
		        };

		        var developer = GetDeveloper(gameDto.Developer,context);
		        var genre = GetGenre(gameDto.Genre, context);

		        game.Developer = developer;
		        game.Genre = genre;

		        foreach (var currentTag in gameDto.Tags)
		        {
		            var tag = GetTag(context, currentTag);

		            game.GameTags.Add(new GameTag
		            {
		                Tag = tag
		            });
		        }

                games.Add(game);
		        sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
		    }

            context.AddRange(games);
		    context.SaveChanges();
		    return sb.ToString();
		}
	    public static string ImportUsers(VaporStoreDbContext context, string jsonString)
	    {
            StringBuilder sb = new StringBuilder();
	        var usersDto = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);
            List<User> users = new List<User>();

	        foreach (var userDto in usersDto)
	        {
	            var isValid = true;

	            foreach (var userDtoCard in userDto.Cards)
	            {
	                if (!IsValid(userDtoCard))
	                {
	                    isValid = false;
	                    break;
	                }
	            }

	            if (!IsValid(userDto) || !isValid)
	            {
	                sb.AppendLine("Invalid Data");
	                continue;
	            }

                User user = new User
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age
                };

	            foreach (var userDtoCard in userDto.Cards)
	            {
	                var cardType = Enum.Parse<CardType>(userDtoCard.Type);

	                var card = new Card
	                {
	                    Number = userDtoCard.Number,
	                    Cvc = userDtoCard.CVC,
	                    Type = cardType
	                };

                    user.Cards.Add(card);
	            }

                users.Add(user);
	            sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
	        }

	        context.Users.AddRange(users);
	        context.SaveChanges();

	        return sb.ToString();
	    }
	    public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(ImportPurchaseDto[]),new XmlRootAttribute("Purchases"));
            StringBuilder sb = new StringBuilder();
		    var purchaseDtos = (ImportPurchaseDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Purchase> purchases = new List<Purchase>();

		    foreach (var importPurchaseDto in purchaseDtos)
		    {
		        var isValidEnum = Enum.TryParse<PurchaseType>(importPurchaseDto.Type, out PurchaseType result);

		        var game = context.Games.FirstOrDefault(g => g.Name == importPurchaseDto.Title);
		        var card = context.Cards.FirstOrDefault(c => c.Number == importPurchaseDto.Card);

		        var isValidGameAndCard = game != null || card != null;

                if (!IsValid(importPurchaseDto) || !isValidEnum || !isValidGameAndCard)
		        {
		            sb.AppendLine("Invalid Data");
		            continue;
                }

                Purchase purchase = new Purchase
                {
                    Type = result,
                    ProductKey = importPurchaseDto.Key,
                    Date = DateTime.ParseExact(importPurchaseDto.Date, "dd/MM/yyyy HH:mm",CultureInfo.InvariantCulture),
                    Card = card,
                    Game = game
                };


		        purchases.Add(purchase);
		        sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
		    }

            context.Purchases.AddRange(purchases);
		    context.SaveChanges();

		    return sb.ToString();
		}

	    private static Tag GetTag(VaporStoreDbContext context, string currentTag)
	    {
	        var tag = context.Tags.FirstOrDefault(t => t.Name == currentTag);

	        if (tag == null)
	        {
	            tag = new Tag
	            {
	                Name = currentTag
	            };

	            context.Tags.Add(tag);
	            context.SaveChanges();
	        }

	        return tag;
	    }
	    private static Genre GetGenre(string gameDtoGenre, VaporStoreDbContext context)
	    {
	        Genre genre = context.Genres.FirstOrDefault(g => g.Name == gameDtoGenre);

	        if (genre == null)
	        {
	            genre = new Genre
	            {
	                Name = gameDtoGenre
	            };

	            context.Genres.Add(genre);
	            context.SaveChanges();
	        }

	        return genre;
	    }
	    private static Developer GetDeveloper(string gameDtoDeveloper, VaporStoreDbContext context)
	    {
	        Developer dev = context.Developers.FirstOrDefault(d => d.Name == gameDtoDeveloper);

	        if (dev == null)
	        {
	            dev = new Developer
	            {
	                Name = gameDtoDeveloper
	            };

	            context.Developers.Add(dev);
	            context.SaveChanges();
	        }

	        return dev;
	    }
        private static bool IsValid(object entity)
	    {
            var validationContext = new ValidationContext(entity);
	        var validationResult = new List<ValidationResult>();

	        var isValid = Validator.TryValidateObject(entity, validationContext, validationResult,true);

	        return isValid;
	    }
	}
}