﻿namespace LojaProdutos.Models
{
    public class RegistroProdutoModel
    {
        public int ProdutoId { get; set; }
        public String CategoriaNome { get; set; }
        public double Total { get; set; }
        public DateTime DataCompra { get; set; }
        public double TotalGeral { get; set; }
    }
}
