using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiNegocio.Models
{
    public class Shoe
    {
        public long ShoeId { get; set; }
        public string ShoeName { get; set; }
        public long ShoeSize { get; set; }
        public string ShoeType { get; set; }
        public string ShoeMarca { get; set; }
    }
}
