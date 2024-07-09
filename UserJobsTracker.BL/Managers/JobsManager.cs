using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using UserJobsTracker.BL.DTOs;
using UserJobsTracker.DAL.Models;
using UserJobsTracker.DAL.Repositories;

namespace UserJobsTracker.BL.Managers
{
    public class JobsManager
    {
        #region Fields
        private readonly IRepository<Job, int> _repository;
        #endregion

        #region CTOR
        public JobsManager(IRepository<Job, int> repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        public List<JobDTO> GetAllByBranchId(int? branchId)
        {
            var jobsQuery = _repository
                .GetAll();

            if (branchId.HasValue)
            {
                jobsQuery = jobsQuery
                    .Where(job => job.BranchId == branchId);
            }
            
            var jobs = jobsQuery
                .Select(job => new JobDTO
                {
                    Id = job.Id,
                    Name = job.Name,
                    HireDate = job.HireDate
                })
                .ToList();

            return jobs;
        }

        public UpdateJobDTO GetById(int id)
        {
            var job = _repository.GetById(id);

            var updateJobDTO = new UpdateJobDTO
            {
                Id = job.Id,
                Name = job.Name,
                HireDate = job.HireDate,
                BranchId = job.BranchId,
            };

            return updateJobDTO;
        }

        public void Add(CreateJobDTO job)
        {
            var addedJob = new Job
            {
                Name = job.Name,
                HireDate = job.HireDate,
                BranchId = job.BranchId,
            };
            _repository.Add(addedJob);
            _repository.SaveChanges();
        }

        public void Update(UpdateJobDTO updateJobDTO)
        {
            _repository.Update(updateJobDTO, updateJobDTO.Id);
            _repository.SaveChanges();
        }

        public bool Delete(int id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
            return true;
        }
        #endregion
    }
}
