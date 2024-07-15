using System.Collections.Generic;
using System.Linq;
using UserJobsTracker.BL.DTOs;
using UserJobsTracker.DAL.Models;
using UserJobsTracker.DAL.Repositories;

namespace UserJobsTracker.BL.Managers
{
    public class JobsManager
    {
        #region Fields
        private readonly IRepository<Job, long> _repository;
        #endregion

        #region CTOR
        public JobsManager(IRepository<Job, long> repository)
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

        public UpdateJobNameDto GetById(int id)
        {
            var job = _repository.GetById(id);

            var updateJobDTO = new UpdateJobNameDto
            {
                Id = job.Id,
                Name = job.Name,
                //HireDate = job.HireDate,
                //BranchId = job.BranchId,
            };

            return updateJobDTO;
        }

        public void Add(CreateJobDTO job)
        {
            var addedJob = new Job
            {
                Name = job.Name,
                HireDate = job.HireDate,
                LeaveDate = job.LeaveDate,
                BranchId = job.BranchId,
            };
            _repository.Add(addedJob);
            _repository.SaveChanges();
        }

        public void Update(UpdateJobNameDto updateJobDTO)
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

        public bool DeleteMultiple(List<long> idsList)
        {
            //var deletedEntities = _repository
            //    .GetAll()
            //    .Where(job => idsList.Contains(job.Id))
            //    .ToList();

            _repository.DeleteMultiple(idsList);
            _repository.SaveChanges();
            return true;
        }
        #endregion
    }
}
