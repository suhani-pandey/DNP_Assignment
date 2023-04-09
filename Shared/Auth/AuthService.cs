using System.ComponentModel.DataAnnotations;
using Application.DAOInterfaces;
using Domain;

namespace Shared.Auth;

public class AuthService : IAuthService
{
    private readonly IUserDAO userDao;


    // public Task<User> ValidateUser(string username, string password)
    // {
    //     // IEnumerable<User> allUsers = userDao.GetAllUsernamesAsync();
    //     // User? existingUser = allUsers.FirstOrDefault(user => user.username.Equals(username,StringComparison.OrdinalIgnoreCase));
    //     //
    //     // if (existingUser == null)
    //     // {
    //     //     throw new Exception("User not found");
    //     // }
    //     //
    //     // if (!existingUser.password.Equals(password))
    //     // {
    //     //     throw new Exception("Password mismatch");
    //     // }
    //
    //     // return Task.FromResult(existingUser);
    // }

    public Task RegisterUser(User user)
    {
        if (string.IsNullOrEmpty(user.username))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.password))
        {
            throw new ValidationException("Password cannot be null");
        }
        // Do more user info validation here

        // save to persistence instead of list

        userDao.CreateAsync(user);

        return Task.CompletedTask;
    }
}