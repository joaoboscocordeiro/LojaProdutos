﻿using LojaProdutos.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LojaProdutos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] SenhaHash { get; set; }
        public byte[] SenhaSalt { get; set; }
        public CargoEnum Cargo { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; } = DateTime.Now;
        [ValidateNever]
        public EnderecoModel Endereco { get; set; }
    }
}
