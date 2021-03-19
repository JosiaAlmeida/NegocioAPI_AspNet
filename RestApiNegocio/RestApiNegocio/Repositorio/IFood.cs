using RestApiNegocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiNegocio.Repositorio
{
    public interface IFood
    {
        public List<Food> AllFoods();
        public Food SingleFood(int id);
        public Food CreateFood(Food Food);
        public Food UpDateFood(Food Food);
        public Food DeleteFood(int id);

    }
}
