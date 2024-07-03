public class PedidoCompraService
{
    private readonly PedidoCompraRepository _pedidoCompraRepository;
    private readonly DetallePedidoRepository _detallePedidoRepository;

    public PedidoCompraService(PedidoCompraRepository pedidoCompraRepository, DetallePedidoRepository detallePedidoRepository)
    {
        _pedidoCompraRepository = pedidoCompraRepository;
        _detallePedidoRepository = detallePedidoRepository;
    }

    public bool ValidarPedido(PedidoCompra pedidoCompra)
    {
        var detalles = _detallePedidoRepository.GetAll().Where(d => d.Id_pedido == pedidoCompra.Id).ToList();
        if (detalles == null || detalles.Count == 0) return false;

        pedidoCompra.Total = detalles.Sum(d => d.Subtotal);
        return true;
    }

    public List<DetallePedido> ListarDetalles(int idPedido)
    {
        return _detallePedidoRepository.GetAll().Where(d => d.Id_pedido == idPedido).ToList();
    }
}