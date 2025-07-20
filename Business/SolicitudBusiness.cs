using ICL.Data;
using ICL.Models;
using ICL.Repository;

namespace ICL.Business
{
    public class SolicitudBusiness
    {
        private readonly SolicitudRepository _repository;
        private readonly PedidoPostulanteBusiness _postulanteBusiness;

        public SolicitudBusiness(ICLContext context)
        {
            _repository = new SolicitudRepository(context);
            _postulanteBusiness = new PedidoPostulanteBusiness(new PedidoPostulanteRepository(context), new ServicioRepository(context)); 
        }

        
        public int CrearSolicitud(Solicitud solicitud, List<PedidoPostulante> pedidos)
        {
            if (pedidos == null)
            {
                throw new Exception("El pedido llego en null");
            }

            if (pedidos == null || pedidos.Count == 0)
            {
                throw new Exception("Debe haber al menos un pedido asociado a la solicitud.");
            }

            // Crear la solicitud en la base de datos y obtener el ID generado
            int idGeneradoDeSolicitud = _repository.CrearSolicitud(solicitud);

            // Asignar el ID de la solicitud a cada PedidoPostulante y guardarlos
            foreach (var pedido in pedidos)
            {
                pedido.SolicitudId = idGeneradoDeSolicitud; // Asigna la relación
                _postulanteBusiness.CrearPostulante(pedido); // Guarda cada pedido en la BD
            }

            return idGeneradoDeSolicitud;
            // Dispara el evento
            //_repository.PedidoCreado?.Invoke(this, new PedidoCreadoEvent { Pedido = unPedido });

        }

        public class PedidoCreadoEvent
        {
            public PedidoPostulante Pedido { get; set; }
        }


        public Solicitud ObtenerSolicitud(int idSolicitud)
        {
            return _repository.ObtenerSolicitud(idSolicitud);
        }




    }
}
