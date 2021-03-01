using BolsaEmpleo.DTO.Comun;
using BolsaEmpleo.DTO.User;
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
    public class UserRepository : IUserRepository
    {
        private readonly BolsaEmpleoContext _db;

        public UserRepository(BolsaEmpleoContext db)
        {
            _db = db;
        }

        public async Task<Response<CreateUserRequest>> CreateUser(CreateUserRequest request)
        {
            var response = new Response<CreateUserRequest>();

            try
            {
                using (_db)
                {
                    int result = await _db.Database.ExecuteSqlRawAsync("createUser @userTypeId, @Name, @LastName, @userLogin, @password, @createdBy",
                                    new SqlParameter("@userTypeId", request.Role),
                                    new SqlParameter("@Name", request.Name),
                                    new SqlParameter("@LastName", request.Name),
                                    new SqlParameter("@userLogin", request.Email),
                                    new SqlParameter("@password", request.Password),
                                    new SqlParameter("@createdBy", request.Email)

                                    );

                    if (result > 0)
                    {
                        response.Data = request;
                        response.Ok = true;
                        response.Mensaje = "Registrado correctamente";

                        return response;

                    }
                }

                response.Ok = false;
                response.Mensaje = "No se pudo registrar. Por favor, verifique e inténte nuevamente";
                return response;


            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;
                response.Ok = false;

                return response;
            }
        }

        public async Task<Response<UserReponse>> GetUser(string UserLogin)
        {
            var response = new Response<UserReponse>();

            try
            {
                var user = await _db.UserReponse.FromSqlRaw<UserReponse>("getUserByUserLogin @userLogin",
                new SqlParameter("@userLogin", UserLogin)).ToListAsync();

                response.Data = user.FirstOrDefault();

                if (response.Data == null)
                {
                    response.Mensaje = "No se encontró el puesto de trabajo. Por favor, verifique inténte nuevamente";
                }
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
