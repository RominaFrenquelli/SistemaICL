using ICL.Data;
using ICL.Repository;

namespace ICL.Business
{
    public class ProveedorBusiness
    {
        private readonly ProveedorRepository _repository;

        public ProveedorBusiness(ICLContext context)
        {
            _repository = new ProveedorRepository(context);
        }
    }
}
