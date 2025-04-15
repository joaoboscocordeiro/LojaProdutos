using LojaProdutos.Dtos.Login;
using Microsoft.AspNetCore.Mvc;

namespace LojaProdutos.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUsuarioDto loginUsuarioDto)
        {
            return View(loginUsuarioDto);
        }
    }
}
