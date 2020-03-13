using ExpenseLoggerDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseLoggerInfrastructure
{
    public interface IRepository<TEntity> where TEntity: BaseEntity
    {
        TEntity GetByIdAsync(int id);

        List<TEntity> GetListItems();
    }
}
