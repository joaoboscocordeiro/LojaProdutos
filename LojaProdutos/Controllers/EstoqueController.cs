using ClosedXML.Excel;
using LojaProdutos.Filtros;
using LojaProdutos.Services.Estoque;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LojaProdutos.Controllers
{

    [UsuarioLogado]
    public class EstoqueController : Controller
    {
        private readonly IEstoqueInterface _estoqueInterface;

        public EstoqueController(IEstoqueInterface estoqueInterface) 
        {
            _estoqueInterface = estoqueInterface;
        }

        [UsuarioLogadoAdm]
        public IActionResult Index()
        {
            var registros = _estoqueInterface.ListarRegistros();
            return View(registros);
        }

        public IActionResult GerarRelatorio()
        {
            // Buscar os dados
            var dados = BuscarDados();

            // Retornar o arquivo
            using (XLWorkbook workbook = new XLWorkbook())
            {
                workbook.AddWorksheet(dados, "Dados Vendas");

                using (MemoryStream ms = new MemoryStream())
                {
                    workbook.SaveAs(ms);
                    return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spredsheetml.sheet", "Vendas.xls");
                }
            }
        }

        private DataTable BuscarDados()
        {
            DataTable dataTable = new DataTable();

            dataTable.TableName = "Dados Vendas - Produtos";

            dataTable.Columns.Add("ProdutoId", typeof(int));
            dataTable.Columns.Add("Categoria", typeof(string));
            dataTable.Columns.Add("Data da Compra", typeof(DateTime));
            dataTable.Columns.Add("Valor Total", typeof(double));

            var dados = _estoqueInterface.ListarRegistros();

            if (dados.Count > 0)
            {
                foreach (var registro in dados)
                {
                    dataTable.Rows.Add(registro.ProdutoId, registro.CategoriaNome, registro.DataCompra, registro.Total);
                }
            }
            return dataTable;
        }

        [HttpPost]
        public async Task<IActionResult> BaixarEstoque(int id)
        {
            var produtoBaixador = await _estoqueInterface.CriarRegistro(id);
            TempData["MensagemSucesso"] = "Compra Realizada com Sucesso!";
            return RedirectToAction("Index", "Home");
        }
    }
}
