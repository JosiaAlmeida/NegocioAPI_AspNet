using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiNegocio.Models
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        public long _id{ get; set; }
        [Column("nome")]
        public string nome { get; set; }
        [Column("password")]
        public string password { get; set; }

    }
}
