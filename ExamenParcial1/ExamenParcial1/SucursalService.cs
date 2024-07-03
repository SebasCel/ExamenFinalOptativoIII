public class SucursalService
{
    public bool ValidarSucursal(Sucursal sucursal)
    {
        if (string.IsNullOrEmpty(sucursal.Direccion) || sucursal.Direccion.Length < 10 ||
            string.IsNullOrEmpty(sucursal.Mail) || !sucursal.Mail.Contains("@") ||
            !sucursal.Mail.Substring(sucursal.Mail.IndexOf("@")).Contains("."))
        {
            return false;
        }
        return true;
    }
}