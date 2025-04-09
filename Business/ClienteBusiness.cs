using ICL.Data;
using ICL.Models;
using ICL.Repository;

namespace ICL.Business
{
    public class ClienteBusiness
    {
        private readonly ClienteRepository _repository;

        public ClienteBusiness(ICLContext context)
        {
            _repository = new ClienteRepository(context);
        }

        public int CrearCliente(Cliente algunCliente)
        {
            if (algunCliente == null)
            {
                throw new Exception("El cliente llego en null");
            }

            var clientesExistentes = _repository.ObtenerClientes();

            foreach (var cliente in clientesExistentes)
            {
                if (cliente.Cuil == algunCliente.Cuil)
                {
                    throw new Exception("El cliente ya existe en el sistema");
                }
            }

            algunCliente.Validate();

            var idGeneradoDeCliente = _repository.CrearCliente(algunCliente);

            return idGeneradoDeCliente;
        }

        public List<Cliente> ObtenerClientes()
        {
            // 1 - Obtengo los cliente
            var clientes = _repository.ObtenerClientes();

            // 2 - Retorno los cliente 
            return clientes;
        }

        public List<Cliente> BuscarClientes(string nombreCliente)
        {
            
            var clientes = _repository.BuscarClientes(nombreCliente);

             
            return clientes;
        }
    }
}

