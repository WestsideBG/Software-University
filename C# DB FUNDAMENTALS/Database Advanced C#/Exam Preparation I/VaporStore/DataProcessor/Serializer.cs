using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.DataProcessor.Dtos.Export;
using Formatting = Newtonsoft.Json.Formatting;

namespace VaporStore.DataProcessor
{
    using System;
    using Data;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context.Genres
                .Where(g => genreNames.Contains(g.Name))
                .Select(g => new ExportGenreDto
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games
                        .Where(game => game.Purchases.Any())
                        .Select(game => new ExportGameDto
                        {
                            Id = game.Id,
                            Title = game.Name,
                            Developer = game.Developer.Name,
                            Tags = string.Join(", ", game.GameTags.Select(t => t.Tag.Name).ToArray()),
                            Players = game.Purchases.Count
                        })
                        .OrderByDescending(ga => ga.Players)
                        .ThenBy(ga => ga.Id)
                        .ToArray(),
                    TotalPlayersCount = g.Games.Sum(ga => ga.Purchases.Count)
                })
                .OrderByDescending(g => g.TotalPlayersCount)
                .ThenBy(g => g.Id)
                .ToArray();

            var result = JsonConvert.SerializeObject(genres, Formatting.Indented);

            return result;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ExportUserDto[]),new XmlRootAttribute("Users"));
            StringBuilder sb = new StringBuilder();

            var type = Enum.Parse<PurchaseType>(storeType);

            var users = context.Users
                .Select(u => new ExportUserDto
                {
                    Username = u.Username,
                    Purchases = u.Cards.SelectMany(c => c.Purchases).Where(p => p.Type == type).Select(p => new ExportPurchaseDto
                    {
                        Card = p.Card.Number,
                        Cvc = p.Card.Cvc,
                        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new ExportGameXmlDto
                        {
                            Title = p.Game.Name,
                            Genre = p.Game.Genre.Name,
                            Price = p.Game.Price
                        }
                    })
                        .OrderBy(p => p.Date)
                        .ToArray(),

                    TotalSpent = u.Cards.SelectMany(c => c.Purchases).Where(p => p.Type == type).Sum(p => p.Game.Price)
                })
                .Where(p => p.Purchases.Any())
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            var namespaces = new XmlSerializerNamespaces(new []
            {
                new XmlQualifiedName("",""), 
            });

            serializer.Serialize(new StringWriter(sb),users, namespaces);

            return sb.ToString();
        }
    }
}