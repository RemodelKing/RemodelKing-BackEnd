using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Register.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace backend.Register.Persistence.Repositories;

public class RequestRepository : BaseRepository, IRequestRepository
{
    public RequestRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Request>> ListAsync()
    {
        return await _context.Requests.ToListAsync();
    }

    public async Task<Request> FindByIdAsync(int id)
    {
        return await _context.Requests.FindAsync(id);
    }

    public async Task AddAsync(Request request)
    {
        await _context.Requests.AddAsync(request);
    }
}