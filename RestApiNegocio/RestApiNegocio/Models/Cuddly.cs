using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiNegocio.Models
{
    //Peluches
    [Table("cluddy")]
    public class Cuddly
    {
        [Column("id")]
        public long CuddlyId { get; set; }
        [Column("name")]
        public string CuddlyName { get; set; }
        [Column("especie")]
        public string CuddlyEspcie { get; set; }
    }
}
