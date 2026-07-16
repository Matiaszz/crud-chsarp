using Crud.Server.Data;
using Crud.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.Server.Repositories.Entities.Impl;

public class UserRepository(AppDbContext context) : IUserRepository
{
    private readonly AppDbContext _context = context;

    public async Task<User> Save(User user)
    {
        UsersSet().Add(user);
        await Commit();
        return user;
    }

    public async ValueTask<User?> FindById(Guid id) => await UsersSet().FindAsync(id);

    public async Task<bool> DeleteById(Guid id)
    {
        var user = await FindById(id);
        if (user is null) return false;

        UsersSet().Remove(user);
        await Commit();

        return true;
    }


    private DbSet<User> UsersSet() => _context.Users;
    private Task<int> Commit() => _context.SaveChangesAsync();
}