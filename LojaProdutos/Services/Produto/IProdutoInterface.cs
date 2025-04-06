<<<<<<< HEAD
﻿using LojaProdutos.Dtos.Produto;
using LojaProdutos.Models;
=======
﻿using LojaProdutos.Models;
>>>>>>> 6bf09e7b0729bf24deb5b7330c89a94496998304

namespace LojaProdutos.Services.Produto
{
    public interface IProdutoInterface
    {
        Task<List<ProdutoModel>> BuscarProdutos();
<<<<<<< HEAD
        Task<ProdutoModel> Cadastar(CriarProdutoDto criarProdutoDto, IFormFile foto);
        Task<ProdutoModel> BuscarProdutoPorId(int id);
        Task<ProdutoModel> Editar(EditarProdutoDto editarProdutoDto, IFormFile foto);
        Task<ProdutoModel> Remover(int id);
=======
>>>>>>> 6bf09e7b0729bf24deb5b7330c89a94496998304
    }
}
