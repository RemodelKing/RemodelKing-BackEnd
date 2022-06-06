namespace backend.Register.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}