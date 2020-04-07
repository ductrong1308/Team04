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
        public bool DeleteSelectedExpense(Expense selectedExpense)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                // Check if item is successful deleted or not.
                bool isItemDeleted = false;

                // Checking if the expense item already existed in the DB.
                Expense selectedItem = context.Expenses
                    .FirstOrDefault(x => x.Id == selectedExpense.Id && x.UserID == selectedExpense.UserID);

                // Delete the item if item is existing.
                if (selectedItem != null)
                {
                    context.Expenses.Remove(selectedItem);
                    context.SaveChanges();
                    isItemDeleted = true;
                }

                return isItemDeleted;
            }
        }

        /// <summary>
        /// Delete an existing Category.
        /// </summary>
        /// <param name="selectedCategory"></param>
        public bool DeleteSelectedCategory(Category selectedCategory)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                // Check if item is successful deleted or not.
                bool isItemDeleted = false;

                // Checking if the expense item already existed in the DB.
                Category selectedItem = context.Categories
                    .FirstOrDefault(x => x.Id == selectedCategory.Id && x.UserID == selectedCategory.UserID);

                // Delete the item if item is existing.
                if (selectedItem != null)
                {
                    context.Categories.Remove(selectedItem);
                    context.SaveChanges();
                    isItemDeleted = true;
                }

                return isItemDeleted;
            }
        }

        /// <summary>
        /// Update an existing expense.
        /// </summary>
        /// <param name="existingExpense"></param>
        public bool UpdateExistingExpense(Expense existingExpense)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                // Check if item is successful updated or not.
                bool isItemUpdated = false;

                // Checking if the expense item already existed in the DB.
                Expense selectedItem = context.Expenses
                    .FirstOrDefault(x => x.Id == existingExpense.Id && x.UserID == existingExpense.UserID);

                // Update the new data to the existing item.
                if (selectedItem != null)
                {
                    selectedItem.CategoryName = existingExpense.CategoryName;
                    selectedItem.Amount = existingExpense.Amount;
                    selectedItem.CreatedDate = existingExpense.CreatedDate;
                    context.SaveChanges();

                    isItemUpdated = true;
                }

                return isItemUpdated;
            }
        }

        /// <summary>
        /// Update an existing category.
        /// </summary>
        /// <param name="existingCategory"></param>
        public bool UpdateExistingCategory(Category existingCategory)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                // Check if item is successful updated or not.
                bool isItemUpdated = false;

                // Checking if the expense item already existed in the DB.
                Category selectedItem = context.Categories
                    .FirstOrDefault(x => x.Id == existingCategory.Id && x.UserID == existingCategory.UserID);

                // Update the new data to the existing item.
                if (selectedItem != null)
                {
                    selectedItem.Name = existingCategory.Name;
                    context.SaveChanges();
                    isItemUpdated = true;
                }

                return isItemUpdated;
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
                var userCurrency = context.Settings.FirstOrDefault(x => x.Name.Trim().ToLower() == "currency" && x.UserID == userId);

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
