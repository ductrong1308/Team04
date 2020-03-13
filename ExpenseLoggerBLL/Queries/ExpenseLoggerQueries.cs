using ExpenseLoggerDAL;
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
    }
}
