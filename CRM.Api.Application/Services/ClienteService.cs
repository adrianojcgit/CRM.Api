using AutoMapper;
using CMR.Api.Domain.Entities;
using CMR.Api.Domain.Interfaces;
using CRM.Api.Application.DTO;
using CRM.Api.Application.Interfaces;
using System.Runtime.InteropServices;

namespace CRM.Api.Application.Services
{

	public class ClienteService : IClienteService
    {
        private readonly IMapper _mapper;
        private IClienteRepository _context;

        public ClienteService(IMapper mapper, IClienteRepository context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Add(ClienteDTO clienteDTO)
        {
            var clienteEntity = _mapper.Map<Cliente>(clienteDTO);
            await _context.Create(clienteEntity);
        }

        public async Task<ClienteDTO> GetById(int? id)
        {
            var clienteEntity = await _context.GetById(id);
            return _mapper.Map<ClienteDTO>(clienteEntity);
        }

        public async Task<IEnumerable<ClienteDTO>> GetClientes()
        {
            var clienteEntity = await _context.GetClientes();
            return _mapper.Map<IEnumerable<ClienteDTO>>(clienteEntity);
        }

        public async Task Remove(int? id)
        {
            var clienteEntity = _context.GetById(id).Result;
            await _context.Remove(clienteEntity);
        }

        public async Task Update(ClienteDTO clienteDTO)
        {
            var clienteEntity = _mapper.Map<Cliente>(clienteDTO);
            await _context.Update(clienteEntity);
        }
    }
}
