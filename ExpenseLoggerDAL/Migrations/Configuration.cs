namespace ExpenseLoggerDAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
                    EmailAddress = "crisronaldo@gmail.com",
                    Password = "/fvqx+m2xEpjERwBKgbhow==",
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
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-63).Date, Amount = 15.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-63).Date, Amount = 17.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-63).Date, Amount = 19.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-63).Date, Amount = 21.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-63).Date, Amount = 101.35m },

                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-62).Date, Amount = 20.2m },
                        new Expense() { CategoryName = "Transportation", CreatedDate = DateTime.Now.AddDays(-62).Date, Amount = 170 },
                        new Expense() { CategoryName = "Housing", CreatedDate = DateTime.Now.AddDays(-62).Date, Amount = 550 },
                        new Expense() { CategoryName = "Entertainment", CreatedDate = DateTime.Now.AddDays(-62).Date, Amount = 30 },

                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-37).Date, Amount = 10.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-37).Date, Amount = 20.2m },
                        new Expense() { CategoryName = "Transportation", CreatedDate = DateTime.Now.AddDays(-37).Date, Amount = 170 },
                        new Expense() { CategoryName = "Housing", CreatedDate = DateTime.Now.AddDays(-37).Date, Amount = 550 },
                        new Expense() { CategoryName = "Entertainment", CreatedDate = DateTime.Now.AddDays(-37).Date, Amount = 30 },

                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-10).Date, Amount = 10.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-10).Date, Amount = 20.2m },
                        new Expense() { CategoryName = "Transportation", CreatedDate = DateTime.Now.AddDays(-10).Date, Amount = 170 },
                        new Expense() { CategoryName = "Housing", CreatedDate = DateTime.Now.AddDays(-10).Date, Amount = 550 },
                        new Expense() { CategoryName = "Entertainment", CreatedDate = DateTime.Now.AddDays(-10).Date, Amount = 30 },

                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-9).Date, Amount = 10.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-9).Date, Amount = 40.2m },
                        new Expense() { CategoryName = "Transportation", CreatedDate = DateTime.Now.AddDays(9).Date, Amount = 170 },
                        new Expense() { CategoryName = "Entertainment", CreatedDate = DateTime.Now.AddDays(9).Date, Amount = 30.50m },

                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-8).Date, Amount = 10.35m },
                        new Expense() { CategoryName = "Meals", CreatedDate = DateTime.Now.AddDays(-8).Date, Amount = 40.2m },
                        new Expense() { CategoryName = "Transportation", CreatedDate = DateTime.Now.AddDays(8).Date, Amount = 170 },
                        new Expense() { CategoryName = "Entertainment", CreatedDate = DateTime.Now.AddDays(8).Date, Amount = 30.50m },
                    }
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
