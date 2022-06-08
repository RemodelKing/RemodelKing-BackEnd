using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Register.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace backend.Register.Persistence.Repositories;

public class ClientRepository: BaseRepository, IClientRepository
{

    public ClientRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Client>> ListAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Client> FindByIdAsync(int id)
    {
        return await _context.Clients.FindAsync(id);
    }

    public async Task AddAsync(Client client)
    {
        await _context.Clients.AddAsync(client);
    }
    
}