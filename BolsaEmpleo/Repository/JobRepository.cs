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
        public async Task<Response<List<JobByCategoryResponse>>> GetJobsForJobIndex()
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
                            var jobs = await GetJobsByCategory(category.IdCategory);

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

        public async Task<Response<List<JobByCategoryResponse>>> GetJobsByCategory(int categoryId)
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

        public async Task<Response<List<JobByCategoryResponse>>> GetJobsForJobIndex(string query)
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
    }
}
