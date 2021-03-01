using BolsaEmpleo.DTO.Comun;
using BolsaEmpleo.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaEmpleo.IRepository
{
    public interface IUserRepository
    {
        public Task<Response<UserReponse>> GetUser(string UserLogin);
        public Task<Response<CreateUserRequest>> CreateUser(CreateUserRequest request);
    }
}
