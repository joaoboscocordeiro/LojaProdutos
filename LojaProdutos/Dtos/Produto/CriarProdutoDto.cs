﻿using System.ComponentModel.DataAnnotations;

namespace LojaProdutos.Dtos.Produto
{
    public class CriarProdutoDto
    {
        [Required(ErrorMessage = "Digite o Nome!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite a Marca!")]
        public string Marca { get; set; }
        public string? Foto { get; set; }
        [Required(ErrorMessage = "Digite o Valor!")]
        public double Valor { get; set; }
        [Required(ErrorMessage = "Inserir a Quantidade!")]
        public int QuantidadeEstoque { get; set; }
        [Required(ErrorMessage = "Selecione a Categoria!")]
        public int CategoriaModelId { get; set; }
    }
}
