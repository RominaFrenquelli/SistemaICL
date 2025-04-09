using ICL.Data;
using ICL.Repository;

namespace ICL.Business
{
    public class ListaDePreciosBusiness
    {
        private readonly ListaDePreciosRepository _repository;

        public ListaDePreciosBusiness(ICLContext context)
        {
            _repository = new ListaDePreciosRepository(context);
        }
    }
}
