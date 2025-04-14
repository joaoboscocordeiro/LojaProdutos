using AutoMapper;
using LojaProdutos.Dtos.Endereco;
using LojaProdutos.Models;

namespace LojaProdutos.Profiles
{
    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper()
        {
            CreateMap<EnderecoModel, EditarEnderecoDto>().ReverseMap();
        }
    }
}
