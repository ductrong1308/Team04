using ExpenseLoggerDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ExpenseLoggerBLL.Queries
{
    /// <summary>
    /// This class contains methods that help the application to query data in the. database.
    /// </summary>
    public class ExpenseLoggerQueries
    {
        public ExpenseLoggerQueries()
        {
        }

        /// <summary>
        /// Get user by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserByIdAsync(int id)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                return context.Users.FirstOrDefault(x => x.Id == id);
            }
        }

        /// <summary>
        /// Get user by email and password
        /// This function is used when user do login.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetUserByEmailAndPassword(string email, string password)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                return context.Users.FirstOrDefault(x => x.EmailAddress == email && x.Password == password);
            }
        }

        /// <summary>
        /// Get all categories which belong to a user.
        /// This is used to bind data to the category comboBox.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<string> GetExpenseCategories(int userId)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                return context.Categories.Where(x => x.UserID == userId).Select(x => x.Name).ToList();
            }
        }

        /// <summary>
        /// Querying expenses by userID and date range.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public List<Expense> FilterExpensesByDate(int userId, DateTime fromDate, DateTime toDate)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                return context.Expenses
                    .Where(x => DbFunctions.TruncateTime(x.CreatedDate) >= fromDate.Date
                        && DbFunctions.TruncateTime(x.CreatedDate) <= toDate.Date && x.UserID == userId)
                    .OrderBy(x => x.CreatedDate)
                    .ToList();
            }
        }

        /// <summary>
        /// Query settings belong to a user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Setting> GetUserSettings(int userId)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                return context.Settings.Where(x => x.UserID == userId).ToList();
            }
        }

        /// <summary>
        /// Query all expense category of a user.
        /// This data will be shown in a dataGridView.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Category> GetExpensesCategoriesByUserId(int userId)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                return context.Categories.Where(x => x.UserID == userId).ToList();
            }
        }

        /// <summary>
        /// Check if a category name is already used or not.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public bool IsCategoryNameExisted(int userId, string categoryName)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                return context.Categories.FirstOrDefault(x => x.UserID == userId && x.Name == categoryName) != null;
            }
        }
    }
}
