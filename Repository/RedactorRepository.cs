using ICL.Data;

namespace ICL.Repository
{
    public class RedactorRepository
    {
        private readonly ICLContext _context;

        public RedactorRepository(ICLContext context)
        {
            _context = context;
        }
    }
}
