using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using ExamenParcial1;

namespace ExamenParcial1
{
    public class DetalleFacturaRepository
    {
        private readonly IDbConnection _dbConnection;

        public DetalleFacturaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Add(DetalleFactura detalleFactura)
        {
            var sql = "INSERT INTO DetalleFactura (Id_Factura, Id_Producto, Cantidad_producto, Subtotal) VALUES (@Id_Factura, @Id_Producto, @Cantidad_producto, @Subtotal)";
            _dbConnection.Execute(sql, detalleFactura);
        }

        public void Update(DetalleFactura detalleFactura)
        {
            var sql = "UPDATE DetalleFactura SET Id_Factura = @Id_Factura, Id_Producto = @Id_Producto, Cantidad_producto = @Cantidad_producto, Subtotal = @Subtotal WHERE Id = @Id";
            _dbConnection.Execute(sql, detalleFactura);
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM DetalleFactura WHERE Id = @Id";
            _dbConnection.Execute(sql, new { Id = id });
        }

        public DetalleFactura Get(int id)
        {
            var sql = "SELECT * FROM DetalleFactura WHERE Id = @Id";
            return _dbConnection.Query<DetalleFactura>(sql, new { Id = id }).FirstOrDefault();
        }

        public IEnumerable<DetalleFactura> List()
        {
            var sql = "SELECT * FROM DetalleFactura";
            return _dbConnection.Query<DetalleFactura>(sql).ToList();
        }
    }
}

