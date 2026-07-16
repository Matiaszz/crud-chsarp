using Crud.Server.Models;
using Crud.Server.Repositories;

namespace Crud.Server.Repositories.Entities;

public interface IUserRepository : ICrudRepository<User>
{
}