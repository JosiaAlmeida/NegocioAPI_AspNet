using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiNegocio.Models
{
    public class Book
    {
        public long BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookAutor { get; set; }
    }
}
