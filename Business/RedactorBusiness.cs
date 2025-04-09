using ICL.Data;
using ICL.Repository;

namespace ICL.Business
{
    public class RedactorBusiness
    {
        private readonly RedactorRepository _repository;

        public RedactorBusiness(ICLContext context)
        {
            _repository = new RedactorRepository(context);
        }
    }
}
