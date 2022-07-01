using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Registro
    {
        public int Id { get; set; }
        public int IdTipoVehiculo { get; set; }
        public string Placa { get; set; }
        public DateTime Ingreso { get; set; }
        public DateTime? Salida { get; set; }
        public string Factura { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? ValorDescuento { get; set; }
        public decimal? TotalPagado { get; set; }
    }
}
