using DocumentFormat.OpenXml.InkML;
using LojaProdutos.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LojaProdutos.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessao = HttpContext.Session.GetString("usuarioSessao");
            
            if (string.IsNullOrEmpty(sessao)) return View();

            UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessao);

            return View(usuario);
        }
    }
}
