using System.Collections.Generic;
using UserJobsTracker.DAL.Models;
using UserJobsTracker.DAL.Repositories;

namespace UserJobsTracker.BL.Managers
{
    public class BranchesManager
    {
        private readonly IRepository<Branch> _repository;

        public BranchesManager(IRepository<Branch> repository)
        {
            _repository = repository;
        }

        public List<Branch> GetAll()
        {
            var branches = _repository.GetAll();
            return branches;
        }
    }
}
