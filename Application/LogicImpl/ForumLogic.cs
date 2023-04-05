using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Domain;

namespace Application.LogicImpl;

public class ForumLogic : IForumLogic
{

    private readonly IForumDao forumDao;

    public ForumLogic(IForumDao forumDao)
    {
        this.forumDao = forumDao;
    }

    public async Task<Forum> CreateForumAsync(Forum forumdto)
    {
        ValidateData(forumdto);
        Forum forum = new Forum(forumdto.Title, forumdto.Description);
        Forum created = await forumDao.CreateForumAsync(forum);
        return created;
    }

    private void ValidateData(Forum forumdto)
    {
        if (string.IsNullOrEmpty(forumdto.Title)) throw new Exception("Title cannot be empty");
        if (string.IsNullOrEmpty(forumdto.Description)) throw new Exception("Description cannot be empty");
    }
}