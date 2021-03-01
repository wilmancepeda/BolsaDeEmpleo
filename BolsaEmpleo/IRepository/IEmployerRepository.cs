using BolsaEmpleo.DTO;
using BolsaEmpleo.DTO.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaEmpleo.IRepository
{
    public interface IEmployerRepository
    {
        public Task<Response<List<GetEmployerResponse>>> GetEmployers();
    }
}
