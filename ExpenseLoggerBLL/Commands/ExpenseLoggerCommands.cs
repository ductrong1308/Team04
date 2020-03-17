using ExpenseLoggerDAL;
using System.Linq;

namespace ExpenseLoggerBLL.Commands
{
    /// <summary>
    /// This class contains methods that help the application to insert, update, delete data from database.
    /// </summary>
    public class ExpenseLoggerCommands
    {
        /// <summary>
        /// Adding a new user.
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public bool AddNewUser(User newUser)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                context.Users.Add(newUser);
                context.SaveChanges();

                return newUser.Id > 0;
            }
        }

        /// <summary>
        /// Adding a new expense.
        /// </summary>
        /// <param name="newExpense"></param>
        /// <returns></returns>
        public bool AddNewExpense(Expense newExpense)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                context.Expenses.Add(newExpense);
                context.SaveChanges();

                return newExpense.Id > 0;
            }
        }

        /// <summary>
        /// Delete an existing expense.
        /// </summary>
        /// <param name="selectedExpense"></param>
        public void DeleteSelectedExpense(Expense selectedExpense)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                // Checking if the expense item already existed in the DB.
                Expense selectedItem = context.Expenses
                    .FirstOrDefault(x => x.Id == selectedExpense.Id && x.UserID == selectedExpense.UserID);

                // Delete the item if item is existing.
                if (selectedItem != null)
                {
                    context.Expenses.Remove(selectedItem);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Update an existing expense.
        /// </summary>
        /// <param name="existingExpense"></param>
        public void UpdateExistingExpense(Expense existingExpense)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                // Checking if the expense item already existed in the DB.
                Expense selectedItem = context.Expenses
                    .FirstOrDefault(x => x.Id == existingExpense.Id && x.UserID == existingExpense.UserID);

                // Update the new data to the existing item.
                if (selectedItem != null)
                {
                    selectedItem.CategoryName = existingExpense.CategoryName;
                    selectedItem.Amount = existingExpense.Amount;
                    selectedItem.CreatedDate = existingExpense.CreatedDate;
                }

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Add or update a user currency.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="newCurrency"></param>
        public void AddOrUpdateCurrency(int userId, string newCurrency)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                // Checking if user had a currency preference or not.
                var userCurrency = context.Settings.FirstOrDefault(x => x.Name.Trim().ToLower() == "currency");

                // if yes, just update the value
                if (userCurrency != null)
                {
                    userCurrency.Value = newCurrency;
                }
                else
                {
                    // create a new setting item, with name and value.
                    Setting newSetting = new Setting()
                    {
                        Name = "Currency",
                        Value = newCurrency,
                        UserID = userId
                    };
                    context.Settings.Add(newSetting);
                }

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Update an existing category.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="categoryId"></param>
        /// <param name="newCategoryName"></param>
        public void UpdateCategory(int userId, int categoryId, string newCategoryName)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                // Checking if the category already existed.
                Category category = context.Categories.Where(x => x.Id == categoryId && x.UserID == userId).FirstOrDefault();

                // Update the existing category with new value.
                if (category != null)
                {
                    category.Name = newCategoryName;
                }

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Adding a new category.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="categoryName"></param>
        public void AddCategory(int userId, string categoryName)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                Category category = new Category()
                {
                    Name = categoryName,
                    UserID = userId
                };

                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
    }
}
