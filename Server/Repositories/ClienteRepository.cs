using CrudBasicoClientes.Server.Context;
using CrudBasicoClientes.Shared.Entitites;
using CrudBasicoClientes.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CrudBasicoClientes.Server.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteContext _context;
        public ClienteRepository(ClienteContext clienteContext)
        {
            _context = clienteContext;
        }

        public async Task<Cliente?> AdicionarCliente(Cliente cliente)
        {
            if(cliente == null) return null;

            var check = await _context.Clientes.FirstOrDefaultAsync(c => c.Nome
                                               .Equals(cliente.Nome, StringComparison.OrdinalIgnoreCase));

            if(check is not null) return null;

            var novoCliente = _context.Clientes.Add(cliente).Entity;
            await _context.SaveChangesAsync();
            return novoCliente;
        }

        public async Task<Cliente> AtualizarClientes(Cliente cliente)
        {
            var clienteAtlz = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == cliente.Id);
            if(clienteAtlz == null) return null;

            clienteAtlz.Nome = cliente.Nome;
            clienteAtlz.Email = cliente.Email;

            await _context.SaveChangesAsync();

            return await _context.Clientes.FirstOrDefaultAsync(c => c.Id == cliente.Id);
        }

        public async Task<Cliente?> ExcluirCliente(int idCliente)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(_ => _.Id == idCliente);

            if(cliente is null) return null;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> ObterCliente(int idCliente)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == idCliente);

            if(cliente is null) return null;

            return cliente;
        }

        public async Task<List<Cliente>> ObterTodosClientes()
        {
            return await _context.Clientes.ToListAsync();
        }
    }
}
