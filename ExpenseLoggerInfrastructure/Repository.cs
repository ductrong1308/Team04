using ExpenseLoggerDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseLoggerInfrastructure
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public Repository()
        {
        }

        public TEntity GetByIdAsync(int id)
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();
                return query.SingleOrDefault(x => x.Id == id);
            }
        }

        public List<TEntity> GetListItems()
        {
            using (ExpenseLoggerDBContext context = new ExpenseLoggerDBContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();
                return query.ToList();
            }
        }
    }
}
