using BolsaEmpleo.DTO;
using BolsaEmpleo.DTO.Comun;
using BolsaEmpleo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaEmpleo.IRepository
{
    public interface IPositionRepository
    {
        public Task<Response<List<GetPositionsByCategoryResponse>>> GetPositions(int categoryId);
    }
}
