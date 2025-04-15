using LojaProdutos.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace LojaProdutos.Services.Sessao
{
    public class SessaoService : ISessaoInterface
    {
        private readonly HttpContextAccessor _ctx;

        public SessaoService(HttpContextAccessor ctx)
        {
            _ctx = ctx;
        }
        public UsuarioModel BuscarSessao()
        {
            string sessaoUsuario = _ctx.HttpContext.Session.GetString("usuarioSessao");

            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessao(UsuarioModel usuario)
        {
            string usuarioJson = JsonConvert.SerializeObject(usuario);
            _ctx.HttpContext.Session.SetString("usuarioSessao", usuarioJson);
        }

        public void RemoveSessao()
        {
            _ctx.HttpContext.Session.Remove("usuarioSessao");
        }
    }
}
