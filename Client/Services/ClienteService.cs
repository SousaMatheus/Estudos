using CrudBasicoClientes.Shared.Entitites;
using CrudBasicoClientes.Shared.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace CrudBasicoClientes.Client.Services
{
    public class ClienteService : IClienteRepository
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public ClienteService(HttpClient httpClient, JsonSerializerOptions options)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<Cliente> AdicionarCliente(Cliente model)
        {
            var cliente = await _httpClient.PostAsJsonAsync("api/Cliente/Add-Cliente", model);
            var response = await cliente.Content.ReadFromJsonAsync<Cliente>();
            return response!;
        }

        public async Task<Cliente> AtualizarClientes(Cliente model)
        {
            var cliente = await _httpClient.PutAsJsonAsync("api/cliente/update-cliente", model);
            var response = await cliente.Content.ReadFromJsonAsync<Cliente>();
            return response!;
        }

        public async Task<Cliente> ExcluirCliente(int idCliente)
        {
            var cliente = await _httpClient.DeleteAsync($"api/cliente/delete-cliente/{idCliente}");
            var response = await cliente.Content.ReadFromJsonAsync<Cliente>();
            return response!;
        }

        public async Task<Cliente> ObterCliente(int idCliente)
        {
            var cliente = await _httpClient.GetAsync($"api/cliente/{idCliente}");
            var reponse = await cliente.Content.ReadFromJsonAsync<Cliente>();
            return reponse!;
        }

        public async Task<List<Cliente>> ObterTodosClientes()
        {
            var cliente = await _httpClient.GetAsync("api/clientes");
            var reponse = await cliente.Content.ReadFromJsonAsync<List<Cliente>>();
            return reponse!;
        }
    }
}
