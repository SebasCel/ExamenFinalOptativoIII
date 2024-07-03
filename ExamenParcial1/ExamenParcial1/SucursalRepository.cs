using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ExamenParcial1;

namespace ExamenParcial1
{
    public class SucursalRepository
    {
        private readonly IDbConnection _dbConnection;

        public SucursalRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Add(Sucursal sucursal)
        {
            var sql = "INSERT INTO Sucursal (Descripcion, Direccion, Telefono, Whatsapp, Mail, Estado) VALUES (@Descripcion, @Direccion, @Telefono, @Whatsapp, @Mail, @Estado)";
            _dbConnection.Execute(sql, sucursal);
        }

        public void Update(Sucursal sucursal)
        {
            var sql = "UPDATE Sucursal SET Descripcion = @Descripcion, Direccion = @Direccion, Telefono = @Telefono, Whatsapp = @Whatsapp, Mail = @Mail, Estado = @Estado WHERE Id = @Id";
            _dbConnection.Execute(sql, sucursal);
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM Sucursal WHERE Id = @Id";
            _dbConnection.Execute(sql, new { Id = id });
        }

        public Sucursal Get(int id)
        {
            var sql = "SELECT * FROM Sucursal WHERE Id = @Id";
            return _dbConnection.Query<Sucursal>(sql, new { Id = id }).FirstOrDefault();
        }

        public IEnumerable<Sucursal> List()
        {
            var sql = "SELECT * FROM Sucursal";
            return _dbConnection.Query<Sucursal>(sql).ToList();
        }
    }
}
