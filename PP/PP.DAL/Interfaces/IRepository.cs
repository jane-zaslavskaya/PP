using System;
using System.Linq;
using System.Linq.Expressions;
using PP.Core.Data.Base;

namespace PP.DAL.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Dispose();

        /// <summary>
        /// The save.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Save(T entity);

        int AddOrUpdate(T entity);

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Remove(T entity);

        /// <summary>
        /// The search for.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T GetById(long id);

        /// <summary>
        /// Saves the changes.
        /// </summary>
        void SaveChanges();
    }
}