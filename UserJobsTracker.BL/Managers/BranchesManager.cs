using System.Collections.Generic;
using System.Linq;
using UserJobsTracker.BL.DTOs;
using UserJobsTracker.DAL.Models;
using UserJobsTracker.DAL.Repositories;

namespace UserJobsTracker.BL.Managers
{
    public class BranchesManager
    {
        private readonly IRepository<Branch, int> _repository;
        public BranchesManager(IRepository<Branch, int> repository)
        {
            _repository = repository;
        }

        public List<BranchDTO> GetAll()
        {
            var branches = _repository
                .GetAll()
                .Select(branch => new BranchDTO
                {
                    Id = branch.Id, 
                    Name = branch.Name,
                })
                .ToList();

            return branches;
        }
    }
}
