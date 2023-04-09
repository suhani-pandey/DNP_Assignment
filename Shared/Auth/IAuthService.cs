using Domain;

namespace Shared.Auth;

public interface IAuthService
{
    // Task<User> ValidateUser(string username, string password);
    Task RegisterUser(User user);
}