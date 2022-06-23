using backend.Register.Domain.Models;
using backend.Security.Domain.Models;
using backend.Security.Domain.Services.Communication;

namespace backend.Security.Domain.Services;

public interface IUserService
{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
    Task<IEnumerable<Business>> ListAsync();
    Task<Business> GetByIdAsync(long id);
    Task RegisterAsync(RegisterRequest request);
    Task UpdateAsync(long id, UpdateRequest request);
    Task DeleteAsync(long id);
}