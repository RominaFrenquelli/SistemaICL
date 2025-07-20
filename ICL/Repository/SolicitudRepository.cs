using ICL.Data;
using ICL.Models;
using Microsoft.EntityFrameworkCore;

namespace ICL.Repository
{
    public class SolicitudRepository
    {
        private readonly ICLContext _context;

        public SolicitudRepository(ICLContext context)
        {
            _context = context;
        }

        public int CrearSolicitud(Solicitud unaSolicitud)
        {
            _context.Solicitud.Add(unaSolicitud);

            _context.SaveChanges();

            return unaSolicitud.Id;
        }

        public Solicitud ObtenerSolicitud(int idSolicitud)
        {
            Solicitud laSolicitud = _context.Solicitud
                .Include(p => p.Pedidos)
                .Include(s => s.Cliente)
                .FirstOrDefault(sol => sol.Id == idSolicitud);

            return laSolicitud;
        }

        
    }
}
