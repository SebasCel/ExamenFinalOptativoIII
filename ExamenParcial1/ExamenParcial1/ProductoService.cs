public class ProductoService
{
    public bool ValidarProducto(Producto producto)
    {
        if (string.IsNullOrEmpty(producto.Descripcion) || producto.Cantidad_minima < 1 ||
            producto.Precio_compra <= 0 || producto.Precio_venta <= 0)
        {
            return false;
        }
        return true;
    }
}