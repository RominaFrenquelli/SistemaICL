using ICL.Models;
using ICL.Models.DTOs;

namespace ICL.Interfaces
{
    public interface IPedidoPostulanteBusiness
    {
        Task<int> CrearPostulante(PedidoPostulante algunPostulante);
        Task EditarPedido(int id, PedidoPostulante nuevoPedido);
        Task<PedidoPostulanteDTO?> BuscarPorId(int id);
        Task<List<PedidoPostulanteDTO>> ListarPedidos();
        Task<PedidoPostulanteDTO?> BuscarPorDNI(string dni);
        Task EliminarPedidoFisico(int id);
        Task PedidoEliminarLogico(int id);
        Task ReactivarPerdido(int id);
    }
}
