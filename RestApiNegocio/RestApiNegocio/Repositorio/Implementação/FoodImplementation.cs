using Microsoft.EntityFrameworkCore;
using RestApiNegocio.Models;
using RestApiNegocio.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiNegocio.Repositorio.Implementação
{
    public class FoodImplementation : IFood
    {
        private MysqlContext _context;
        private DbSet<Food> _dataset;

        public FoodImplementation(MysqlContext Food)
        {
            this._context = Food;
            _dataset = _context.Set<Food>();
        }

        public List<Food> AllFoods()
        {
            return _dataset.ToList();
        }

        public Food SingleFood(int id)
        {
            if (id == null) return null;
            return _dataset.SingleOrDefault(b => b.Food_id.Equals(id));
        }
        public Food CreateFood(Food Food)
        {
            try
            {
                _dataset.Add(Food);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Food;
        }

        public Food UpDateFood(Food Food)
        {
            if (Food.Food_id == null) return null;
            try
            {
                _dataset.Update(Food);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return Food;
        }
        public Food DeleteFood(int id)
        {
            if (id == null) return null;
            var delete = _dataset.SingleOrDefault(b => b.Food_id.Equals(id));
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
