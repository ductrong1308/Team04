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
                Expense selectedItem = context.Expenses.FirstOrDefault(x => x.Id == selectedExpense.Id);
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
                Expense selectedItem = context.Expenses.FirstOrDefault(x => x.Id == existingExpense.Id);
                selectedItem.CategoryName = existingExpense.CategoryName;
                selectedItem.Amount = existingExpense.Amount;
                selectedItem.CreatedDate = existingExpense.CreatedDate;

                context.SaveChanges();
            }
        }
    }
}
