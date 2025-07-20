using ICL.Data;
using ICL.Interfaces;
using ICL.Models;
using Microsoft.EntityFrameworkCore;

namespace ICL.Repository
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly ICLContext _context;

        public ServicioRepository(ICLContext context)
        {
            _context = context;
        }

        public async Task<int> CrearServicio(Servicio nuevo)
        {
            await _context.Servicio.AddAsync(nuevo);
            await _context.SaveChangesAsync();
            return nuevo.Id;
        }

        public async Task<List<Servicio>> ListarServicio()
        {
            return await _context.Servicio.Where(s => s.Enable == null || s.Enable != false).ToListAsync();
        }

        public async Task<List<Servicio>> ObtenerPorIds(List<int> ids)
        {
            return await _context.Servicio.Where(s => ids.Contains(s.Id) && (s.Enable == null || s.Enable == true)).ToListAsync();
        }

    }
}
