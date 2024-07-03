using ExamenParcial1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ExamenParcialNegocios
{
    public class FacturaService
    {
            public bool ValidarFactura(Factura factura)
            {
                if (factura.Total <= 0 || factura.TotalIva5 < 0 || factura.TotalIva10 < 0 ||
                    string.IsNullOrEmpty(factura.TotalLetras) || factura.TotalLetras.Length < 6 ||
                    !EsFormatoNroFacturaValido(factura.NroFactura))
                {
                    return false;
                }
                return true;
            }

            private bool EsFormatoNroFacturaValido(string nroFactura)
            {
                if (nroFactura.Length != 10)
                    return false;

                if (!char.IsDigit(nroFactura[0]) || !char.IsDigit(nroFactura[1]) || !char.IsDigit(nroFactura[2]) || nroFactura[3] != '-' ||
                    !char.IsDigit(nroFactura[4]) || !char.IsDigit(nroFactura[5]) || !char.IsDigit(nroFactura[6]) || !char.IsDigit(nroFactura[7]) ||
                    nroFactura[8] != '-' || !char.IsDigit(nroFactura[9]))
                    return false;
                return true;
            }
        }
    }