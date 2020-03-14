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

        public void DeleteSelectedExpense(int selectedExpenseId)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                Expense selectedItem = context.Expenses.FirstOrDefault(x => x.Id == selectedExpenseId);
                if (selectedItem != null)
                {
                    context.Expenses.Remove(selectedItem);
                    context.SaveChanges();
                }
            }
        }
    }
}
