using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MovieManagement.Repositories
{
    public class GenericRepository<TEntity> : IDisposable
        where TEntity: class
    {
        private Microsoft.EntityFrameworkCore.DbContext _context;

        public GenericRepository(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            _context = dbContext;
        }

        public virtual TEntity Add(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity) as TEntity;
        }

        public virtual void Delete(int id)
        {
            var item = _context.Set<TEntity>().Find(id);
            _context.Set<TEntity>().Remove(item);
        }

        public IQueryable<TEntity> Get()
        {
            return _context.Set<TEntity>();
        }

        public virtual bool SaveChanges()
        {
            return 0 < _context.SaveChanges();
        }

        public void Dispose()
        {
            if (null != _context)
            {
                _context.Dispose();
            }
        }

    }
}
