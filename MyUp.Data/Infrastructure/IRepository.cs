using System;
using System.Linq;
using System.Linq.Expressions;

namespace MyUp.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void DeleteMulti(Expression<Func<T, bool>> where);

        T GetSingleById(int id);

        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] strings = null);

        IQueryable<T> GetAll(string[] strings = null);

        IQueryable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] strings = null);

        IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] strings = null);

        int Count(Expression<Func<T, bool>> where);

        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}