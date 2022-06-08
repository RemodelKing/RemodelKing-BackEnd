using backend.Register.Domain.Models;
using backend.Register.Domain.Services.Communication;

namespace backend.Register.Domain.Services;

public interface IBusinessService
{
    Task<IEnumerable<Business>> ListAsync();
    Task<BusinessResponse> CreateAsync(Business business);
}