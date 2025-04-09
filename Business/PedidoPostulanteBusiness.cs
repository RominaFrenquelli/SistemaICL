using ICL.Data;
using ICL.Models;
using ICL.Repository;

namespace ICL.Business
{
    public class PedidoPostulanteBusiness
    {
        private readonly PedidoPostulanteRepository _repository;

        public PedidoPostulanteBusiness(PedidoPostulanteRepository pedidoPostulanteRepository)
        {
            _repository = pedidoPostulanteRepository;
        }

        public int CrearPostulante(PedidoPostulante algunPostulante)
        {
            if (algunPostulante == null)
            {
                throw new Exception("El postulante llego en null");
            }

            var postulantesExistentes = _repository.ExistePostulante(algunPostulante.DNI);

            if (postulantesExistentes != null && postulantesExistentes.Solicitud != null)
            {
                algunPostulante.Observaciones += $"⚠️ ALERTA: Este postulante ya ha sido solicitado anteriormente el {postulantesExistentes.Solicitud.FechaDeIngreso} por otra empresa.";

            }

            algunPostulante.Validate();

            return _repository.CrearPedidoPostulante(algunPostulante);
        }

        public PedidoPostulante ObtenerPedido(int idPedido)
        {
            PedidoPostulante pedido = _repository.ObtenerPedidoPostulante(idPedido);

            return pedido;

        }


    }
    
}
