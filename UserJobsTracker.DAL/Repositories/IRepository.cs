using System.Collections.Generic;

namespace UserJobsTracker.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        void SaveChanges();
    }
}
