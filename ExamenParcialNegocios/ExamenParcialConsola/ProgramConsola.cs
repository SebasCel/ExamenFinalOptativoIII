using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using ExamenParcial1;


namespace ExamenParcialConsola
{
    class ProgramConsola
    {
        static ClienteService clienteService = new ClienteService();
        static FacturaService facturaService = new FacturaService();
        static SucursalService sucursalService = new SucursalService();
        static ProductoService productoService = new ProductoService();
        static DetalleFacturaService detalleFacturaService = new DetalleFacturaService();

        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                var clienteRepository = new ClienteRepository(dbConnection);
                var facturaRepository = new FacturaRepository(dbConnection);
                var sucursalRepository = new SucursalRepository(dbConnection);
                var productoRepository = new ProductoRepository(dbConnection);
                var detalleFacturaRepository = new DetalleFacturaRepository(dbConnection);

                while (true)
                {
                    MostrarMenu();
                    int opcion = LeerOpcion();

                    switch (opcion)
                    {
                        case 1:
                            CrearCliente(clienteRepository);
                            break;
                        case 2:
                            LeerCliente(clienteRepository);
                            break;
                        case 3:
                            ActualizarCliente(clienteRepository);
                            break;
                        case 4:
                            EliminarCliente(clienteRepository);
                            break;
                        case 5:
                            CrearFactura(facturaRepository);
                            break;
                        case 6:
                            LeerFactura(facturaRepository);
                            break;
                        case 7:
                            ActualizarFactura(facturaRepository);
                            break;
                        case 8:
                            EliminarFactura(facturaRepository);
                            break;
                        case 9:
                            CrearSucursal(sucursalRepository);
                            break;
                        case 10:
                            LeerSucursal(sucursalRepository);
                            break;
                        case 11:
                            ActualizarSucursal(sucursalRepository);
                            break;
                        case 12:
                            EliminarSucursal(sucursalRepository);
                            break;
                        case 13:
                            CrearProducto(productoRepository);
                            break;
                        case 14:
                            LeerProducto(productoRepository);
                            break;
                        case 15:
                            ActualizarProducto(productoRepository);
                            break;
                        case 16:
                            EliminarProducto(productoRepository);
                            break;
                        case 17:
                            CrearDetalleFactura(detalleFacturaRepository);
                            break;
                        case 18:
                            LeerDetalleFactura(detalleFacturaRepository);
                            break;
                        case 19:
                            ActualizarDetalleFactura(detalleFacturaRepository);
                            break;
                        case 20:
                            EliminarDetalleFactura(detalleFacturaRepository);
                            break;
                        case 21:
                            return;
                        default:
                            Console.WriteLine("Opcion no válida. Elija una opcion correcta.");
                            break;
                    }
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("------- Menu: ------- ");
            Console.WriteLine("1. Crear Cliente");
            Console.WriteLine("2. Leer Cliente");
            Console.WriteLine("3. Actualizar Cliente");
            Console.WriteLine("4. Eliminar Cliente");
            Console.WriteLine("5. Crear Factura");
            Console.WriteLine("6. Leer Factura");
            Console.WriteLine("7. Actualizar Factura");
            Console.WriteLine("8. Eliminar Factura");
            Console.WriteLine("9. Crear Sucursal");
            Console.WriteLine("10. Leer Sucursal");
            Console.WriteLine("11. Actualizar Sucursal");
            Console.WriteLine("12. Eliminar Sucursal");
            Console.WriteLine("13. Crear Producto");
            Console.WriteLine("14. Leer Producto");
            Console.WriteLine("15. Actualizar Producto");
            Console.WriteLine("16. Eliminar Producto");
            Console.WriteLine("17. Crear Detalle Factura");
            Console.WriteLine("18. Leer Detalle Factura");
            Console.WriteLine("19. Actualizar Detalle Factura");
            Console.WriteLine("20. Eliminar Detalle Factura");
            Console.WriteLine("21. Salir");
        }

        static int LeerOpcion()
        {
            Console.Write("Seleccione una opcion: ");
            return int.Parse(Console.ReadLine());
        }


        static void CrearCliente(ClienteRepository clienteRepository)
        {
            Console.WriteLine("Ingrese los datos del cliente: ");
            Cliente nuevoCliente = ObtenerDatosClienteDesdeConsola();
            if (clienteService.ValidarCliente(nuevoCliente))
            {
                clienteRepository.Add(nuevoCliente);
                Console.WriteLine("Cliente creado exitosamente.");
            }
            else
            {
                Console.WriteLine("Error en la validacion del cliente.");
            }
        }

