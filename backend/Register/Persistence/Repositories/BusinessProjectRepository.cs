using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Register.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace backend.Register.Persistence.Repositories;

public class BusinessProjectRepository: BaseRepository, IBusinessProjectRepository
{
    public BusinessProjectRepository(AppDbContext context) : base(context)
    {
        
    }
    public async Task<IEnumerable<BusinessProject>> ListAsync()
    {
        return await _context.BusinessProjects.ToListAsync();
    }
    public async Task<BusinessProject> FindByIdAsync(int id)
    {
        return await _context.BusinessProjects.FindAsync(id);
    }
    public async Task AddAsync(BusinessProject businessProject)
    {
        await _context.BusinessProjects.AddAsync(businessProject);
    }

    public async Task DeleteAsync(BusinessProject businessProject)
    {
        _context.BusinessProjects.Remove(businessProject);
    }
}