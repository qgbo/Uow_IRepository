using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VWFSCN.TMS.Domain.Core
{
    /// <summary>
    /// Repository Interface
    /// </summary>
    /// <typeparam name="TData">Data Type</typeparam>
    public interface IRepository< TData>
    {
      //  IUnitOfWork unitOfWork { get; set; }

        void Commit();
        Task CommitAsync(); 
        /// <summary>
        /// Find By Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        TData FindById(long id);

        /// <summary>
        /// Find One
        /// </summary>
        /// <param name="predicate">Predicate Expression</param>
        /// <returns></returns>
        TData FindOne(Expression<Func<TData, bool>> predicate);

        /// <summary>
        /// Find
        /// </summary>
        /// <param name="predicate">Predicate Expression</param>
        /// <returns></returns>
        IQueryable<TData> Find(Expression<Func<TData, bool>> predicate);
        TData Single(Expression<Func<TData, bool>> predicate);
        

        /// <summary>
        /// Count
        /// </summary>
        /// <param name="predicate">Predicate Expression</param>
        /// <returns></returns>
        int Count(Expression<Func<TData, bool>> predicate);

        IQueryable<TData> GetAll();
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        TData Add(TData entity);
        TData Update(TData entity);
        void Attach(TData entity);
        void AddRange(TData[] entities);
        void UpdateRange(TData[] entities);

        void ExcludeProperty(TData entity, params string[] properpties);
        TData FirstOrDefault(Expression<Func<TData, bool>> predicate);

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="entity">Entity</param>
        void Remove(TData entity);
        bool RemoveRange(Expression<Func<TData, bool>> predicate);
    }
}
