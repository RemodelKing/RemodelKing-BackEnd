using backend.Register.Domain.Models;
using backend.Register.Domain.Services.Communication;

namespace backend.Register.Domain.Services;

public interface IPortfolioService
{
    Task<IEnumerable<Portfolio>> ListAsync();
    Task<PortfolioResponse> CreateAsync(Portfolio portfolio);
}