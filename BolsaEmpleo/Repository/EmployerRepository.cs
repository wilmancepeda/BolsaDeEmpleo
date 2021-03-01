using BolsaEmpleo.DTO;
using BolsaEmpleo.DTO.Comun;
using BolsaEmpleo.IRepository;
using BolsaEmpleo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaEmpleo.Repository
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly BolsaEmpleoContext _db;
        public EmployerRepository(BolsaEmpleoContext db)
        {
            _db = db;
        }
        public async Task<Response<List<GetEmployerResponse>>> GetEmployers()
        {
            var response = new Response<List<GetEmployerResponse>>();

            try
            {
                response.Data = await _db.Employer.Select(e => new GetEmployerResponse() {  IdEmployer = e.IdEmployer, EmployerName = e.EmployerName }).ToListAsync();

                response.Ok = true;

                return response;
            }
            catch (Exception e)
            {
                response.Ok = false;
                //response.Mensaje = "Ops! Algo inesperado ha ocurrido. Favor inténtelo más tarde";
                response.Mensaje = e.Message;
                return response;
            }
        }
    }

}
