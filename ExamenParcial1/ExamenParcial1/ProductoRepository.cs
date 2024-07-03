using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ExamenParcial1;

namespace ExamenParcial1
{
    public class ProductoRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Add(Producto producto)
        {
            var sql = "INSERT INTO Producto (Descripcion, Cantidad_minima, Cantidad_stock, Precio_compra, Precio_venta, Categoria, Marca, Estado) VALUES (@Descripcion, @Cantidad_minima, @Cantidad_stock, @Precio_compra, @Precio_venta, @Categoria, @Marca, @Estado)";
            _dbConnection.Execute(sql, producto);
        }

        public void Update(Producto producto)
        {
            var sql = "UPDATE Producto SET Descripcion = @Descripcion, Cantidad_minima = @Cantidad_minima, Cantidad_stock = @Cantidad_stock, Precio_compra = @Precio_compra, Precio_venta = @Precio_venta, Categoria = @Categoria, Marca = @Marca, Estado = @Estado WHERE Id = @Id";
            _dbConnection.Execute(sql, producto);
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM Producto WHERE Id = @Id";
            _dbConnection.Execute(sql, new { Id = id });
        }

        public Producto Get(int id)
        {
            var sql = "SELECT * FROM Producto WHERE Id = @Id";
            return _dbConnection.Query<Producto>(sql, new { Id = id }).FirstOrDefault();
        }

        public IEnumerable<Producto> List()
        {
            var sql = "SELECT * FROM Producto";
            return _dbConnection.Query<Producto>(sql).ToList();
        }
    }
}