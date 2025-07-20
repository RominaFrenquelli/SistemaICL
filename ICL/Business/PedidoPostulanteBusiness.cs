using ICL.Data;
using ICL.Interfaces;
using ICL.Models;
using ICL.Models.DTOs;
using ICL.Repository;

namespace ICL.Business
{
    public class PedidoPostulanteBusiness : IPedidoPostulanteBusiness
    {
        private readonly IPedidoPostulanteRepository _repository;
        private readonly IServicioRepository _servicioRepository;

        public PedidoPostulanteBusiness(IPedidoPostulanteRepository pedidoPostulanteRepository, IServicioRepository servicioRepo)
        {
            _repository = pedidoPostulanteRepository;
            _servicioRepository = servicioRepo;
        }

        private async Task<string> GenerarCodigoPedido()
        {
            int añoActual = DateTime.Now.Year;

            int cantidadPedidosEsteAño = await _repository.ContarPedidos(añoActual);

            int nuevoNumero = cantidadPedidosEsteAño + 1;

            return $"PED-{nuevoNumero:D5}-{añoActual}";
        }

        public async Task<int> CrearPostulante(PedidoPostulante algunPostulante)
        {
            if (algunPostulante == null)
            {
                throw new Exception("El postulante llego en null");
            }

            var postulantesExistentes = await _repository.ExistePostulante(algunPostulante.DNI);

            if (postulantesExistentes != null && postulantesExistentes.Solicitud != null)
            {
                algunPostulante.Observaciones += $"⚠️ ALERTA: Este postulante ya ha sido solicitado anteriormente por otra empresa.";

            }

            algunPostulante.Servicios = await _servicioRepository.ObtenerPorIds(algunPostulante.ServiciosId ?? new());

            var codigo = await GenerarCodigoPedido();
            algunPostulante.AsignarCodigo(codigo);

            return await _repository.CrearPedidoPostulante(algunPostulante);
        }

        public async Task EditarPedido (int id, PedidoPostulante nuevoPedido)
        {
            var pedidoExistente = await _repository.ObtenerPedidoPostulante(id);

            if(pedidoExistente == null) 
            { 
                throw new Exception("El pedido es nulo"); 
            }

            pedidoExistente.Nombre = nuevoPedido.Nombre;
            pedidoExistente.Apellido = nuevoPedido.Apellido;
            pedidoExistente.DNI = nuevoPedido.DNI;
            pedidoExistente.FechaDeNacimiento = nuevoPedido.FechaDeNacimiento;
            pedidoExistente.ServiciosId = nuevoPedido.ServiciosId;
            pedidoExistente.Observaciones = nuevoPedido.Observaciones;
            pedidoExistente.ProveedorId = nuevoPedido.ProveedorId;
            pedidoExistente.RedactorId = nuevoPedido.RedactorId;

            await _repository.EditarPedido(pedidoExistente);
        }

        //public PedidoPostulante ObtenerPedido(int idPedido)
        //{
        //    PedidoPostulante pedido = _repository.ObtenerPedidoPostulante(idPedido);

        //    return pedido;

        //}

        public async Task<PedidoPostulanteDTO?> BuscarPorId(int id)
        {
            var pedido = await _repository.ObtenerPedidoPostulante(id);
            return MapearAPedidoPostulanteDTO(pedido);
        }

        //public List<PedidoPostulante> ListarPedidos()
        //{
        //    return _repository.ListarPedidos();
        //}

        public async Task<List<PedidoPostulanteDTO>> ListarPedidos()
        {
            var pedidos = await _repository.ListarPedidos();

            var dtoList = pedidos.Select(p => new PedidoPostulanteDTO
            {
                Id = p.Id,
                CodigoPedido = p.CodigoPedido,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                DNI = p.DNI,
                FechaDeNacimiento = p.FechaDeNacimiento,
                FechaDeIngreso = p.FechaDeIngreso,
                FechaDeEntrega = p.FechaDeEntrega,
                Estado = p.Estado.ToString(),
                Observaciones = p.Observaciones,
                SolicitudId = p.SolicitudId,
                NombreCliente = p.Solicitud?.Cliente?.RazonSocial,
                NombreServicios = p.Servicios != null && p.Servicios.Any() ? string.Join(", ", p.Servicios.Select(s => s.Nombre)) : null,
                NombreRedactor = p.Redactor?.Nombre,
                NombreProveedor = p.Proveedor?.Nombre
            }).ToList();

            return dtoList;
        }

        //public PedidoPostulante ObtenerPorDNI(string dni)
        //{
        //    if (dni == null)
        //        throw new Exception("El postulante no existe en el sistema");

        //    return _repository.ObtenerPorDNI(dni);
        //}

        public async Task<PedidoPostulanteDTO?> BuscarPorDNI(string dni)
        {
            var pedido = await _repository.ObtenerPorDNI(dni);
            return  MapearAPedidoPostulanteDTO(pedido);
        }

        private PedidoPostulanteDTO? MapearAPedidoPostulanteDTO(PedidoPostulante? p)
        {
            if (p == null) return null;

            return new PedidoPostulanteDTO
            {
                Id = p.Id,
                CodigoPedido = p.CodigoPedido,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                DNI = p.DNI,
                FechaDeNacimiento = p.FechaDeNacimiento,
                FechaDeIngreso = p.FechaDeIngreso,
                FechaDeEntrega = p.FechaDeEntrega,
                Estado = p.Estado.ToString(),
                Observaciones = p.Observaciones,
                SolicitudId = p.SolicitudId,
                NombreCliente = p.Solicitud?.Cliente?.RazonSocial,
                NombreServicios = p.Servicios != null && p.Servicios.Any() ? string.Join(", ", p.Servicios.Select(s => s.Nombre)) : null,
                NombreRedactor = p.Redactor?.Nombre,
                NombreProveedor = p.Proveedor?.Nombre
            };
        }

        public async Task EliminarPedidoFisico(int id)
        {
            PedidoPostulante pedido = await _repository.ObtenerPedidoPostulante(id);
            await _repository.EliminarPedidoFisico(pedido);
        }

        public async Task PedidoEliminarLogico(int id)
        {
            PedidoPostulante eliminadoLogicoPedido = await _repository.ObtenerPedidoPostulante(id);
            if (eliminadoLogicoPedido == null || !eliminadoLogicoPedido.Enable)
                throw new Exception("El pedido no se encontró o ya se encuentra deshabilitado");
            
           await _repository.EliminarPedidoLogico(eliminadoLogicoPedido);
        }

        public async Task ReactivarPerdido(int id)
        {
            PedidoPostulante pedido = await _repository.ObtenerPedidoPostulante(id);
            if(pedido == null)
                throw new Exception("El pedido no se encontró");

            if (pedido.Enable)
                throw new Exception("El pedido ya está habilitado.");

            await _repository.ReactivarPedido(pedido);
        }
    }
    
}
