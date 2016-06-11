using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MyUp.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        #region Properties

        private EntitiesDbContext _entitiesDbContext;
        private readonly IDbSet<T> _dbSet;

        private IDbFactory DbFactory
        {
            get;
        }

        private EntitiesDbContext DbContext => _entitiesDbContext ?? (_entitiesDbContext = DbFactory.Init());

        #endregion Properties

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<T>();
        }

        #region Implementation

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _entitiesDbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void DeleteMulti(Expression<Func<T, bool>> where)
        {
            var objects = _dbSet.Where(where).AsEnumerable();
            foreach (var obj in objects)
                _dbSet.Remove(obj);
        }

        public virtual T GetSingleById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where, string includes)
        {
            return _dbSet.Where(where).ToList();
        }

        public virtual int Count(Expression<Func<T, bool>> where)
        {
            return _dbSet.Count(where);
        }

        private IQueryable<T> GetAll(string[] includes = null)
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes == null || !includes.Any()) return _entitiesDbContext.Set<T>().AsQueryable();
            var query = _entitiesDbContext.Set<T>().Include(includes.First());
            query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));
            return query.AsQueryable();
        }

        public T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            return GetAll(includes).FirstOrDefault(expression);
        }

        public virtual IQueryable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes == null || !includes.Any())
                return _entitiesDbContext.Set<T>().Where(predicate).AsQueryable();
            var query = _entitiesDbContext.Set<T>().Include(includes.First());
            query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));
            return query.Where(predicate).AsQueryable();
        }

        public virtual IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> predicate, out int total, int index = 0,
            int size = 20, string[] includes = null)
        {
            var skipCount = index * size;
            IQueryable<T> resetSet;

            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Any())
            {
                var query = _entitiesDbContext.Set<T>().Include(includes.First());
                query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));
                resetSet = predicate != null ? query.Where(predicate).AsQueryable() : query.AsQueryable();
            }
            else
            {
                resetSet = predicate != null ? _entitiesDbContext.Set<T>().Where(predicate).AsQueryable() : _entitiesDbContext.Set<T>().AsQueryable();
            }

            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();
            return resetSet.AsQueryable();
        }

        public bool CheckContains(Expression<Func<T, bool>> predicate)
        {
            return _entitiesDbContext.Set<T>().Count(predicate) > 0;
        }

        #endregion Implementation
    }
}