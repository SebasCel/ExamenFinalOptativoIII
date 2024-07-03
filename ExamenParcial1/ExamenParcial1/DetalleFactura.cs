using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenParcial1
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int Id_Factura { get; set; }
        public int Id_Producto { get; set; }
        public int Cantidad_producto { get; set; }
        public decimal Subtotal { get; set; }
    }
}

