using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Todo.Domain.Entities;
using Todo.Domain.Interfaces;
using Todo.Infra.Data.Context;

namespace Todo.Infra.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _context.Users.FirstAsync(x=> x.Id == id);
    }

    public async Task<User> GetUserByNameAsync(string name)
    {
        return await _context.Users.FirstAsync(x => x.Name == name);
    }

    public async Task<User> CreateUserAsync(User user)
    {
        try { 
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }catch(DbException ex) 
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }
    public async Task<User> DeleteUserAsync(User user)
    {
  
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return user;
    }
}
