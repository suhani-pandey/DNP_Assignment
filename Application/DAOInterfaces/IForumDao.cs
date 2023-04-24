using Domain;

namespace Application.DAOInterfaces;

public interface IForumDao
{
    Task<Forum> CreateForumAsync(Forum forumdto);
    Task<Forum?> GetForumById(int ForumId);
    Task<IEnumerable<Forum>> GetAllForumAsync(Forum forum);
    // Task<Comments> CreateComments(Comments comments);
}