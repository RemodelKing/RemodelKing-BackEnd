using backend.Register.Domain.Models;

namespace backend.Register.Domain.Repositories;

public interface IBusinessRepository
{
    Task<IEnumerable<Business>> ListAsync();
    Task<Business> FindByIdAsync(long id);
    Task AddAsync(Business business);
    //Task<Business> FindByNameAsync(string name);
}