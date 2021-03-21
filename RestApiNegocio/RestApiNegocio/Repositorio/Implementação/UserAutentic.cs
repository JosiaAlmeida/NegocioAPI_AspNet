using Microsoft.EntityFrameworkCore;
using RestApiNegocio.Models;
using RestApiNegocio.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiNegocio.Repositorio.Implementação
{
    public class UserAutentic : IUser
    {
        private MysqlContext _context;

        public UserAutentic(MysqlContext context)
        {
            _context = context;
            dataset = _context.Set<User>();
        }

        private DbSet<User> dataset;
        public User newUser(User user)
        {
            try
            {
                dataset.Add(user);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return user;
        }
        public User user(string nome, string password)
        {
            if (nome is null || password is null) return null;
            var user = dataset.SingleOrDefault(b=> b.nome== nome && b.password== password);
            try
            {
                dataset.Find(user);
            }
            catch (Exception)
            {

                throw;
            }
            return user;
        }
    }
}
