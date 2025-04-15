using LojaProdutos.Models;

namespace LojaProdutos.Services.Sessao
{
    public interface ISessaoInterface
    {
        void CriarSessao(UsuarioModel usuario);
        void RemoveSessao();
        UsuarioModel BuscarSessao();
    }
}
