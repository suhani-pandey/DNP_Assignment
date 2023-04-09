using Domain;

namespace HttpClient.ClientInterface;

public interface IForumService
{
    Task CreateForum(Forum forum);
    Task<IEnumerable<Forum>> GetForums();
    Task<Forum> GetForumById(int forumId);
}