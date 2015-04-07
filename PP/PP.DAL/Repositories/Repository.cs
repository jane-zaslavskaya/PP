using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PP.Core.Data.Base;
using PP.DAL.Interfaces;
using PP.EF;

namespace PP.DAL.Repositories
{
    /// <summary>
    /// The repository.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// The data context.
        /// </summary>
        public PPContext dataContext { get; set; }

        public Repository(PPContext dataCont)
        {
            dataContext = dataCont;
        }

        /// <summary>
        /// Gets the current set.
        /// </summary>
        /// <value>The current set.</value>
        private IDbSet<T> CurrentSet
        {
            get { return this.dataContext.Set<T>(); }
        }

        public IDbSet<T> CurrentSetPublic
        {
            get { return this.dataContext.Set<T>(); }
        }

        #region IRepository<T> Members

        /// <summary>
        /// The search for.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return this.CurrentSet.Where(predicate);
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<T> GetAll()
        {
            return this.CurrentSet;
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public new T GetById(long id)
        {
            var value = this.CurrentSet.FirstOrDefault(e => e.Id.Equals(id));

            return value;
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(T entity)
        {
            this.CurrentSet.Attach(entity);
            this.CurrentSet.Remove(entity);
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Save(T entity)
        {
            if (this.dataContext.Entry(entity).State == EntityState.Detached)
            {
                this.CurrentSet.Add(entity);
            }
        }

        public int AddOrUpdate(T entity)
        {
            if (entity.Id == 0)
            {
                this.CurrentSet.Add(entity);
            }
            else
            {
                var existing = this.CurrentSet.Find(entity.Id);
                dataContext.Entry(existing).CurrentValues.SetValues(entity);
            }

            this.dataContext.SaveChanges();
            return (int) entity.Id;
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
            this.dataContext.SaveChanges();
        }

        public void Dispose()
        {
            if (dataContext != null)
            {
                dataContext.Dispose();
            }
        }

        #endregion
    }
}