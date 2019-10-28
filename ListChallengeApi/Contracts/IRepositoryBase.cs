using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expressions);
        IQueryable<T> FindAll();
        void Create(T entity);
        void DeleteAll(IEnumerable<T> entity);
        void Delete(T entity);
    }
}
