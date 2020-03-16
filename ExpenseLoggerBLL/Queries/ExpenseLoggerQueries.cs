using ExpenseLoggerDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace ExpenseLoggerBLL.Queries
{
    public class ExpenseLoggerQueries
    {
        public ExpenseLoggerQueries()
        {
        }

        public User GetUserByIdAsync(int id)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                return context.Users.FirstOrDefault(x => x.Id == id);
            }
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                return context.Users.FirstOrDefault(x => x.EmailAddress == email && x.Password == password);
            }
        }

        public List<string> GetExpenseCategories(int userId)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                return context.Categories.Where(x => x.UserID == userId).Select(x => x.Name).ToList();
            }
        }

        public List<Expense> FilterExpensesByDate(DateTime fromDate, DateTime toDate)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                return context.Expenses
                    .Where(x => DbFunctions.TruncateTime(x.CreatedDate) >= fromDate.Date 
                        && DbFunctions.TruncateTime(x.CreatedDate) <= toDate.Date)
                    .OrderBy(x=> x.CreatedDate)
                    .ToList();
            }
        }

        public List<Setting> GetUserSettings(int userId)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                return context.Settings.Where(x => x.UserID == userId).ToList();
            }
        }

        public List<Category> GetExpensesCategoriesByUserId(int userId)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                return context.Categories.Where(x => x.UserID == userId).ToList();
            }
        }
    }
}
