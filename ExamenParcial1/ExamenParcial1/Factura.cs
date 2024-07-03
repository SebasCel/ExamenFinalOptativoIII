using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenParcial1
{
    public class Factura
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int NroFactura { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Total { get; set; }
        public decimal TotalIva5 { get; set; }
        public decimal TotalIva10 { get; set; }
        public decimal TotalIva { get; set; }
        public string TotalLetras { get; set; }
        public string Sucursal { get; set; }
    }
}