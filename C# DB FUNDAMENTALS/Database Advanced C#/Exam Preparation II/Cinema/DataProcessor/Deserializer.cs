using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Cinema.Data.Models;
using Cinema.Data.Models.Enums;
using Cinema.DataProcessor.ImportDto;
using Newtonsoft.Json;

namespace Cinema.DataProcessor
{
    using System;

    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var movies = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);
            List<Movie> mappedMovies = new List<Movie>();

            foreach (var importMovieDto in movies)
            {
                var isValidEnum = Enum.TryParse(importMovieDto.Genre, out Genre result);

                if (!IsValid(importMovieDto) || context.Movies.Any(m => m.Title == importMovieDto.Title) || !isValidEnum)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Movie movie = new Movie
                {
                    Title = importMovieDto.Title,
                    Genre = result,
                    Duration = TimeSpan.Parse(importMovieDto.Duration),
                    Rating = importMovieDto.Rating,
                    Director = importMovieDto.Director
                };

                mappedMovies.Add(movie);
                sb.AppendLine(
                    $"Successfully imported {movie.Title} with genre {movie.Genre.ToString()} and rating {movie.Rating:F2}!");
            }

            context.AddRange(mappedMovies);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var data = JsonConvert.DeserializeObject<ImportHallDto[]>(jsonString);
            List<Hall> halls = new List<Hall>();

            foreach (var hallDto in data)
            {
                if (!IsValid(hallDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Hall hall = new Hall
                {
                    Name = hallDto.Name,
                    Is3D = hallDto.Is3D,
                    Is4Dx = hallDto.Is4Dx,
                };

                for (int i = 0; i < hallDto.Seats; i++)
                {
                    hall.Seats.Add(new Seat());
                }

                var projectionType = "";

                if (hall.Is4Dx)
                {
                    projectionType = "4Dx";

                    if (hall.Is3D)
                    {
                        projectionType = "4Dx/3D";
                    }
                }
                else if (hall.Is3D)
                {
                    projectionType = "3D";
                }
                else
                {
                    projectionType = "Normal";
                }

                halls.Add(hall);
                sb.AppendLine($"Successfully imported {hall.Name}({projectionType}) with {hall.Seats.Count} seats!");
            }

            context.Halls.AddRange(halls);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ImportProjectionDto[]), new XmlRootAttribute("Projections"));

            var projections = (ImportProjectionDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Projection> mappedProjections = new List<Projection>();

            foreach (var projectionDto in projections)
            {
                var movie = context.Movies.Find(projectionDto.MovieId);
                var hall = context.Halls.Find(projectionDto.HallId);


                if (!IsValid(projectionDto) || movie == null || hall == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    Hall = hall,
                    Movie = movie,
                    DateTime = DateTime.ParseExact(projectionDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                mappedProjections.Add(projection);
                sb.AppendLine($"Successfully imported projection {projection.Movie.Title} on {projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}!");
            }

            context.Projections.AddRange(mappedProjections);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));

            var customers = (ImportCustomerDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Customer> mappedCustomers = new List<Customer>();

            foreach (var customerDto in customers)
            {
                if (!IsValid(customerDto) || customerDto.Tickets.Any(t => !IsValid(t)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Customer customer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance
                };

                bool hasProjection = true;
                foreach (var ticketDto in customerDto.Tickets)
                {
                    var projection = context.Projections.Find(ticketDto.ProjectionId);
                    if (projection == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        hasProjection = false;
                        break;
                    }
                    customer.Tickets.Add(new Ticket
                    {
                        Price = ticketDto.Price,
                        Projection = projection
                    });
                }

                if (!hasProjection)
                {
                    continue;
                }

                mappedCustomers.Add(customer);
                sb.AppendLine($"Successfully imported customer {customer.FirstName} {customer.LastName} with bought tickets: {customer.Tickets.Count}!");
            }

            context.Customers.AddRange(mappedCustomers);
            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object importMovieDto)
        {
            var validationContext = new ValidationContext(importMovieDto);
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(importMovieDto, validationContext, result, true);

            return isValid;
        }

    }
}