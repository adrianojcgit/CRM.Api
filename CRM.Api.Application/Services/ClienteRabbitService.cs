using AutoMapper;
using CMR.Api.Domain.Interfaces;
using CRM.Api.Application.DTO;
using CRM.Api.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Application.Services
{
	public class ClienteRabbitService : IClienteRabbitService
	{
		private readonly IMapper _mapper;
		private readonly IClienteRabbitRepository _context;

		public ClienteRabbitService(IMapper mapper, IClienteRabbitRepository context)
		{
			_mapper = mapper;
			_context = context;
		}

		public async Task<IEnumerable<ClienteDTO>> GetByPorte(string porte)
		{
			var clienteEntity = await _context.GetByPorte(porte);
			return _mapper.Map<IEnumerable<ClienteDTO>>(clienteEntity);
		}
		public async Task<IEnumerable<ClienteDTO>> GetAll()
		{
			var clienteEntity = await _context.GetAll();
			return _mapper.Map<IEnumerable<ClienteDTO>>(clienteEntity);
		}
		public async Task<ClienteDTO> GetByCnpj(string CNPJ)
		{
			var clienteEntity = await _context.GetByCnpj(CNPJ);
			return _mapper.Map<ClienteDTO>(clienteEntity);
		}
	}
}
