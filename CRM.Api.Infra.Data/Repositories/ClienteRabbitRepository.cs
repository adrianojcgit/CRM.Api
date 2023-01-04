using CMR.Api.Domain.Entities;
using CMR.Api.Domain.Interfaces;
using CRM.Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CRM.Api.Infra.Data.Repositories
{
	public class ClienteRabbitRepository : IClienteRabbitRepository
	{
		private readonly ApplicationDbContext _context;
		public ClienteRabbitRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Cliente>> GetByPorte(string porte)
		{
			var result = await _context.Clientes.Where(x => x.PorteEmpresa == porte).ToListAsync();
			return result;
		}
		public async Task<IEnumerable<Cliente>> GetAll()
		{
			var result = await _context.Clientes.ToListAsync();
			return result;
		}

		public async Task<Cliente> GetByCnpj(string CNPJ)
		{
			var result = await _context.Clientes.FirstOrDefaultAsync(x => x.CnpjParametro.Contains(CNPJ));
			return result;
		}
	}
}
