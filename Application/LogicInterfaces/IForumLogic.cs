using Domain;

namespace Application.LogicInterfaces;

public interface IForumLogic
{
    Task<Forum> CreateForumAsync(Forum forumdto);
}