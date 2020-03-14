using ExpenseLoggerDAL;
using System;
using System.Collections.Generic;
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
                return context.Expenses.Where(x => x.CreatedDate >= fromDate && x.CreatedDate <= toDate).ToList();
            }
        }
    }
}
