using BolsaEmpleo.DTO.Comun;
using BolsaEmpleo.DTO.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaEmpleo.IRepository
{
    public interface IJobRepository
    {
        public Task<Response<List<JobByCategoryResponse>>> GetJobsByCategory(int categoryId);
        public Task<Response<List<JobByCategoryResponse>>> GetJobsByQuery(string query, int categoryId);

        public Task<Response<List<JobByCategoryResponse>>> GetJobsForJobIndex();
        public Task<Response<List<JobByCategoryResponse>>> GetJobsForJobIndex(string query);
    }
}
