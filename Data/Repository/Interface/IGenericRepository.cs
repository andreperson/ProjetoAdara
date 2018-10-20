using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;  

namespace Data.Repository.Interface
{
    public interface IGenericRepository<T> where T : class 
    {
        IQueryable<T> ListAll();
        IQueryable<T> Search(Expression<Func<T, bool>> predicate);
        T Find(int id);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
        void Dispose();
    }
}
