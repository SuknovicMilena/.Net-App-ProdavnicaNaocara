﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProdavnicaNaocara.Data.Repositories
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        #region Fields

        /// <summary>
        /// Database context
        /// </summary>
        protected DbContext context;

        /// <summary>
        /// Database set for entity
        /// </summary>
        protected readonly DbSet<TEntity> dbSet;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructor that accepts database context
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public BaseRepository(DbContext dbContext)
        {
            context = dbContext;
            dbSet = context.Set<TEntity>();
            context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Attach list of entities 
        /// </summary>
        /// <param name="entities"></param>
        public virtual void Attach(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (context.Entry(entity).State == EntityState.Detached) context.Set<TEntity>().Attach(entity);
            }
        }

        /// <summary>
        /// Insert new entity
        /// </summary>
        /// <param name="entity">Entity for insert</param>
        public virtual void Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            dbSet.Add(entity);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity for update</param>
        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Delete entity by its id
        /// </summary>
        /// <param name="id">Id of entity that needs to be deleted</param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity for delete</param>
        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
        }

        #region Sync

        /// <summary>
        /// Delete entity/entities based on supplied filter
        /// </summary>
        /// <param name="filter">Filter that specifies entities that needs to be deleted</param>
        public virtual void Delete(Expression<Func<TEntity, bool>> filter)
        {
            var records = Find(filter);

            foreach (var record in records)
            {
                Delete(record);
            }
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>List of entities</returns>
        public virtual List<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        /// <summary>
        /// Get entity by its id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Entity object</returns>
        public virtual TEntity GetById(params object[] ids)
        {
            return dbSet.Find(ids);
        }

        /// <summary>
        /// Find entities based on supplied criteria
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order by clause</param>
        /// <param name="include">Include properties</param>
        /// <returns>List of entities</returns>
        public virtual List<TEntity> Find(Expression<Func<TEntity, bool>> filter = null,
                                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                          string include = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                foreach (var includeProperty in include.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        /// <summary>
        /// Get single entity
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns>Entity</returns>
        public virtual TEntity Single(Expression<Func<TEntity, bool>> filter)
        {
            return dbSet.Single(filter);
        }

        /// <summary>
        /// Get single entity if exists and return null if it does not
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns>Entity</returns>
        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filter)
        {
            return dbSet.SingleOrDefault(filter);
        }

        /// <summary>
        /// Get first entity that match filter
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns>Entity</returns>
        public virtual TEntity First(Expression<Func<TEntity, bool>> filter)
        {
            return dbSet.First(filter);
        }

        /// <summary>
        /// Get first entity if exists and return null if it does not
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns>Entity</returns>
        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter)
        {
            return dbSet.FirstOrDefault(filter);
        }

        /// <summary>
        /// Get total number of entities
        /// </summary>
        /// <returns>Number of entities</returns>
        public virtual int Count()
        {
            return dbSet.Count();
        }

        /// <summary>
        /// Get number of entities that match criteria
        /// </summary>
        /// <param name="criteria">Criteria for match</param>
        /// <returns>Number of entities</returns>
        public virtual int Count(Expression<Func<TEntity, bool>> criteria)
        {
            return dbSet.Where(criteria).Count();
        }

        /// <summary>
        /// Save changes on context
        /// </summary>
        public virtual void Save()
        {
            context.ChangeTracker.DetectChanges();
            context.SaveChanges();
        }

        #endregion Sync

        #region Async

        /// <summary>
        /// Delete entity/entities based on supplied filter
        /// </summary>
        /// <param name="filter">Filter that specifies entities that needs to be deleted</param>
        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> filter)
        {
            var records = await FindAsync(filter);

            foreach (var record in records)
            {
                Delete(record);
            }
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>List of entities</returns>
        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return dbSet.ToListAsync();
        }

        /// <summary>
        /// Get entity by its id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Entity object</returns>
        public virtual Task<TEntity> GetByIdAsync(params object[] ids)
        {
            return dbSet.FindAsync(ids);
        }

        /// <summary>
        /// Find entities based on supplied criteria
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order by clause</param>
        /// <param name="includeProperties">Include properties</param>
        /// <returns>List of entities</returns>
        public virtual Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter = null,
                                                     Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                     string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToListAsync();
            }
            else
            {
                return query.ToListAsync();
            }
        }

        /// <summary>
        /// Get single entity
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns>Entity</returns>
        public virtual Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> filter)
        {
            return dbSet.SingleAsync(filter);
        }

        /// <summary>
        /// Get first entity that match filter
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns>Entity</returns>
        public virtual Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> filter)
        {
            return dbSet.FirstAsync(filter);
        }

        /// <summary>
        /// Get total number of entities
        /// </summary>
        /// <returns>Number of entities</returns>
        public virtual Task<int> CountAsync()
        {
            return dbSet.CountAsync();
        }

        /// <summary>
        /// Get number of entities that match criteria
        /// </summary>
        /// <param name="criteria">Criteria for match</param>
        /// <returns>Number of entities</returns>
        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> criteria)
        {
            return dbSet.Where(criteria).CountAsync();
        }

        #endregion Async

        #region IDisposable

        /// <summary>
        /// Dispose objects
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose object based on flag value
        /// </summary>
        /// <param name="disposing">Flag that indicates if disposing is in progress</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing &&
                context != null)
            {
                context.Dispose();
                context = null;
            }
        }

        #endregion IDisposable

        #endregion Methods
    }
}
