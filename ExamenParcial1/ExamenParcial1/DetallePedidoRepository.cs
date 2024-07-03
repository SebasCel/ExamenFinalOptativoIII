using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

public class DetallePedidoRepository
{
	private readonly IDbConnection _dbConnection;

	public DetallePedidoRepository(IDbConnection dbConnection)
	{
		_dbConnection = dbConnection;
	}

	public void Add(DetallePedido detallePedido)
	{
		var sql = "INSERT INTO DetallePedido (Id_pedido, Id_Producto, Cantidad_producto, Subtotal) VALUES (@Id_pedido, @Id_Producto, @Cantidad_producto, @Subtotal)";
		_dbConnection.Execute(sql, detallePedido);
	}

	public void Update(DetallePedido detallePedido)
	{
		var sql = "UPDATE DetallePedido SET Id_pedido = @Id_pedido, Id_Producto = @Id_Producto, Cantidad_producto = @Cantidad_producto, Subtotal = @Subtotal WHERE Id = @Id";
		_dbConnection.Execute(sql, detallePedido);
	}

	public void Delete(int id)
	{
		var sql = "DELETE FROM DetallePedido WHERE Id = @Id";
		_dbConnection.Execute(sql, new { Id = id });
	}

	public DetallePedido Get(int id)
	{
		var sql = "SELECT * FROM DetallePedido WHERE Id = @Id";
		return _dbConnection.Query<DetallePedido>(sql, new { Id = id }).FirstOrDefault();
	}

	public List<DetallePedido> GetAll()
	{
		var sql = "SELECT * FROM DetallePedido";
		return _dbConnection.Query<DetallePedido>(sql).ToList();
	}
}