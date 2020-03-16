using ExpenseLoggerDAL;
using System.Linq;

namespace ExpenseLoggerBLL.Commands
{
    public class ExpenseLoggerCommands
    {
        public bool AddNewUser(User newUser)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                context.Users.Add(newUser);
                context.SaveChanges();

                return newUser.Id > 0;
            }
        }

        public bool AddNewExpense(Expense newExpense)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                context.Expenses.Add(newExpense);
                context.SaveChanges();

                return newExpense.Id > 0;
            }
        }

        public void DeleteSelectedExpense(Expense selectedExpense)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                Expense selectedItem = context.Expenses
                    .FirstOrDefault(x => x.Id == selectedExpense.Id && x.UserID == selectedExpense.UserID);
                if (selectedItem != null)
                {
                    context.Expenses.Remove(selectedItem);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateExistingExpense(Expense existingExpense)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                Expense selectedItem = context.Expenses
                    .FirstOrDefault(x => x.Id == existingExpense.Id && x.UserID == existingExpense.UserID);
                if(selectedItem != null)
                {
                    selectedItem.CategoryName = existingExpense.CategoryName;
                    selectedItem.Amount = existingExpense.Amount;
                    selectedItem.CreatedDate = existingExpense.CreatedDate;
                }

                context.SaveChanges();
            }
        }

        public void AddOrUpdateCurrency(int userId, string newCurrency)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                var userCurrency = context.Settings.FirstOrDefault(x => x.Name.Trim().ToLower() == "currency");
                if (userCurrency != null)
                {
                    userCurrency.Value = newCurrency;
                }
                else
                {
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

        public void UpdateCategory(int userId, int categoryId, string newCategoryName)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                Category category = context.Categories.Where(x => x.Id == categoryId && x.UserID == userId)
                    .FirstOrDefault();
                if(category != null)
                {
                    category.Name = newCategoryName;
                }

                context.SaveChanges();
            }
        }

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
