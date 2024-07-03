using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data.SqlClient;
using System.Data;

namespace ExamenParcial1
{
    public class ConexionBD
    {
        private readonly string connectionString;
        public ConexionBD(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public NpgsqlConnection Conectar()
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}
