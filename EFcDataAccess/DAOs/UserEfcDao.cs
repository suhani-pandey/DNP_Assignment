using Application.DAOInterfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFcDataAccess.DAOs;

public class UserEfcDao: IUserDAO

{
    private readonly ForumContext context;

    public UserEfcDao(ForumContext context)
    {
        this.context = context;
    }

    public async Task<User> CreateAsync(User user)
    {
        EntityEntry<User> userToCreate = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return userToCreate.Entity;
    }

    // public async Task<User> GetUserByUsernameandPassword(string userName, string password)
    // {
    //     User? user = await context.Users.FirstOrDefaultAsync(u =>
    //         u.username.Equals(userName) && u.password.Equals(password));
    //     if (user is null )
    //     {
    //         throw new Exception("Cannot find the user");
    //     }
    //     return user;
    // }

    public async Task<User?> GetUserById(int OwnerId)
    {
        User? user = await context.Users.FindAsync(OwnerId);
        if (user!=null)
        {
            throw new Exception($"user with id {OwnerId} is not found");
        }
        return user;
    }

    public async Task<IEnumerable<User?>> GetAllUsersAsync()
    {
        IQueryable<User> getAllUsers = context.Users.AsQueryable();
        IEnumerable<User> result = await getAllUsers.ToListAsync();
        return result;
    }
}