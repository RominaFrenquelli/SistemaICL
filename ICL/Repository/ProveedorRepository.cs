using ICL.Data;

namespace ICL.Repository
{
    public class ProveedorRepository
    {
        private readonly ICLContext _context;

        public ProveedorRepository(ICLContext context)
        {
            _context = context;
        }
    }
}
