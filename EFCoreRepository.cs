using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestUOW.Data;
using VWFSCN.TMS.Domain.Core;

namespace VWFSCN.TMS.Infrastructure.Repository
{
    public class EFCoreRepository<TEntityType> :  IRepository<TEntityType> where TEntityType : class
    {
        public DbContext Context { get; set; }

        public EFCoreRepository(TestUOWContext unitOfWork)
        {
            this.Context = unitOfWork;
        }

        public void Commit()
        {
            //  this.unitOfWork.Commit();
            this.Context.SaveChanges();
        }
        public async Task CommitAsync()
        {
          //await  this.unitOfWork.CommitAsync();
        }
       

        

        public TEntityType Add(TEntityType entity)
        {
            return this.Context.Set<TEntityType>().Add(entity).Entity;
        }

        public void AddRange(TEntityType[] entities)
        {
             this.Context.Set<TEntityType>().AddRange(entities);
        }

        public TEntityType Update(TEntityType entity)
        {
            return this.Context.Set<TEntityType>().Update(entity).Entity;
        }

        public void ExcludeProperty(TEntityType entity,params string[] properpties)
        {
            foreach (var item in properpties)
            {
                Context.Entry(entity).Property(item).IsModified = false;
            }
        }


        public void UpdateRange(TEntityType[] entities)
        {
             this.Context.Set<TEntityType>().UpdateRange(entities);
        }

        public void Attach(TEntityType entity)
        {
            this.Context.Set<TEntityType>().Attach(entity);
        }

        public TEntityType FirstOrDefault(Expression<Func<TEntityType, bool>> predicate)
        {
            return this.Context.Set<TEntityType>().FirstOrDefault(predicate);
        }

        public TEntityType Single(Expression<Func<TEntityType, bool>> predicate)
        {
            return this.Context.Set<TEntityType>().Single(predicate);
        }

        public int Count(Expression<Func<TEntityType, bool>> predicate)
        {
            return this.Context.Set<TEntityType>().Count(predicate);
        }

        public IQueryable<TEntityType> Find(Expression<Func<TEntityType, bool>> predicate)
        {
            return this.Context.Set<TEntityType>().Where(predicate);
        }

        public IQueryable<TEntityType> GetAll()
        {
            return this.Context.Set<TEntityType>().AsQueryable();
        }

        public TEntityType FindById(long id)
        {
            int m = (int)id;
            return this.Context.Set<TEntityType>().Find(m);
        }

        public TEntityType FindOne(Expression<Func<TEntityType, bool>> predicate)
        {
            return this.Context.Set<TEntityType>().FirstOrDefault(predicate);
        }

        public void Remove(TEntityType entity)
        {
            this.Context.Set<TEntityType>().Remove(entity);
        }
        public bool RemoveRange(Expression<Func<TEntityType, bool>> predicate)
        {
            var s = this.Find(predicate).AsNoTracking().ToArray();
            if (s.Length > 0)
                this.Context.Set<TEntityType>().RemoveRange(s);
            return s.Length>0;
        }

    }
}
