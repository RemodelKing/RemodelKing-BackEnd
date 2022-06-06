using backend.Register.Domain.Repositories;
using backend.Register.Persistence.Context;

namespace backend.Register.Persistence.Repositories;

public class UnitOfWorkRepository: IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWorkRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}