using Microsoft.EntityFrameworkCore;
using RestApiNegocio.Models;
using RestApiNegocio.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestApiNegocio.Repositorio.Implementação
{
    public class UserRepositorio: IUser
    {
        private readonly MysqlContext _context;
        private DbSet<Usuario> usuarios;

        public UserRepositorio(MysqlContext context)
        {
            _context = context;
            usuarios = _context.Set<Usuario>();
        }

        public Usuario get(string nome, string password)
        {
            var users = new List<Usuario>();
            users.Add(new Usuario { id = 1, Nome = "Josias", Password = "josias", Role="manager" });
            users.Add(new Usuario { id = 2, Nome = "Almeida", Password = "Almeida", Role="empoloyee" });
            return users.Where(x => x.Nome.ToLower() == nome.ToLower() && x.Password == x.Password).First();
        }

        public Usuario Newuser(Usuario user)
        {
            try
            {
                usuarios.Add(user);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return user;
        }


        public Usuario UserLast(Usuario user)
        {
            
            var result = usuarios.FirstOrDefault(x => x.Nome == user.Nome && x.Password == user.Password);
            try
            {
                _context.Entry(result);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
