using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiNegocio.Models
{
    //Peluches
    public class Cuddly
    {
        public long CuddlyId { get; set; }
        public string CuddlyName { get; set; }
        public string CuddlyEspcie { get; set; }
    }
}
