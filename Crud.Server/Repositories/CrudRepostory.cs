namespace Crud.Server.Repositories;

public interface ICrudRepository<T>
{

    Task<T> Save(T saveObject);
    ValueTask<T?> FindById(Guid id);

    Task<bool> DeleteById(Guid id);
}