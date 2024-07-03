using System.Collections.Generic;
using System.Linq;
using UserJobsTracker.DAL.Context;

namespace UserJobsTracker.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Fields
        private readonly UserJobsTrackerDbContext _context;
        #endregion

        #region Ctor
        public Repository(UserJobsTrackerDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {

        }

        public void Delete(int id)
        {
            var deletedEntity = GetById(id);
            if (deletedEntity != null)
            {
                _context.Set<TEntity>().Remove(deletedEntity);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        #endregion
    }
}