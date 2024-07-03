using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using ExamenParcial1;

namespace ExamenParcial1
{
    public class ClienteRepository
    {
        private readonly ConexionBD conexion;
        public ClienteRepository(ConexionBD conexion)
        {
            this.conexion = conexion;
        }

        public void CrearCliente(Cliente cliente)
        {
            using var conn = conexion.Conectar();
            conn.Open();
        }

        public Cliente ObtenerClientePorId(int id)
        {
            using var conn = conexion.Conectar();
            conn.Open();
            return null;
        }
    }
}
