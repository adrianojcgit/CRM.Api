using CMR.Api.Domain.Entities;

namespace CMR.Api.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClientes();
        Task<Cliente> GetById(int? id);
        Task<Cliente> Create(Cliente cliente);
        Task<Cliente> Update(Cliente cliente);
        Task<Cliente> Remove(Cliente cliente);
    }
}
