using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiNegocio.Models
{
    [Table("food")]
    public class Food
    {
        [Column("id")]
        public long Food_id { get; set; }
        [Column("name")]
        public string FoodName { get; set; }
        [Column("qualidade")]
        public string FoodQualidade { get; set; }

    }
}
