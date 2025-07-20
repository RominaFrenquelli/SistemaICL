using ICL.Data;

namespace ICL.Repository
{
    public class ListaDePreciosRepository
    {
        private readonly ICLContext _context;

        public ListaDePreciosRepository(ICLContext context)
        {
            _context = context;
        }
    }
}
