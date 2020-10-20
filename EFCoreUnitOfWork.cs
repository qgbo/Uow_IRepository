using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestUOW.Data;
using VWFSCN.TMS.Domain.Core;

namespace VWFSCN.TMS.Infrastructure.Repository
{
    public class EFCoreUnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; set; }

        public EFCoreUnitOfWork(TestUOWContext dbContext)
        {
            this.Context = dbContext;
        }

        public void Commit()
        {
            this.Context.SaveChanges();
        }

        public async Task CommitAsync()
        {
           await this.Context.SaveChangesAsync();
        }
        public void Dispose()
        {
            if (this.Context != null)
            {                
                this.Context.Dispose();
                this.Context = null;
            }
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
