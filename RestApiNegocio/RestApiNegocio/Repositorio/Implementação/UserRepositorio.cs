using RestApiNegocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiNegocio.Repositorio.Implementação
{
    public static class UserRepositorio
    {
        public static Usuario get(string nome, string password)
        {
            var users = new List<Usuario>();
            users.Add(new Usuario { id = 1, Nome = "Josias", Password = "josias", Role="manager" });
            users.Add(new Usuario { id = 2, Nome = "Almeida", Password = "Almeida", Role="empoloyee" });
            return users.Where(x => x.Nome.ToLower() == nome.ToLower() && x.Password == x.Password).First();
        } 
    }
}
