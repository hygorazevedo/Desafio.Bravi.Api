using AutoMapper;
using Desafio.Bravi.Domain.Models;

namespace Desafio.Bravi.Api.Controllers.CriarCliente
{
    internal class CriarClienteProfile : Profile
    {
        public CriarClienteProfile()
        {
            CreateMap<CriarClienteRequest, Cliente>();
        }
    }
}
