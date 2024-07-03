using ExamenParcial1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenParcialNegocios
{
    public class DetalleFacturaService
    {
        public bool ValidarDetalleFactura(DetalleFactura detalleFactura)
        {
            if (detalleFactura.Cantidad_producto <= 0 || detalleFactura.Subtotal < 0)
            {
                return false;
            }
            return true;
        }
    }
}

