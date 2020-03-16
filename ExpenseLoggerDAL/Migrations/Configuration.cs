namespace ExpenseLoggerDAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ExpenseLoggerDAL.ExpenseLoggerDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExpenseLoggerDAL.ExpenseLoggerDBContext context)
        {
            List<User> users = new List<User>()
            {
                new User()
                {
                    FirstName = "Admin",
                    LastName = "System",
                    EmailAddress = "admin@gmail.com",
                    Password = "/fvqx+m2xEpjERwBKgbhow==", // This will be equal to 123
                    Gender = true,
                    Settings = new List<Setting>()
                    {
                        new Setting() { Name = "Currency", Value = "$" }
                    },
                    Categories = new List<Category>()
                    {
                        new Category() { Name = "Meals" },
                        new Category() { Name = "Transportation" },
                        new Category() { Name = "Housing" },
                        new Category() { Name = "Entertainment" },
                    },
                    Expenses = new List<Expense>()
                    {
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddMinutes(-37), Amount = 10.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddMinutes(-37), Amount = 20.2m },
                        new Expense() { CategoryName = "Transportation", CreatedDate = DateTime.Now.AddMinutes(-37), Amount = 170 },
                        new Expense() { CategoryName = "Housing", CreatedDate = DateTime.Now.AddMinutes(-37), Amount = 550 },
                        new Expense() { CategoryName = "Entertainment", CreatedDate = DateTime.Now.AddMinutes(-37), Amount = 30 },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddMinutes(-62), Amount = 20.2m },
                        new Expense() { CategoryName = "Transportation", CreatedDate = DateTime.Now.AddMinutes(-62), Amount = 170 },
                        new Expense() { CategoryName = "Housing", CreatedDate = DateTime.Now.AddMinutes(-62), Amount = 550 },
                        new Expense() { CategoryName = "Entertainment", CreatedDate = DateTime.Now.AddMinutes(-62), Amount = 30 },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddMinutes(-63), Amount = 15.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddMinutes(-63), Amount = 17.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddMinutes(-63), Amount = 19.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddMinutes(-63), Amount = 21.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddMinutes(-63), Amount = 101.35m },

                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-8), Amount = 10.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-8), Amount = 40.2m },
                        new Expense() { CategoryName = "Transportation", CreatedDate = DateTime.Now.AddDays(-8), Amount = 170 },
                        new Expense() { CategoryName = "Entertainment", CreatedDate = DateTime.Now.AddDays(-8), Amount = 30.50m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-9), Amount = 10.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-9), Amount = 40.2m },
                        new Expense() { CategoryName = "Transportation", CreatedDate = DateTime.Now.AddDays(-9), Amount = 170 },
                        new Expense() { CategoryName = "Entertainment", CreatedDate = DateTime.Now.AddDays(-9), Amount = 30.50m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-10), Amount = 10.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-10), Amount = 20.2m },
                        new Expense() { CategoryName = "Transportation", CreatedDate = DateTime.Now.AddDays(-10), Amount = 170 },
                        new Expense() { CategoryName = "Housing", CreatedDate = DateTime.Now.AddDays(-10), Amount = 550 },
                        new Expense() { CategoryName = "Entertainment", CreatedDate = DateTime.Now.AddDays(-10), Amount = 30 },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-37), Amount = 10.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-37), Amount = 20.2m },
                        new Expense() { CategoryName = "Transportation", CreatedDate = DateTime.Now.AddDays(-37), Amount = 170 },
                        new Expense() { CategoryName = "Housing", CreatedDate = DateTime.Now.AddDays(-37), Amount = 550 },
                        new Expense() { CategoryName = "Entertainment", CreatedDate = DateTime.Now.AddDays(-37), Amount = 30 },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-62), Amount = 20.2m },
                        new Expense() { CategoryName = "Transportation", CreatedDate = DateTime.Now.AddDays(-62), Amount = 170 },
                        new Expense() { CategoryName = "Housing", CreatedDate = DateTime.Now.AddDays(-62), Amount = 550 },
                        new Expense() { CategoryName = "Entertainment", CreatedDate = DateTime.Now.AddDays(-62), Amount = 30 },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-63), Amount = 15.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-63), Amount = 17.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-63), Amount = 19.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-63), Amount = 21.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-63), Amount = 101.35m },

                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-90), Amount = 10.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-90), Amount = 40.2m },
                        new Expense() { CategoryName = "Transportation", CreatedDate = DateTime.Now.AddDays(-90), Amount = 170 },
                        new Expense() { CategoryName = "Entertainment", CreatedDate = DateTime.Now.AddDays(-90), Amount = 30.50m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-90), Amount = 10.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-91), Amount = 40.2m },
                        new Expense() { CategoryName = "Transportation", CreatedDate = DateTime.Now.AddDays(-91), Amount = 170 },
                        new Expense() { CategoryName = "Entertainment", CreatedDate = DateTime.Now.AddDays(-91), Amount = 30.50m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-92), Amount = 10.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-92), Amount = 20.2m },
                        new Expense() { CategoryName = "Transportation", CreatedDate = DateTime.Now.AddDays(-92), Amount = 170 },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-92), Amount = 10.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-92), Amount = 40.2m },
                        new Expense() { CategoryName = "Transportation", CreatedDate = DateTime.Now.AddDays(-92), Amount = 170 },
                        new Expense() { CategoryName = "Entertainment", CreatedDate = DateTime.Now.AddDays(-92), Amount = 30.50m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-92), Amount = 10.35m },

                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-130), Amount = 40.2m },
                        new Expense() { CategoryName = "Transportation", CreatedDate = DateTime.Now.AddDays(-130), Amount = 170 },
                        new Expense() { CategoryName = "Entertainment", CreatedDate = DateTime.Now.AddDays(-130), Amount = 30.50m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-130), Amount = 10.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-131), Amount = 40.2m },
                        new Expense() { CategoryName = "Transportation", CreatedDate = DateTime.Now.AddDays(-131), Amount = 170 },
                        new Expense() { CategoryName = "Entertainment", CreatedDate = DateTime.Now.AddDays(-131), Amount = 30.50m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-132), Amount = 10.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-132), Amount = 20.2m },
                        new Expense() { CategoryName = "Transportation", CreatedDate = DateTime.Now.AddDays(-132), Amount = 170 },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-132), Amount = 10.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-132), Amount = 40.2m },
                        new Expense() { CategoryName = "Transportation", CreatedDate = DateTime.Now.AddDays(-132), Amount = 170 },
                        new Expense() { CategoryName = "Entertainment", CreatedDate = DateTime.Now.AddDays(-132), Amount = 30.50m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-132), Amount = 10.35m },
                    }
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
