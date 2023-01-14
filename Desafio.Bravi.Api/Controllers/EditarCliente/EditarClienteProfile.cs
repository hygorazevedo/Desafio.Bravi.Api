using AutoMapper;
using Desafio.Bravi.Domain.Models;

namespace Desafio.Bravi.Api.Controllers.EditarCliente
{
    internal class EditarClienteProfile : Profile
    {
        public EditarClienteProfile()
        {
            CreateMap<EditarClienteRequest, Cliente>();
        }
    }
}