        static void LeerCliente(ClienteRepository clienteRepository)
        {
            Console.WriteLine("Ingrese el ID del cliente a consultar: ");
            int id = int.Parse(Console.ReadLine());
            Cliente cliente = clienteRepository.Get(id);
            if (cliente != null)
            {
                Console.WriteLine("Cliente encontrado: ");
                Console.WriteLine(cliente);
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        static void ActualizarCliente(ClienteRepository clienteRepository)
        {
            Console.WriteLine("Ingrese el ID del cliente a actualizar: ");
            int id = int.Parse(Console.ReadLine());
            Cliente cliente = clienteRepository.Get(id);
            if (cliente != null)
            {
                Console.WriteLine("Ingrese los nuevos datos del cliente: ");
                Cliente nuevosDatosCliente = ObtenerDatosClienteDesdeConsola();
                nuevosDatosCliente.Id = id;
                if (clienteService.ValidarCliente(nuevosDatosCliente))
                {
                    clienteRepository.Update(nuevosDatosCliente);
                    Console.WriteLine("Cliente actualizado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Error en la validación del cliente.");
                }
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        static void EliminarCliente(ClienteRepository clienteRepository)
        {
            Console.WriteLine("Ingrese el ID del cliente a eliminar: ");
            int id = int.Parse(Console.ReadLine());
            clienteRepository.Delete(id);
            Console.WriteLine("Cliente eliminado.");
        }

        static Cliente ObtenerDatosClienteDesdeConsola()
        {
            Cliente cliente = new Cliente();
            Console.Write("Nombre: ");
            cliente.Nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            cliente.Apellido = Console.ReadLine();
            Console.Write("Documento: ");
            cliente.Documento = Console.ReadLine();
            Console.Write("Dirección: ");
            cliente.Direccion = Console.ReadLine();
            Console.Write("Mail: ");
            cliente.Mail = Console.ReadLine();
            Console.Write("Celular: ");
            cliente.Celular = Console.ReadLine();
            Console.Write("Estado: ");
            cliente.Estado = Console.ReadLine();
            return cliente;
        }

        static void CrearFactura(FacturaRepository facturaRepository)
        {
            Console.WriteLine("Ingrese los datos de la factura: ");
            Factura nuevaFactura = ObtenerDatosFacturaDesdeConsola();
            if (facturaService.ValidarFactura(nuevaFactura))
            {
                facturaRepository.Add(nuevaFactura);
                Console.WriteLine("Factura creada exitosamente.");
            }
            else
            {
                Console.WriteLine("Error en la validación de la factura.");
            }
        }

        static void LeerFactura(FacturaRepository facturaRepository)
        {
            Console.WriteLine("Ingrese el ID de la factura: ");
            int id = int.Parse(Console.ReadLine());
            Factura factura = facturaRepository.Get(id);
            if (factura != null)
            {
                Console.WriteLine("Factura encontrada: ");
                Console.WriteLine(factura);
            }
            else
            {
                Console.WriteLine("Factura no encontrada.");
            }
        }

        static void ActualizarFactura(FacturaRepository facturaRepository)
        {
            Console.WriteLine("Ingrese el ID de la factura a actualizar: ");
            int id = int.Parse(Console.ReadLine());
            Factura factura = facturaRepository.Get(id);
            if (factura != null)
            {
                Console.WriteLine("Ingrese los nuevos datos de la factura: ");
                Factura nuevosDatosFactura = ObtenerDatosFacturaDesdeConsola();
                nuevosDatosFactura.Id = id;
                if (facturaService.ValidarFactura(nuevosDatosFactura))
                {
                    facturaRepository.Update(nuevosDatosFactura);
                    Console.WriteLine("Factura actualizada exitosamente.");
                }
                else
                {
                    Console.WriteLine("Error en la validacion de la factura.");
                }
            }
            else
            {
                Console.WriteLine("Factura no encontrada.");
            }
        }

        static void EliminarFactura(FacturaRepository facturaRepository)
        {
            Console.WriteLine("Ingrese el ID de la factura a eliminar: ");
            int id = int.Parse(Console.ReadLine());
            facturaRepository.Delete(id);
            Console.WriteLine("Factura eliminada.");
        }

        static Factura ObtenerDatosFacturaDesdeConsola()
        {
            Factura factura = new Factura();
            Console.Write("ID Cliente: ");
            factura.Id_cliente = int.Parse(Console.ReadLine());
            Console.Write("ID Sucursal: ");
            factura.Id_sucursal = int.Parse(Console.ReadLine());
            Console.Write("Nro. Factura: ");
            factura.Nro_Factura = Console.ReadLine();
            Console.Write("Fecha y Hora: ");
            factura.Fecha_Hora = DateTime.Parse(Console.ReadLine());
            Console.Write("Total: ");
            factura.Total = decimal.Parse(Console.ReadLine());
            Console.Write("Total IVA 5: ");
            factura.Total_iva5 = decimal.Parse(Console.ReadLine());
            Console.Write("Total IVA 10: ");
            factura.Total_iva10 = decimal.Parse(Console.ReadLine());
            Console.Write("Total IVA: ");
            factura.Total_iva = decimal.Parse(Console.ReadLine());
            Console.Write("Total en Letras: ");
            factura.Total_letras = Console.ReadLine();
            return factura;
        }


        static void CrearSucursal(SucursalRepository sucursalRepository)
        {
            Console.WriteLine("Ingrese los datos de la sucursal: ");
            Sucursal nuevaSucursal = ObtenerDatosSucursalDesdeConsola();
            if (sucursalService.ValidarSucursal(nuevaSucursal))
            {
                sucursalRepository.Add(nuevaSucursal);
                Console.WriteLine("Sucursal creada exitosamente.");
            }
            else
            {
                Console.WriteLine("Error en la validación de la sucursal.");
            }
        }

        static void LeerSucursal(SucursalRepository sucursalRepository)
        {
            Console.WriteLine("Ingrese el ID de la sucursal: ");
            int id = int.Parse(Console.ReadLine());
            Sucursal sucursal = sucursalRepository.Get(id);
            if (sucursal != null)
            {
                Console.WriteLine("Sucursal encontrada: ");
                Console.WriteLine(sucursal);
            }
            else
            {
                Console.WriteLine("Sucursal no encontrada.");
            }
        }

        static void ActualizarSucursal(SucursalRepository sucursalRepository)
        {
            Console.WriteLine("Ingrese el ID de la sucursal a actualizar: ");
            int id = int.Parse(Console.ReadLine());
            Sucursal sucursal = sucursalRepository.Get(id);
            if (sucursal != null)
            {
                Console.WriteLine("Ingrese los nuevos datos de la sucursal: ");
                Sucursal nuevosDatosSucursal = ObtenerDatosSucursalDesdeConsola();
                nuevosDatosSucursal.Id = id;
                if (sucursalService.ValidarSucursal(nuevosDatosSucursal))
                {
                    sucursalRepository.Update(nuevosDatosSucursal);
                    Console.WriteLine("Sucursal actualizada exitosamente.");
                }
                else
                {
                    Console.WriteLine("Error en la validación de la sucursal.");
                }
            }
            else
            {
                Console.WriteLine("Sucursal no encontrada.");
            }
        }

        static void EliminarSucursal(SucursalRepository sucursalRepository)
        {
            Console.WriteLine("Ingrese el ID de la sucursal a eliminar: ");
            int id = int.Parse(Console.ReadLine());
            sucursalRepository.Delete(id);
            Console.WriteLine("Sucursal eliminada.");
        }

        static Sucursal ObtenerDatosSucursalDesdeConsola()
        {
            Sucursal sucursal = new Sucursal();
            Console.Write("Descripción: ");
            sucursal.Descripcion = Console.ReadLine();
            Console.Write("Dirección: ");
            sucursal.Direccion = Console.ReadLine();
            Console.Write("Teléfono: ");
            sucursal.Telefono = Console.ReadLine();
            Console.Write("Whatsapp: ");
            sucursal.Whatsapp = Console.ReadLine();
            Console.Write("Mail: ");
            sucursal.Mail = Console.ReadLine();
            Console.Write("Estado: ");
            sucursal.Estado = Console.ReadLine();
            return sucursal;
        }

        static void CrearProducto(ProductoRepository productoRepository)
        {
            Console.WriteLine("Ingrese los datos del producto: ");
            Producto nuevoProducto = ObtenerDatosProductoDesdeConsola();
            if (productoService.ValidarProducto(nuevoProducto))
            {
                productoRepository.Add(nuevoProducto);
                Console.WriteLine("Producto creado exitosamente.");
            }
            else
            {
                Console.WriteLine("Error en la validación del producto.");
            }
        }

        static void LeerProducto(ProductoRepository productoRepository)
        {
            Console.WriteLine("Ingrese el ID del producto a consultar: ");
            int id = int.Parse(Console.ReadLine());
            Producto producto = productoRepository.Get(id);
            if (producto != null)
            {
                Console.WriteLine("Producto encontrado: ");
                Console.WriteLine(producto);
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        static void ActualizarProducto(ProductoRepository productoRepository)
        {
            Console.WriteLine("Ingrese el ID del producto a actualizar: ");
            int id = int.Parse(Console.ReadLine());
            Producto producto = productoRepository.Get(id);
            if (producto != null)
            {
                Console.WriteLine("Ingrese los nuevos datos del producto: ");
                Producto nuevosDatosProducto = ObtenerDatosProductoDesdeConsola();
                nuevosDatosProducto.Id = id;
                if (productoService.ValidarProducto(nuevosDatosProducto))
                {
                    productoRepository.Update(nuevosDatosProducto);
                    Console.WriteLine("Producto actualizado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Error en la validación del producto.");
                }
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        static void EliminarProducto(ProductoRepository productoRepository)
        {
            Console.WriteLine("Ingrese el ID del producto a eliminar: ");
            int id = int.Parse(Console.ReadLine());
            productoRepository.Delete(id);
            Console.WriteLine("Producto eliminado.");
        }

        static Producto ObtenerDatosProductoDesdeConsola()
        {
            Producto producto = new Producto();
            Console.Write("Descripción: ");
            producto.Descripcion = Console.ReadLine();
            Console.Write("Cantidad mínima: ");
            producto.Cantidad_minima = int.Parse(Console.ReadLine());
            Console.Write("Cantidad en stock: ");
            producto.Cantidad_stock = int.Parse(Console.ReadLine());
            Console.Write("Precio de compra: ");
            producto.Precio_compra = decimal.Parse(Console.ReadLine());
            Console.Write("Precio de venta: ");
            producto.Precio_venta = decimal.Parse(Console.ReadLine());
            Console.Write("Categoría: ");
            producto.Categoria = Console.ReadLine();
            Console.Write("Marca: ");
            producto.Marca = Console.ReadLine();
            Console.Write("Estado: ");
            producto.Estado = Console.ReadLine();
            return producto;
        }


        static void CrearDetalleFactura(DetalleFacturaRepository detalleFacturaRepository)
        {
            Console.WriteLine("Ingrese los datos del detalle de factura: ");
            DetalleFactura nuevoDetalleFactura = ObtenerDatosDetalleFacturaDesdeConsola();
            if (detalleFacturaService.ValidarDetalleFactura(nuevoDetalleFactura))
            {
                detalleFacturaRepository.Add(nuevoDetalleFactura);
                Console.WriteLine("Detalle de factura creado exitosamente.");
            }
            else
            {
                Console.WriteLine("Error en la validación del detalle de factura.");
            }
        }

        static void LeerDetalleFactura(DetalleFacturaRepository detalleFacturaRepository)
        {
            Console.WriteLine("Ingrese el ID del detalle de factura a consultar: ");
            int id = int.Parse(Console.ReadLine());
            DetalleFactura detalleFactura = detalleFacturaRepository.Get(id);
            if (detalleFactura != null)
            {
                Console.WriteLine("Detalle de factura encontrado: ");
                Console.WriteLine(detalleFactura);
            }
            else
            {
                Console.WriteLine("Detalle de factura no encontrado.");
            }
        }

        static void ActualizarDetalleFactura(DetalleFacturaRepository detalleFacturaRepository)
        {
            Console.WriteLine("Ingrese el ID del detalle de factura a actualizar: ");
            int id = int.Parse(Console.ReadLine());
            DetalleFactura detalleFactura = detalleFacturaRepository.Get(id);
            if (detalleFactura != null)
            {
                Console.WriteLine("Ingrese los nuevos datos del detalle de factura: ");
                DetalleFactura nuevosDatosDetalleFactura = ObtenerDatosDetalleFacturaDesdeConsola();
                nuevosDatosDetalleFactura.Id = id;
                if (detalleFacturaService.ValidarDetalleFactura(nuevosDatosDetalleFactura))
                {
                    detalleFacturaRepository.Update(nuevosDatosDetalleFactura);
                    Console.WriteLine("Detalle de factura actualizado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Error en la validación del detalle de factura.");
                }
            }
            else
            {
                Console.WriteLine("Detalle de factura no encontrado.");
            }
        }

        static void EliminarDetalleFactura(DetalleFacturaRepository detalleFacturaRepository)
        {
            Console.WriteLine("Ingrese el ID del detalle de factura a eliminar: ");
            int id = int.Parse(Console.ReadLine());
            detalleFacturaRepository.Delete(id);
            Console.WriteLine("Detalle de factura eliminado.");
        }

        static DetalleFactura ObtenerDatosDetalleFacturaDesdeConsola()
        {
            DetalleFactura detalleFactura = new DetalleFactura();
            Console.Write("ID Factura: ");
            detalleFactura.Id_Factura = int.Parse(Console.ReadLine());
            Console.Write("ID Producto: ");
            detalleFactura.Id_Producto = int.Parse(Console.ReadLine());
            Console.Write("Cantidad del producto: ");
            detalleFactura.Cantidad_producto = int.Parse(Console.ReadLine());
            Console.Write("Subtotal: ");
            detalleFactura.Subtotal = decimal.Parse(Console.ReadLine());
            return detalleFactura;
        }
    }
}