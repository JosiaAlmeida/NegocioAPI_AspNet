using RestApiNegocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiNegocio.Repositorio
{
    public interface IUser
    {
        public Usuario UserLast(Usuario user);
        public Usuario Newuser(Usuario user);
    }
}
