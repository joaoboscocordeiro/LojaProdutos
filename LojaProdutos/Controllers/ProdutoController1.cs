using LojaProdutos.Services.Produto;
using Microsoft.AspNetCore.Mvc;

namespace LojaProdutos.Controllers
{
    public class ProdutoController1 : Controller
    {
        private readonly IProdutoInterface _produtoInterface;
        public ProdutoController1(IProdutoInterface produtoInterface)
        {
            _produtoInterface = produtoInterface;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoInterface.BuscarProdutos();
            return View(produtos);
        }
    }
}
