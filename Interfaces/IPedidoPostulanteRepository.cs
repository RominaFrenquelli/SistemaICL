using ICL.Models;

namespace ICL.Interfaces
{
    public interface IPedidoPostulanteRepository
    {
        Task<int> CrearPedidoPostulante(PedidoPostulante postulante);
        Task<PedidoPostulante> ObtenerPedidoPostulante(int id);
        Task<PedidoPostulante> ExistePostulante(string dni);
        Task<List<PedidoPostulante>> ListarPedidos();
        Task<PedidoPostulante> ObtenerPorDNI(string postulanteDNI);
        Task<int> ContarPedidos(int año);
        Task EditarPedido(PedidoPostulante nuevoPedido);
        Task EliminarPedidoFisico(PedidoPostulante pedidoEliminado);
        Task EliminarPedidoLogico(PedidoPostulante pedidoEliminadoLogico);
        Task ReactivarPedido(PedidoPostulante pedido);
    }
}
