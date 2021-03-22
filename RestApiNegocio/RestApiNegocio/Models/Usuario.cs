using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiNegocio.Models
{
    [Table("user")]
    public class Usuario
    {
        [Column("id")]
        public int id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("role")]
        public string Role { get; set; }
        [Column("password")]
        public string Password { get; set; }
    }
}
