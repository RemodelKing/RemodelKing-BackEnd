using backend.Register.Domain.Models;

namespace backend.Register.Domain.Repositories;

public interface IPortfolioRepository
{
    Task<IEnumerable<Portfolio>> ListAsync();
    Task<Portfolio> FindByIdAsync(int id);
    Task AddAsync(Portfolio portfolio);
}