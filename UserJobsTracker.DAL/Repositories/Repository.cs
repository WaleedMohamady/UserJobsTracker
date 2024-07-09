using System.Linq;
using UserJobsTracker.DAL.Context;

namespace UserJobsTracker.DAL.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
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
        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public TEntity GetById(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Update<TUpdateEntityDTO>(TUpdateEntityDTO updateEntityDTO, TKey id) where TUpdateEntityDTO : class
        {
            TEntity entity = GetById(id);
            _context.Entry(entity).CurrentValues.SetValues(updateEntityDTO);
        }

        public void Delete(TKey id)
        {
            var deletedEntity = GetById(id);
            _context.Set<TEntity>().Remove(deletedEntity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        #endregion
    }
}