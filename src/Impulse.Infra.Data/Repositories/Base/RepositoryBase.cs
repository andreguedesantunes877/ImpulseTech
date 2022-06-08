using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Impulse.Domain.Interfaces.Repositories.Base;
using Impulse.Infra.Data.Context;

namespace Impulse.Infra.Data.Repositories.Base
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected ImpulseContext Db = new ImpulseContext();
        
        public TEntity Add(TEntity obj)
        {
            try
            {
                Db.Set<TEntity>().Add(obj);
                Db.SaveChanges();

                return obj;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public TEntity Update(TEntity obj)
        {
            try
            {
                Db.Entry(obj).State = EntityState.Modified;
                Db.SaveChanges();

                return obj;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Remove(TEntity obj)
        {
            try
            {
                Db.Set<TEntity>().Remove(obj);
                Db.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) 
                return;
            
            Db?.Dispose();
        }
    }
}