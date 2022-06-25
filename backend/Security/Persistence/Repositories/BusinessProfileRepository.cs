using backend.Register.Domain.Models;
using backend.Security.Domain.Models;
using backend.Security.Domain.Repositories;
using backend.Shared.Persistence.Contexts;
using backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Security.Persistence.Repositories;

public class BusinessProfileRepository : BaseRepository, IBusinessProfileRepository
{
    public BusinessProfileRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Business>> ListAsync()
    {
        return await _context.Businesses.ToListAsync();

    }

    public async Task AddAsync(Business user)
    {
        await _context.Businesses.AddAsync(user);
    }

    public async Task<Business> FindByIdAsync(long id)
    {
        return await _context.Businesses.FindAsync(id);
    }

    public async Task<Business> FindByEmailAsync(string email)
    {
        return await _context.Businesses.SingleOrDefaultAsync(x => x.Email == email);
    }

    public bool ExistsByEmail(string email)
    {
        return _context.Businesses.Any(x => x.Email == email);
    }
    public Business FindById(long id)
    {
        return _context.Businesses.Find(id);
    }

    public void Update(Business user)
    {
        _context.Businesses.Update(user);
    }

    public void Remove(Business user)
    {
        _context.Businesses.Remove(user);
    }
}