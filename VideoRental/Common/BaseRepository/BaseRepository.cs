using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using VideoRental.Common.BaseClass;

namespace VideoRental.Common.BaseRepository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public TEntity Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            ModifiedTimestamps();
            _context.SaveChanges();

            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            ModifiedTimestamps();
            _context.SaveChanges();

            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            var entities = _context.ChangeTracker.Entries()
              .Where(e => e.Entity is BaseEntity && e.State == EntityState.Unchanged);

            foreach (var item in entities)
            {
                if (item.State == EntityState.Unchanged)
                {
                    ((BaseEntity)item.Entity).IsDeleted = true;
                    ((BaseEntity)item.Entity).ModifiedTime = DateTime.Now;
                    ((BaseEntity)item.Entity).ModifiedBy = GetUserName();
                }
            }

            _context.SaveChanges();

            return entity;
        }

        private void ModifiedTimestamps()
        {
            var entities = _context.ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedTime = DateTime.Now;
                    ((BaseEntity)entity.Entity).CreatedBy = GetUserName();
                }
                else if (entity.State == EntityState.Modified)
                {
                    ((BaseEntity)entity.Entity).ModifiedTime = DateTime.Now;
                    ((BaseEntity)entity.Entity).ModifiedBy = GetUserName();
                }
            }
        }

        private string GetUserName()
        {
            return System.Security.Principal.GenericPrincipal.Current.Identity.Name;
        }
    }
}
