﻿using LojaProdutos.Dtos.Produto;
using LojaProdutos.Models;
﻿using LojaProdutos.Models;

namespace LojaProdutos.Services.Produto
{
    public interface IProdutoInterface
    {
        Task<List<ProdutoModel>> BuscarProdutos();
        Task<List<ProdutoModel>> BuscarProdutoFiltro(string? pesquisar);
        Task<ProdutoModel> Cadastar(CriarProdutoDto criarProdutoDto, IFormFile foto);
        Task<ProdutoModel> BuscarProdutoPorId(int id);
        Task<ProdutoModel> Editar(EditarProdutoDto editarProdutoDto, IFormFile foto);
        Task<ProdutoModel> Remover(int id);
    }
}
