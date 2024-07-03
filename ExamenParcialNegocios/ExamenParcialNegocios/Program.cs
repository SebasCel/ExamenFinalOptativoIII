using ExamenParcial1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenParcialNegocios
{
    class Program
    {
        static void Main(string[] args)
        {
            ValidarDatosCliente();
            ValidarDatosFactura();
        }

        static void ValidarDatosCliente()
        {
            ClienteService clienteService = new ClienteService();
            Cliente cliente = ObtenerDatosClienteDesdeConsola();
            bool clienteValido = clienteService.ValidarCliente(cliente);

            if (clienteValido)
            {
                Console.WriteLine("Los datos del cliente son validos");
            }
            else
            {
                Console.WriteLine("Los datos del cliente no son validos");
            }
        }

        static void ValidarDatosFactura()
        {
            FacturaService facturaService = new FacturaService();
            Factura factura = ObtenerDatosFacturaDesdeConsola();

            bool facturaValida = facturaService.ValidarFactura(factura);

            if (facturaValida)
            {
                Console.WriteLine("Los datos de la factura son validos")
            }
            else
            {
                Console.WriteLine("Los datos de la factura no son validos");
            }
        }

        static Cliente ObtenerDatosClienteDesdeConsola()
        {
            Cliente cliente = new Clientes();
            Console.WriteLine("Ingresa el nombre del cliente:");
            cliente.Nombre = Console.ReadLine();
            Console.WriteLine("Ingresa el apellido del cliente:");
            cliente.Apellido = Console.ReadLine();
            return cliente;
        }

        static Factura ObtenerDatosFacturaDesdeConsola()
        {
            Factura factura = new Factura();
            Console.WriteLine("Ingrese el total de la factura:");
            factura.Total = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Ingrese el total en letras:");
            factura.TotalLetras = Console.ReadLine();
            return factura;
        }
    }
}