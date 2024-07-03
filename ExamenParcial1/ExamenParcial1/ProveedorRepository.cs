using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

public class ProveedorRepository
{
    private readonly IDbConnection _dbConnection;

    public ProveedorRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public void Add(Proveedor proveedor)
    {
        var sql = "INSERT INTO Proveedor (RazonSocial, TipoDocumento, NumeroDocumento, Direccion, Mail, Celular, Estado) VALUES (@RazonSocial, @TipoDocumento, @NumeroDocumento, @Direccion, @Mail, @Celular, @Estado)";
        _dbConnection.Execute(sql, proveedor);
    }

    public void Update(Proveedor proveedor)
    {
        var sql = "UPDATE Proveedor SET RazonSocial = @RazonSocial, TipoDocumento = @TipoDocumento, NumeroDocumento = @NumeroDocumento, Direccion = @Direccion, Mail = @Mail, Celular = @Celular, Estado = @Estado WHERE Id = @Id";
        _dbConnection.Execute(sql, proveedor);
    }

    public void Delete(int id)
    {
        var sql = "DELETE FROM Proveedor WHERE Id = @Id";
        _dbConnection.Execute(sql, new { Id = id });
    }

    public Proveedor Get(int id)
    {
        var sql = "SELECT * FROM Proveedor WHERE Id = @Id";
        return _dbConnection.Query<Proveedor>(sql, new { Id = id }).FirstOrDefault();
    }

    public List<Proveedor> GetAll()
    {
        var sql = "SELECT * FROM Proveedor";
        return _dbConnection.Query<Proveedor>(sql).ToList();
    }
}