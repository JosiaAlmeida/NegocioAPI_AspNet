using RestApiNegocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiNegocio.Repositorio
{
    public interface IUser
    {
        public User user(string nome, string password);
        public User newUser(User user);
    }
}
