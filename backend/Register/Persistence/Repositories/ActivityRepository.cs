using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Register.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace backend.Register.Persistence.Repositories;

public class ActivityRepository: BaseRepository, IActivityRepository
{

    public ActivityRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Activity>> ListAsync()
    {
        return await _context.Activities.ToListAsync();
    }

    public async Task<Activity> FindByIdAsync(int id)
    {
        return await _context.Activities.FindAsync(id);
    }

    public async Task AddAsync(Activity activity)
    {
        await _context.Activities.AddAsync(activity);
    }
    
}