using CRM.Api.Application.DTO;

namespace CRM.Api.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> GetClientes();
        Task<ClienteDTO> GetById(int? id);
        Task Add(ClienteDTO clienteDTO);
        Task Update(ClienteDTO clienteDTO);
        Task Remove(int? id);
    }
}
