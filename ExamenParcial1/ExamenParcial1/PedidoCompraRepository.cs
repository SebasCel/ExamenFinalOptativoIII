using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

public class PedidoCompraRepository
{
    private readonly IDbConnection _dbConnection;

    public PedidoCompraRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public void Add(PedidoCompra pedidoCompra)
    {
        var sql = "INSERT INTO PedidoCompra (Id_Proveedor, Id_sucursal, Fecha_Hora, Total) VALUES (@Id_Proveedor, @Id_sucursal, @Fecha_Hora, @Total)";
        _dbConnection.Execute(sql, pedidoCompra);
    }

    public void Update(PedidoCompra pedidoCompra)
    {
        var sql = "UPDATE PedidoCompra SET Id_Proveedor = @Id_Proveedor, Id_sucursal = @Id_sucursal, Fecha_Hora = @Fecha_Hora, Total = @Total WHERE Id = @Id";
        _dbConnection.Execute(sql, pedidoCompra);
    }

    public void Delete(int id)
    {
        var sql = "DELETE FROM PedidoCompra WHERE Id = @Id";
        _dbConnection.Execute(sql, new { Id = id });
    }

    public PedidoCompra Get(int id)
    {
        var sql = "SELECT * FROM PedidoCompra WHERE Id = @Id";
        return _dbConnection.Query<PedidoCompra>(sql, new { Id = id }).FirstOrDefault();
    }

    public List<PedidoCompra> GetAll()
    {
        var sql = "SELECT * FROM PedidoCompra";
        return _dbConnection.Query<PedidoCompra>(sql).ToList();
    }
}