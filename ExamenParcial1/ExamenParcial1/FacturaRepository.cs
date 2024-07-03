using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ExamenParcial1
{
    public class FacturaRepository
    {
        private readonly ConexionBD conexion;

        public FacturaRepository(ConexionBD conexion)
        {
            this.conexion = conexion;
        }

        public void CrearFactura(Factura factura)
        {
            using var conn = conexion.Conectar();
            conn.Open();
        }
        public Factura ObtenerFacturaPorId(int id)
        {
            using var conn = conexion.Conectar();
            conn.Open();
            return null;
        }
    }
}
