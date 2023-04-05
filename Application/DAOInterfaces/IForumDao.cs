using Domain;

namespace Application.DAOInterfaces;

public interface IForumDao
{
    Task<Forum> CreateForumAsync(Forum forumdto);
    Task<Forum?> GetForumById(int ForumId);
}