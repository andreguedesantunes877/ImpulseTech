using System.Collections.Generic;

namespace Impulse.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity Add(TEntity obj);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        TEntity Update(TEntity obj);

        bool Remove(TEntity obj);

        void Dispose();
    }
}