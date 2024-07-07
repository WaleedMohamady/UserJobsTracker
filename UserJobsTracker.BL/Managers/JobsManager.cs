using System.Collections.Generic;
using System.Linq;
using UserJobsTracker.BL.DTOs;
using UserJobsTracker.DAL.Models;
using UserJobsTracker.DAL.Repositories;

namespace UserJobsTracker.BL.Managers
{
    public class JobsManager
    {
        private readonly IRepository<Job> _repository;

        public JobsManager(IRepository<Job> repository)
        {
            _repository = repository;
        }

        public List<JobDTO> GetAll()
        {
            var jobs = _repository
                .GetAll()
                .Select(job => new JobDTO
                {
                    Id = job.Id,
                    Name = job.Name,
                    HireDate = job.HireDate.ToShortDateString(),
                })
                .ToList();

            return jobs;
        }

        public Job GetById(int id)
        {
            var job = _repository.GetById(id);
            return job;
        }

        public void Add(Job job)
        {
            _repository.Add(job);
            _repository.SaveChanges();
        }

        public void Update(Job job)
        {
            var oldJob = _repository.GetById(job.Id);
            oldJob.Name = job.Name;
            oldJob.HireDate = job.HireDate;
            oldJob.BranchId = job.BranchId;
            _repository.SaveChanges();
        }

        public bool Delete(int id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
            return true;
        }
    }
}
