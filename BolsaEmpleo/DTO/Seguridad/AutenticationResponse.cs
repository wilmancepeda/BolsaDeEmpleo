using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaEmpleo.DTO.Seguridad
{
    public class AutenticationResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
