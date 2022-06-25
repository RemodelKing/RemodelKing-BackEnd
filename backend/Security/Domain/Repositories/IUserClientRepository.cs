using backend.Register.Domain.Models;
using backend.Security.Domain.Models;

namespace backend.Security.Domain.Repositories;

public interface IUserClientRepository
{
    Task<IEnumerable<Client>> ListAsync();
    Task AddAsync(Client user);
    Task<Client> FindByIdAsync(long id);
    /*Task<Client> FindByUsernameAsync(string username);
    bool ExistsByUsername(string username);*/
    Task<Client> FindByEmailAsync(string email);
    bool ExistsByEmail(string email);
    Client FindById(long id);
    void Update(Client user);
    void Remove(Client user);
}