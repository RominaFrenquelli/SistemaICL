using ICL.Data;

namespace ICL.Repository
{
    public class ServicioRepository
    {
        private readonly ICLContext _context;

        public ServicioRepository(ICLContext context)
        {
            _context = context;
        }
    }
}
