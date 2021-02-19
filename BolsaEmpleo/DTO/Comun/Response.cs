using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaEmpleo.DTO.Comun
{
    public class Response<T>
    {
        public string Mensaje { get; set; }
        public bool Ok { get; set; }
        public T Data { get; set; }
    }
}
