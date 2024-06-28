using System.ComponentModel.DataAnnotations;

namespace CrudBasicoClientes.Shared.Entitites
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Idade{ get; set; }
    }
}
