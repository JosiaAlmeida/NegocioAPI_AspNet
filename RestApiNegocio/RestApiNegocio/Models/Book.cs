using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiNegocio.Models
{
    [Table("book")]
    public class Book
    {
        [Column("id")]
        public long BookId { get; set; }
        [Column("title")]
        public string BookTitle { get; set; }
        [Column("Autor")]
        public string BookAutor { get; set; }
        [Column("Descicao")]
        public string BookDescricao { get; set; }
    }
}
