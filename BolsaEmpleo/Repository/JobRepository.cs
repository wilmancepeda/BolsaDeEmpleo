using BolsaEmpleo.DTO.Comun;
using BolsaEmpleo.DTO.Job;
using BolsaEmpleo.IRepository;
using BolsaEmpleo.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaEmpleo.Repository
{
    public class JobRepository : IJobRepository
    {
        ICategoryRepository _categoryRepository;
        private readonly BolsaEmpleoContext _db;

        public JobRepository(ICategoryRepository categoryRepository, BolsaEmpleoContext db)
        {
            _categoryRepository = categoryRepository;
            _db = db;
        }
        public async Task<Response<List<JobByCategoryResponse>>> GetLastJobsForIndex()
        {
            var response = new Response<List<JobByCategoryResponse>>();
            var jobsResponse = new List<JobByCategoryResponse>();

            try
            {
                var categories = await _categoryRepository.GetCategories();

                if (categories.Ok)
                {
                    if (categories.Data.Count > 0)
                    {
                        foreach (var category in categories.Data)
                        {
                            var jobs = await GetLastJobsByCategory(category.IdCategory);

                            if (jobs.Ok)
                            {
                                if (jobs.Data.Count > 0)
                                {
                                    jobsResponse.AddRange(jobs.Data);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                response.Ok = false;
                                response.Mensaje = jobs.Mensaje;

                                return response;
                            }
                        }

                        response.Data = jobsResponse;
                        response.Ok = true;
                        return response;
                    }
                    else
                    {
                        response.Mensaje = "No hay categorias para mostrar";
                        response.Ok = true;

                        return response;
                    }
                }
                else
                {
                    response.Mensaje = categories.Mensaje;
                    response.Ok = false;

                    return response;
                }
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;
                //response.Mensaje = "Error! Algo inesperado ha ocurrido. Por favor, inténte más tarde o ponganse en contacto con el administrador";
                response.Ok = false;

                return response;
            }

        }

        public async Task<Response<List<JobByCategoryResponse>>> GetLastJobsByCategory(int categoryId)
        {
            var response = new Response<List<JobByCategoryResponse>>();

            try
            {
                var jobs = await _db.JobByCategory.FromSqlRaw<JobByCategoryResponse>("getLastJobs @categoryId",
               new SqlParameter("@categoryId", categoryId)
               ).ToListAsync();

                response.Data = jobs;

                response.Ok = true;

                return response;
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;
                response.Ok = false;

                return response;
            }
        }

        public async Task<Response<List<JobByCategoryResponse>>> GetLastJobsForIndex(string query)
        {
            var response = new Response<List<JobByCategoryResponse>>();
            var jobsResponse = new List<JobByCategoryResponse>();

            try
            {
                var categories = await _categoryRepository.GetCategories();

                if (categories.Ok)
                {
                    if (categories.Data.Count > 0)
                    {
                        foreach (var category in categories.Data)
                        {
                            var jobs = await GetJobsByQuery(query, category.IdCategory);

                            if (jobs.Ok)
                            {
                                if (jobs.Data.Count > 0)
                                {
                                    jobsResponse.AddRange(jobs.Data);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                response.Ok = false;
                                response.Mensaje = jobs.Mensaje;

                                return response;
                            }
                        }

                        response.Data = jobsResponse;
                        response.Ok = true;
                        return response;
                    }
                    else
                    {
                        response.Mensaje = "No hay categorias para mostrar";
                        response.Ok = true;

                        return response;
                    }
                }
                else
                {
                    response.Mensaje = categories.Mensaje;
                    response.Ok = false;

                    return response;
                }
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;
                //response.Mensaje = "Error! Algo inesperado ha ocurrido. Por favor, inténte más tarde o ponganse en contacto con el administrador";
                response.Ok = false;

                return response;
            }

        }

        public async Task<Response<List<JobByCategoryResponse>>> GetJobsByQuery(string query, int categoryId)
        {
            var response = new Response<List<JobByCategoryResponse>>();

            try
            {
                var jobs = await _db.JobByCategory.FromSqlRaw<JobByCategoryResponse>("getLastJobsByQuery @query, @categoryId",
               new SqlParameter("@query", query),
               new SqlParameter("@categoryId", categoryId)
               ).ToListAsync();

                response.Data = jobs;

                response.Ok = true;

                return response;
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;
                response.Ok = false;

                return response;
            }
        }

        public async Task<Response<List<JobByCategoryResponse>>> GetJobsByCategory(int categoryId)
        {
            var response = new Response<List<JobByCategoryResponse>>();

            try
            {
                var jobs = await _db.JobByCategory.FromSqlRaw<JobByCategoryResponse>("getJobsByCategory @categoryId",
               new SqlParameter("@categoryId", categoryId)
               ).ToListAsync();

                response.Data = jobs;

                response.Ok = true;

                return response;
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;
                response.Ok = false;

                return response;
            }
        }

        public async Task<Response<JobResponse>> GetJobById(int id)
        {
            var response = new Response<JobResponse>();

            try
            {
                var job = await _db.JobResponse.FromSqlRaw<JobResponse>("getJobById @id",
                new SqlParameter("@id", id)).ToListAsync();

                response.Data = job.FirstOrDefault();

                if (response.Data == null)
                {
                    response.Mensaje = "No se encontró el puesto de trabajo. Por favor, verifique inténte nuevamente";
                }
                response.Ok = true;

                return response;
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;
                response.Ok = false;

                return response;
            }
        }

        public async Task<Response<bool>> CreateJob(CreateJobRequest job)
        {
            var response = new Response<bool>();

            try
            {
                using (var transaction = await _db.Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted))
                {
                    string user = "WilmanC";

                    int result = await _db.Database.ExecuteSqlRawAsync("createJob @categoryId, @employerId, @positionId, @jobType, @ubication, @description, @howApply, @createdBy",
                                    new SqlParameter("@categoryId", job.CategoryId),
                                    new SqlParameter("@employerId", job.EmployerId),
                                    new SqlParameter("@positionId", job.PositionId),
                                    new SqlParameter("@jobType", job.JobType),
                                    new SqlParameter("@ubication", job.Ubication),
                                    new SqlParameter("@description", job.Description),
                                    new SqlParameter("@howApply", job.HowApply),
                                    new SqlParameter("@createdBy", user)

                                    );

                    if (result > 0)
                    {
                        try
                        {
                            await transaction.CommitAsync();
                        }
                        catch (Exception e)
                        {
                            await transaction.RollbackAsync();
                            await transaction.DisposeAsync();
                            response.Data = false;
                            response.Ok = false;
                            response.Mensaje = e.Message;

                            return response;

                        }

                        response.Data = true;
                        response.Ok = true;
                        response.Mensaje = "Creado correctamente";

                        return response;
                    }

                    try
                    {
                        await transaction.RollbackAsync();
                    }
                    catch (Exception e)
                    {
                        await transaction.RollbackAsync();
                        await transaction.DisposeAsync();
                        response.Data = false;
                        response.Ok = false;
                        response.Mensaje = e.Message;

                        return response;

                    }
                   

                }

                response.Data = false;
                response.Ok = false;
                response.Mensaje = "No se pudo Actualizar. Por favor, verifique e inténte nuevamente";
                return response;


            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;
                response.Ok = false;

                return response;
            }
        }

        public async Task<Response<bool>> Delete(int id)
        {
            var response = new Response<bool>();

            try
            {
                var result = await _db.Database.ExecuteSqlRawAsync("inactiveJob @id",
                new SqlParameter("@id", id));

                if (result > 0)
                {
                    response.Data = true;
                    response.Mensaje = "Eliminado con exito";
                    response.Ok = true;
                    return response;
                }

                response.Data = false;
                response.Mensaje = "No se pudo eliminar. Por favor, inténte nuevamente";
                response.Ok = true;

                return response;
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;
                response.Ok = false;
                response.Data = false;
                return response;
            }
        }
    }
}
