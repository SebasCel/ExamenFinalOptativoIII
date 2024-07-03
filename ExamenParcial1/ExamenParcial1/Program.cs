using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var conexion = new ConexionDB();
        var dbConnection = conexion.CrearConexion();

        // Prueba con Proveedor
        var proveedorRepository = new ProveedorRepository(dbConnection);
        var proveedorService = new ProveedorService();

        var nuevoProveedor = new Proveedor
        {
            RazonSocial = "Proveedor SA",
            TipoDocumento = "RUC",
            NumeroDocumento = "1234567890",
            Direccion = "Av. Principal 123",
            Mail = "proveedor@empresa.com",
            Celular = "0987654321",
            Estado = "Activo"
        };

        if (proveedorService.ValidarProveedor(nuevoProveedor))
        {
            proveedorRepository.Add(nuevoProveedor);
            Console.WriteLine("Proveedor agregado correctamente.");
        }
        else
        {
            Console.WriteLine("Proveedor no válido.");
        }

        var pedidoCompraRepository = new PedidoCompraRepository(dbConnection);
        var detallePedidoRepository = new DetallePedidoRepository(dbConnection);
        var pedidoCompraService = new PedidoCompraService(pedidoCompraRepository, detallePedidoRepository);

        var nuevoPedidoCompra = new PedidoCompra
        {
            Id_Proveedor = 1,
            Id_sucursal = 1,
            Fecha_Hora = DateTime.Now,
            Total = 0
        };

        pedidoCompraRepository.Add(nuevoPedidoCompra);
        Console.WriteLine("Pedido de Compra agregado correctamente.");

        var nuevoDetallePedido = new DetallePedido
        {
            Id_pedido = nuevoPedidoCompra.Id,
            Id_Producto = 1,
            Cantidad_producto = 10,
            Subtotal = 100
        };

        detallePedidoRepository.Add(nuevoDetallePedido);
        Console.WriteLine("Detalle de Pedido agregado correctamente.");

        if (pedidoCompraService.ValidarPedido(nuevoPedidoCompra))
        {
            pedidoCompraRepository.Update(nuevoPedidoCompra);
            Console.WriteLine("Pedido de Compra validado y actualizado correctamente.");
        }
        else
        {
            Console.WriteLine("Pedido de Compra no valido.");
        }

        var detalles = pedidoCompraService.ListarDetalles(nuevoPedidoCompra.Id);
        Console.WriteLine("Detalles del Pedido:");
        foreach (var detalle in detalles)
        {
            Console.WriteLine($"Producto ID: {detalle.Id_Producto}, Cantidad: {detalle.Cantidad_producto}, Subtotal: {detalle.Subtotal}");
        }


        var sucursalRepository = new SucursalRepository(dbConnection);
        var sucursalService = new SucursalService();

        var nuevaSucursal = new Sucursal
        {
            Descripcion = "Sucursal Central",
            Direccion = "Calle Principal 456",
            Telefono = "123456789",
            Whatsapp = "987654321",
            Mail = "sucursal@empresa.com",
            Estado = "Activo"
        };

        if (sucursalService.ValidarSucursal(nuevaSucursal))
        {
            sucursalRepository.Add(nuevaSucursal);
            Console.WriteLine("Sucursal agregada correctamente.");
        }
        else
        {
            Console.WriteLine("Sucursal no valida.");
        }

        var productoRepository = new ProductoRepository(dbConnection);
        var productoService = new ProductoService();

        var nuevoProducto = new Producto
        {
            Descripcion = "Producto A",
            Cantidad_minima = 5,
            Cantidad_stock = 50,
            Precio_compra = 10,
            Precio_venta = 15,
            Categoria = "Categoría 1",
            Marca = "Marca 1",
            Estado = "Activo"
        };

        if (productoService.ValidarProducto(nuevoProducto))
        {
            productoRepository.Add(nuevoProducto);
            Console.WriteLine("Producto agregado correctamente.");
        }
        else
        {
            Console.WriteLine("Producto no valido.");
        }
    }
}
