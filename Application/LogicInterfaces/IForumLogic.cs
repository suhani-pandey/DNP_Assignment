using Domain;
using Domain.Dtos;

namespace Application.LogicInterfaces;

public interface IForumLogic
{
    Task<Forum> CreateForumAsync(Forum forumdto);
    Task<IEnumerable<Forum>> GetAllForumAsync(Forum forum);
    Task<Forum> GetByIdAsync(int forumId);
    // Task<Forum> GetDescriptionByID(int forumId);
    // Task PostComments(Comments comments);
}