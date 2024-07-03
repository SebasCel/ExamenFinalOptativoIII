using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExamenParcial1
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad_minima { get; set; }
        public int Cantidad_stock { get; set; }
        public decimal Precio_compra { get; set; }
        public decimal Precio_venta { get; set; }
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public string Estado { get; set; }
    }
}
