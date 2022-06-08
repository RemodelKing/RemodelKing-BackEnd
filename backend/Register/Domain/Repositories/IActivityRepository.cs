using backend.Register.Domain.Models;

namespace backend.Register.Domain.Repositories;

public interface IActivityRepository
{
    Task<IEnumerable<Activity>> ListAsync();
    Task<Activity> FindByIdAsync(int id);
    Task AddAsync(Activity activity);
}