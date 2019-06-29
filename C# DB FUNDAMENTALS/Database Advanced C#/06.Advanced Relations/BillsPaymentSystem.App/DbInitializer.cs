using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BillsPaymentSystem.Data;
using BillsPaymentSystem.Data.Models;

namespace BillsPaymentSystem.App
{
    public class DbInitializer
    {
        public DbInitializer(BillsPaymentSystemContext context)
        {
            Seed(context);
        }

        private void Seed(BillsPaymentSystemContext context)
        {
            SeedUsers(context);
        }

        private void SeedUsers(BillsPaymentSystemContext context)
        {
            List<User> users = new List<User>();

            string[] firstNames = new[]
            {
                "Samir",
                "Cvetan",
                "Kiro",
                "Pesho",
                "Mitko",
                null
            };

            string[] lastNames = new[]
            {
                "Azzam",
                "Rangelov",
                "Kirov",
                "Peshov",
                "Mitkov",
                null
            };

            string[] emails = new[]
            {
                "Azzam@abv.bg",
                "Rangelov@abv.bg",
                "Kirov@abv.bg",
                "Peshov@abv.bg",
                "Mitkov@abv.bg",
                null
            };

            string[] passwords = new[]
            {
                "Azzam@abv.bg",
                "Rangelov@abv.bg",
                "Kirov@abv.bg",
                "Peshov@abv.bg",
                "Mitkov@abv.bg",
                "password"
            };


            for (int i = 0; i < firstNames.Length; i++)
            {
                User user = new User()
                {
                    FirstName = firstNames[i],
                    LastName = lastNames[i],
                    Email = emails[i],
                    Password = passwords[i]
                };

                if (!IsValid(user))
                {
                    continue;
                }

                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }
    }
}