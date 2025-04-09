using ICL.Data;

namespace ICL.Repository
{
    public class AdministradorRepository
    {
        private readonly ICLContext _context;

        public AdministradorRepository(ICLContext context)
        {
            _context = context;
        }

        
    }
}
