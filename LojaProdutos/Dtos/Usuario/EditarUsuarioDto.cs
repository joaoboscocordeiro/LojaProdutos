using LojaProdutos.Dtos.Endereco;
using LojaProdutos.Enums;
using System.ComponentModel.DataAnnotations;

namespace LojaProdutos.Dtos.Usuario
{
    public class EditarUsuarioDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public CargoEnum Cargo { get; set; }
        public EditarEnderecoDto Endereco { get; set; }
    }
}
