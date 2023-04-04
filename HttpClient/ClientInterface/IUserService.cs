using Domain;

namespace HttpClient.ClientInterface;

public interface IUserService
{
    Task<User> CreateUser(User user);
}