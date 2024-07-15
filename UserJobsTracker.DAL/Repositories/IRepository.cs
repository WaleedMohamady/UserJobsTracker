using System.Collections.Generic;
using System.Linq;

namespace UserJobsTracker.DAL.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(TKey id);
        void Add(TEntity entity);
        void Update<TUpdateEntityDTO>(TUpdateEntityDTO updateEntityDTO, TKey id) where TUpdateEntityDTO : class;
        void Delete(TKey id);
        void DeleteMultiple(List<TKey> entitiesToDelete);
        void SaveChanges();
    }
}
