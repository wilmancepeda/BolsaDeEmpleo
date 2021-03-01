using BolsaEmpleo.DTO.Comun;
using BolsaEmpleo.DTO.Configuration;
using BolsaEmpleo.IRepository;
using BolsaEmpleo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaEmpleo.Repository
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly BolsaEmpleoContext _db;

        public ConfigurationRepository(BolsaEmpleoContext db)
        {
            _db = db;
        }

        public async Task<Response<bool>> EditConfiguration(ConfigurationEditRequest request)
        {

            var response = new Response<bool>();

            try
            {
                var configuration = await _db.Configuration.Where(c => c.IdConfiguration == request.Id).FirstOrDefaultAsync();
                configuration.Value = request.Value.ToString();
                _db.Configuration.Update(configuration);

                if (await _db.SaveChangesAsync() > 0)
                {
                    response.Data = true;
                    response.Ok = true;
                    return response;
                }
                response.Data = false;

                response.Ok = false;
                response.Mensaje = "No se pudo actualizar. Por favor, inténte nuevamente";

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

        public async Task<Response<Configuration>> GetConfiguration(byte id)
        {
            var response = new Response<Configuration>();

            try
            {
                response.Data = await _db.Configuration.Where(c => c.IdConfiguration == id).FirstOrDefaultAsync();

                if (response.Data == null)
                {
                    response.Mensaje = "No se pudo encontrar la configuración. Por favor, inténte nuevamente";
                    
                }
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

        public async Task<Response<List<Configuration>>> GetConfigurations()
        {
            var response = new Response<List<Configuration>>();

            try
            {
                response.Data = await _db.Configuration.ToListAsync();

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
