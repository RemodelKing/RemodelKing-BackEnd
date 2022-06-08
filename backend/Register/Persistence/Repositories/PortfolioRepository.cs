using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Register.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace backend.Register.Persistence.Repositories;

public class PortfolioRepository: BaseRepository, IPortfolioRepository
{
    public PortfolioRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Portfolio>> ListAsync()
    {
        return await _context.Portfolios
            .ToListAsync();
    }

    public async Task<Portfolio> FindByIdAsync(int id)
    {
        return await _context.Portfolios.FindAsync();
    }

    public async Task AddAsync(Portfolio portfolio)
    {
        await _context.Portfolios.AddAsync(portfolio);
    }

}