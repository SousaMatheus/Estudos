using CrudBasicoClientes.Shared.Entitites;
using Microsoft.EntityFrameworkCore;

namespace CrudBasicoClientes.Server.Context
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions options) : base (options)
        {
            
        }
        
        public DbSet<Cliente> Clientes { get; set; }
    }
}
