using ICL.Data;
using ICL.Models;

namespace ICL.Repository
{
    public class ServicioRepository
    {
        private readonly ICLContext _context;

        public ServicioRepository(ICLContext context)
        {
            _context = context;
        }

        public int CrearServicio(Servicio nuevo)
        {
            _context.Servicio.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }

        public List<Servicio> ListarServicio()
        {
            return _context.Servicio.Where(s => s.Enable != null || s.Enable != false).ToList();
        }

    }
}
