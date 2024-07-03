using ExamenParcial1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenParcialNegocios
{
    public class ProductoService
    {
        public bool ValidarProducto(Producto producto)
        {
            if (string.IsNullOrEmpty(producto.Descripcion) || string.IsNullOrEmpty(producto.Categoria) ||
                string.IsNullOrEmpty(producto.Marca) || producto.Cantidad_minima < 1 ||
                producto.Cantidad_stock < 0 || producto.Precio_compra <= 0 || producto.Precio_venta <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
