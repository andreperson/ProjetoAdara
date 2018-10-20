using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repository.Interface;
using Data.DataContext; 
using System.Linq.Expressions;
using System.Data.Entity; 

namespace Data.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        ConnDataContext db = new ConnDataContext(); 

        #region IGenericRepository<T> Members

        public virtual IQueryable<T> ListAll()
        {
            IQueryable<T> query = db.Set<T>();
            return query;
        }

        public virtual IQueryable<T> Search(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = db.Set<T>().Where(predicate);
            return query;
        }


        public virtual T Find(int _id)
        {
            return db.Set<T>().Find(_id);
        }

        public virtual void Add(T entity)
        {
            db.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            db.Set<T>().Remove(entity);
        }

        public virtual void DeleteRange(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = db.Set<T>().Where(predicate);

            db.Set<T>().RemoveRange(query);

        }

        public virtual void Edit(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            db.SaveChanges();
        }

        public virtual void Dispose()
        {
            db.Dispose();
        }

        #endregion
    }
}
