using backend.Register.Domain.Models;
using backend.Register.Domain.Services.Communication;
using backend.Security.Domain.Models;
using backend.Security.Domain.Services.Communication;

namespace backend.Security.Domain.Services;

public interface IUserClientService
{
    Task<AuthenticateClientResponse> Authenticate(AuthenticateClientRequest request);
    Task<IEnumerable<Client>> ListAsync();
    Task<Client> GetByIdAsync(long id);
    Task<RegisterClientResponse> RegisterAsync(RegisterClientRequest request);
    Task UpdateAsync(long id, UpdateClientRequest request);
    Task DeleteAsync(long id);
}