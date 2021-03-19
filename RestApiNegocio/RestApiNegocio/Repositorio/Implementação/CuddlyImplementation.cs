using Microsoft.EntityFrameworkCore;
using RestApiNegocio.Models;
using RestApiNegocio.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiNegocio.Repositorio.Implementação
{
    public class CuddlyImplementation : ICuddly
    {
        private MysqlContext _context;
        private DbSet<Cuddly> _dataset;

        public CuddlyImplementation(MysqlContext Cuddly)
        {
            this._context = Cuddly;
            _dataset = _context.Set<Cuddly>();
        }

        public List<Cuddly> AllCuddlys()
        {
            return _dataset.ToList();
        }

        public Cuddly SingleCuddly(int id)
        {
            if (id == null) return null;
            return _dataset.SingleOrDefault(b => b.CuddlyId.Equals(id));
        }
        public Cuddly CreateCuddly(Cuddly Cuddly)
        {
            try
            {
                _dataset.Add(Cuddly);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Cuddly;
        }

        public Cuddly UpDateCuddly(Cuddly Cuddly)
        {
            if (Cuddly.CuddlyId == null) return null;
            try
            {
                _dataset.Update(Cuddly);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return Cuddly;
        }
        public Cuddly DeleteCuddly(int id)
        {
            if (id == null) return null;
            var delete = _dataset.SingleOrDefault(b => b.CuddlyId.Equals(id));
            try
            {
                _dataset.Remove(delete);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return delete;
        }

    }
}
