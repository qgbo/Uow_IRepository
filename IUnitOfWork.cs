using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VWFSCN.TMS.Domain.Core
{
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Context
        /// </summary>
        DbContext Context { get; set; }

        /// <summary>
        /// Commit
        /// </summary>
        void Commit();

        Task CommitAsync();
        /// <summary>
        /// Rollback
        /// </summary>
        void Rollback();
    }
}
