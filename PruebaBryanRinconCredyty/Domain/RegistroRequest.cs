using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RegistroRequest
    {
        public int IdTipoVehiculo { get; set; }
        public string Placa { get; set; }
        public DateTime Ingreso { get; set; }
        public Nullable<System.DateTime> Salida { get; set; }
        public string? Factura { get; set; }
    }
}
