using System.Security.Claims;
using Domain;

namespace HttpClient.ClientInterface;

public interface IUserService
{
    Task<User> CreateUser(User user);
    Task<IEnumerable<User>> GetUsers(int id);
    public Task LoginAsync(string username, string password);
    public Task LogoutAsync();
    // public Task RegisterAsync(User user);
    public Task<ClaimsPrincipal> GetAuthAsync();
    
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
}