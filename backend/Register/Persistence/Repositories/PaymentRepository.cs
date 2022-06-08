using backend.Register.Persistence.Context;
using backend.Register.Persistence.Repositories;
using backend.RemodelKing.Domain.Models;
using backend.RemodelKing.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.RemodelKing.Persistence.Repositories;

public class PaymentRepository: BaseRepository, IPaymentRepository
{
    public PaymentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Payment>> ListAsync()
    {
        return await _context.Payments.ToListAsync();
    }

    public async Task AddAsync(Payment payment)
    {
        await _context.Payments.AddAsync(payment);
    }
}