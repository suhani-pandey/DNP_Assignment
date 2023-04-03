using Domain;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(User userToCreate);
}