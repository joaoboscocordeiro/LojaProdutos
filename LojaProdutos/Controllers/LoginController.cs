using LojaProdutos.Dtos.Login;
using LojaProdutos.Services.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace LojaProdutos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioInterface _usuarioInterface;

        public LoginController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUsuarioDto loginUsuarioDto)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _usuarioInterface.Login(loginUsuarioDto);

                if (usuario == null)
                {
                    TempData["MesangemErro"] = "Credenciais inválidas!";
                    return View(loginUsuarioDto);
                }

                TempData["MesangemSucesso"] = "Usuário logado com sucesso!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["MesagemErro"] = "Verifique os dados informados!";
                return View(loginUsuarioDto);
            }
        }
    }
}
