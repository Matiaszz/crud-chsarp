namespace Crud.Server.Repositories;

public interface ICrudRepository<T>
{

    Task<T> Save(Guid id, T saveObject);
    ValueTask<T?> FindById(Guid id);

    Task<bool> DeleteById(Guid id);
}