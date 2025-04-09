using ICL.Data;
using ICL.Repository;

namespace ICL.Business
{
    public class ServicioBusiness
    {
        private readonly ServicioRepository _repository;

        public ServicioBusiness(ICLContext context)
        {
            _repository = new ServicioRepository(context);
        }
    }
}
