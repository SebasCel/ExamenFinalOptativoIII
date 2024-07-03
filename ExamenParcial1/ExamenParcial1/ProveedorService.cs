public class ProveedorService
{
    public bool ValidarProveedor(Proveedor proveedor)
    {
        if (string.IsNullOrEmpty(proveedor.RazonSocial) || proveedor.RazonSocial.Length < 3 ||
            string.IsNullOrEmpty(proveedor.TipoDocumento) || proveedor.TipoDocumento.Length < 3 ||
            string.IsNullOrEmpty(proveedor.NumeroDocumento) || proveedor.NumeroDocumento.Length < 3 ||
            proveedor.Celular.Length != 10 || !long.TryParse(proveedor.Celular, out _))
        {
            return false;
        }
        return true;
    }
}