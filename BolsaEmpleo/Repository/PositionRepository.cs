using BolsaEmpleo.DTO;
using BolsaEmpleo.DTO.Comun;
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
    public class PositionRepository : IPositionRepository
    {
        private readonly BolsaEmpleoContext _db;

        public PositionRepository(BolsaEmpleoContext db)
        {
            _db = db;
        }
      
    
    public async Task<Response<List<GetPositionsByCategoryResponse>>> GetPositions(int categoryId)
        {
            var response = new Response<List<GetPositionsByCategoryResponse>>();

            try
            {
                var positions = await _db.GetPositionsByCategoryResponse.FromSqlRaw<GetPositionsByCategoryResponse>("getPositionByCategoryId @categoryId",
               new SqlParameter("@categoryId", categoryId)).ToListAsync();

                response.Data = positions;

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
