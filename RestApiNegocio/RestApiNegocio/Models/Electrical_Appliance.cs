using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiNegocio.Models
{
    public class Electrical_Appliance
    {
        public long Electrical_id { get; set; }
        public string ElectricalName { get; set; }
        public string ElectricalMarca { get; set; }
        public string ElectricalTipo { get; set; }

    }
}
