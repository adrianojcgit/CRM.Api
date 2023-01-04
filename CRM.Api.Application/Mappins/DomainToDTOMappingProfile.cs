using AutoMapper;
using CMR.Api.Domain.Entities;
using CRM.Api.Application.DTO;

namespace CRM.Api.Application.Mappings
{
    public class DomainToDTOMappingProfile: Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
			CreateMap<Endereco, EnderecoDTO>().ReverseMap();
		}
    }
}
