using BolsaEmpleo.DTO.Comun;
using BolsaEmpleo.DTO.Job;
using BolsaEmpleo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaEmpleo.IRepository
{
    public interface IJobRepository
    {
        public Task<Response<List<JobByCategoryResponse>>> GetLastJobsByCategory(int categoryId);
        public Task<Response<List<JobByCategoryResponse>>> GetJobsByCategory(int categoryId);
        public Task<Response<List<JobByCategoryResponse>>> GetJobsByQuery(string query, int categoryId);
        public Task<Response<JobResponse>> GetJobById(int id);
        public Task<Response<List<JobByCategoryResponse>>> GetLastJobsForIndex();
        public Task<Response<List<JobByCategoryResponse>>> GetLastJobsForIndex(string query);
        public Task<Response<bool>> CreateJob(CreateJobRequest job);
        public Task<Response<bool>> Delete(int id);

    }
}
