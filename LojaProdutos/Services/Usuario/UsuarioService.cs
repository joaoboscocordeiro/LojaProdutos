using LojaProdutos.Data;
using LojaProdutos.Dtos.Usuario;
using LojaProdutos.Models;
using LojaProdutos.Services.Autenticacao;
using Microsoft.EntityFrameworkCore;

namespace LojaProdutos.Services.Usuario
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly DataContext _context;
        private readonly IAutenticacaoInterface _autenticacaoInterface;

        public UsuarioService(DataContext context, IAutenticacaoInterface autenticacaoInterface)
        {
            _context = context;
            _autenticacaoInterface = autenticacaoInterface;
        }
        public async Task<UsuarioModel> BuscarUsuarioPorId(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.Include(e => e.Endereco)
                    .FirstOrDefaultAsync(u => u.Id == id);

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<UsuarioModel>> BuscarUsuarios()
        {
            try
            {
                return await _context.Usuarios.Include(e => e.Endereco).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<CriarUsuarioDto> Cadastrar(CriarUsuarioDto criarUsuarioDto)
        {
            try
            {
                // Serviço que cria a senhaHash e senhaSalt
                _autenticacaoInterface.CriarSenhaHash(criarUsuarioDto.Senha, out byte[] senhaHash, out byte[] senhaSalt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> VerificaSeExisteEmail(CriarUsuarioDto criarUsuarioDto)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == criarUsuarioDto.Email);

                if (usuario == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
