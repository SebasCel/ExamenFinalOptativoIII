using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenParcialNegocios
{
    public class SucursalService
    {
        public bool ValidarSucursal(Sucursal sucursal)
        {
            if (string.IsNullOrEmpty(sucursal.Direccion) || sucursal.Direccion.Length < 10)
                return false;
            if (string.IsNullOrEmpty(sucursal.Mail) || sucursal.Mail.Contains("@") || !sucursal.Mail.Contains("."))
                return false;
            return true;
        }
    }
}
