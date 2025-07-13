using ICL.Data;
using ICL.Interfaces;
using ICL.Models;
using Microsoft.EntityFrameworkCore;

namespace ICL.Repository
{
    public class PedidoPostulanteRepository : IPedidoPostulanteRepository
    {
        private readonly ICLContext _context;

        public PedidoPostulanteRepository(ICLContext context)
        {
            _context = context;
        }

        
        public async Task<int> CrearPedidoPostulante(PedidoPostulante postulante)
        {
            _context.PedidoPostulante.Add(postulante);

            await _context.SaveChangesAsync();

            return postulante.Id;
        }

        public async Task<PedidoPostulante> ObtenerPedidoPostulante(int id)
        {
            return await _context.PedidoPostulante
                .Include(p => p.Solicitud.Cliente)
                .Include(p => p.Servicios)
                .Include(p => p.Redactor)
                .Include(p => p.Proveedor)
                .Include(p => p.Solicitud)
                .FirstOrDefaultAsync(p => p.Id == id);
            
        }

        public async Task<PedidoPostulante> ExistePostulante(string dni)
        {
            PedidoPostulante? postulanteExistente = await _context.PedidoPostulante.FirstOrDefaultAsync(p => p.DNI == dni);

            return postulanteExistente;
        }

        public async Task<List<PedidoPostulante>> ListarPedidos ()
        {
            return await _context.PedidoPostulante
                .Include(p => p.Solicitud.Cliente)
                .Include(p => p.Servicios)
                .Include(p => p.Redactor)
                .Include(p => p.Proveedor)
                .Include(p => p.Solicitud)
                .ToListAsync();
        }

        public async Task<PedidoPostulante> ObtenerPorDNI(string postulanteDNI)
        {
            return await _context.PedidoPostulante.Include(p => p.Solicitud).FirstOrDefaultAsync(p => p.DNI == postulanteDNI);
        }

        public async Task<int> ContarPedidos(int año)
        {
            return await _context.PedidoPostulante.CountAsync(p => p.FechaDeIngreso.Year == año);
        }

        public async Task EditarPedido (PedidoPostulante nuevoPedido)
        {
            _context.PedidoPostulante.Update(nuevoPedido);

            await _context.SaveChangesAsync();
        }

        public async Task EliminarPedidoFisico(PedidoPostulante pedidoEliminado)
        {
         
                _context.PedidoPostulante.Remove(pedidoEliminado);
                await _context.SaveChangesAsync();

        }

        public async Task EliminarPedidoLogico(PedidoPostulante pedidoEliminadoLogico)
        {
            pedidoEliminadoLogico.Enable = false;
            _context.PedidoPostulante.Update(pedidoEliminadoLogico);
            await _context.SaveChangesAsync();
        }

        public async Task ReactivarPedido(PedidoPostulante pedido)
        {
            pedido.Enable = true;
            _context.PedidoPostulante.Update(pedido);
            await _context.SaveChangesAsync();
        }
    }
}
