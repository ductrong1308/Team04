using ExpenseLoggerDAL;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace ExpenseLoggerInfrastructure.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository()
        {
        }

        //public async Task<List<User>> GetUsersAsync()
        //{
        //    var users = await this.currentContext.Users.ToListAsync();
        //    return users;
        //}
    }
}
