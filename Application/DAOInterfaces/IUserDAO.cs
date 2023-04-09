using Domain;

namespace Application.DAOInterfaces;

public interface IUserDAO
{
    Task<User> CreateAsync(User user);
    Task<User> GetUserByUsernameandPassword(string userName,string password,string rePassword);
    Task<User?> GetUserById(int OwnerId);
    //IEnumerable<User> GetAllUsernamesAsync();
    Task<IEnumerable<User?>> GetAllUsersAsync();

}