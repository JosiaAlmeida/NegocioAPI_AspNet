using RestApiNegocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiNegocio.Repositorio
{
    public interface ICuddly
    {
        public List<Cuddly> AllCuddlys();
        public Cuddly SingleCuddly(int id);
        public Cuddly CreateCuddly(Cuddly Cuddly);
        public Cuddly UpDateCuddly(Cuddly Cuddly);
        public Cuddly DeleteCuddly(int id);

    }
}
