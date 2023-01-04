using CMR.Api.Domain.Entities;
namespace CMR.Api.Domain.Interfaces
{	public interface IClienteRabbitRepository
	{
		Task<IEnumerable<Cliente>> GetAll();
		Task<IEnumerable<Cliente>> GetByPorte(string porte);
		Task<Cliente> GetByCnpj(string CNPJ);
	}
}
