using backend.Register.Domain.Models;
using backend.Security.Domain.Models;

namespace backend.Security.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    string GenerateToken(long id,string email, string type);
    ClaimsToken? ValidateToken(string token);
}