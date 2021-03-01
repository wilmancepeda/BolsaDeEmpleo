using BolsaEmpleo.DTO.Comun;
using BolsaEmpleo.DTO.Configuration;
using BolsaEmpleo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaEmpleo.IRepository
{
    public interface IConfigurationRepository
    {
        public Task<Response<List<Configuration>>> GetConfigurations();
        public Task<Response<Configuration>> GetConfiguration(byte id);
        public Task<Response<bool>> EditConfiguration(ConfigurationEditRequest request);
    }
}
