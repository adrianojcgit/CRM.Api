using CRM.Api.Application.DTO;

namespace CRM.Api.Application.Interfaces
{
	public interface IClienteRabbitService
	{
		Task<IEnumerable<ClienteDTO>> GetByPorte(string porte);
		Task<IEnumerable<ClienteDTO>> GetAll();
		Task<ClienteDTO> GetByCnpj(string CNPJ);
	}
}
