using ExpenseLoggerDAL;
using System.Linq;

namespace ExpenseLoggerBLL.Queries
{
    public class ExpenseLoggerQueries
    {
        public ExpenseLoggerQueries()
        {
        }

        public static User GetUserByIdAsync(int id)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                return context.Users.FirstOrDefault(x => x.Id == id);
            }
        }
    }
}
