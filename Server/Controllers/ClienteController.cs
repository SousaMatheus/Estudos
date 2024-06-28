using CrudBasicoClientes.Shared.Entitites;
using CrudBasicoClientes.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudBasicoClientes.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet("Clientes")]
        public async Task<ActionResult<List<Cliente>>> GetAllClientesAsync()
        {
            var clientes = await _clienteRepository.ObterTodosClientes();
            return Ok(clientes);
        }

        [HttpGet("Clientes/{id}")]
        public async Task<ActionResult<Cliente>> GetClienteById(int id)
        {
            var cliente = await _clienteRepository.ObterCliente(id);
            return Ok(cliente);
        }

        [HttpPost("Add-Cliente")]
        public async Task<ActionResult<Cliente>> AddClienteAsync(Cliente model)
        {
            var cliente = await _clienteRepository.AdicionarCliente(model);
            return Ok(cliente);
        }

        [HttpPut("Update-Cliente")]
        public async Task<ActionResult<Cliente>> UpdateClienteAsync(Cliente model)
        {
            var cliente = await _clienteRepository.AtualizarClientes(model);
            return Ok(cliente);
        }

        [HttpDelete("Delete-Cliente/{id}")]
        public async Task<ActionResult<Cliente>> DeleteClienteAsync(int id)
        {
            await _clienteRepository.ExcluirCliente(id);
            return Ok();
        }
    }
}
