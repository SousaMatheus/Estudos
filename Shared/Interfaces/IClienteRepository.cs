using CrudBasicoClientes.Shared.Entitites;

namespace CrudBasicoClientes.Shared.Interfaces
{
    public interface IClienteRepository
    {
        public Task<Cliente> AdicionarCliente(Cliente cliente);
        public Task<Cliente> ObterCliente(int idCliente);
        public Task<List<Cliente>> ObterTodosClientes();
        public Task<Cliente> AtualizarClientes(Cliente cliente);
        public Task<Cliente> ExcluirCliente(int idCliente);
    }
}
