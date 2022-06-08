using backend.Register.Domain.Models;

namespace backend.Register.Domain.Repositories;

public interface IRequestRepository
{
    Task<IEnumerable<Request>> ListAsync();
    Task<Request> FindByIdAsync(int id);
    Task AddAsync(Request request);
}