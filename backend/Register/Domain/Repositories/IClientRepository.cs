

using backend.Register.Domain.Models;

namespace backend.Register.Domain.Repositories;

public interface IClientRepository
{
    Task<IEnumerable<Client>> ListAsync();
    Task<Client> FindByIdAsync(long id);
    Task AddAsync(Client client);
}