using AutoMapper;
using Desafio.Bravi.Domain.Models;
using Desafio.Bravi.Repository.EntityModels;

namespace Desafio.Bravi.Repository.MapperProfile
{
    internal class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<ECliente, Cliente>().ReverseMap();
            CreateMap<ETelefone, Telefone>().ReverseMap();
        }
    }
}
