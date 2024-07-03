using ExamenParcial1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ExamenParcialNegocios
{

    public class ClienteService
    {
        public bool ValidarCliente(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nombre) || cliente.Nombre.Length < 3)
                return false;
            if (string.IsNullOrEmpty(cliente.Apellido) || cliente.Apellido.Length < 3)
                return false;
            if (string.IsNullOrEmpty(cliente.Documento) || cliente.Documento.Length < 3)
                return false;
            if (string.IsNullOrEmpty(cliente.Celular) || cliente.Celular.Length != 10 || !EsNumero(cliente.Celular))
                return false;

            return true;
        }
        private bool EsNumero(string valor)
        {
            foreach (char c in valor)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}