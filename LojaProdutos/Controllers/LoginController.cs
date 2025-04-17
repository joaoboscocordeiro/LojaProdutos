﻿using LojaProdutos.Dtos.Login;
using LojaProdutos.Services.Sessao;
using LojaProdutos.Services.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace LojaProdutos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioInterface _usuarioInterface;
        private readonly ISessaoInterface _sessaoInterface;

        public LoginController(IUsuarioInterface usuarioInterface, ISessaoInterface sessaoInterface)
        {
            _usuarioInterface = usuarioInterface;
            _sessaoInterface = sessaoInterface;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Sair()
        {
            _sessaoInterface.RemoveSessao();
            return RedirectToAction("Login", "Login");
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
