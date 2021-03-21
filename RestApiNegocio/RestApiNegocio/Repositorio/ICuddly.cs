using RestApiNegocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiNegocio.Repositorio
{
    public interface ICuddly
    {
        public List<Cuddly> All();
        public Cuddly Single(int id);
        public Cuddly Create(Cuddly Cuddly);
        public Cuddly UpDate(Cuddly Cuddly);
        public Cuddly Delete(int id);

    }
}
