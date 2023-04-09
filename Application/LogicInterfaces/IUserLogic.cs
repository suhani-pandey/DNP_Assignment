using Domain;
using Domain.Dtos;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(User userToCreate);
    Task<User> ValidateUser(UserLoginDtos userDto);
    Task<User> GetByIdAsync(int userId);
}