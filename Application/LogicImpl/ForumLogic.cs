using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.Dtos;

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
        Forum forum = new Forum(forumdto.Title, forumdto.Description,forumdto.CreatedBy);
        Forum created = await forumDao.CreateForumAsync(forum);
        return created;
    }
    
    // public async Task PostComments(Comments comments)
    // {
    //     Comments createComment = new Comments(comments.CreatedBy,comments.Message);
    //     Comments created = await forumDao.CreateComments(comments);
    //
    // }

    public async Task<IEnumerable<Forum>> GetAllForumAsync(Forum forum)
    {
        IEnumerable<Forum> GetAllForum = await forumDao.GetAllForumAsync(forum);
        return GetAllForum;
    }
    
    public async Task<Forum> GetByIdAsync(int forumId)
    {
         Forum? forum=  await forumDao.GetForumById(forumId);
             if (forum == null)
             {
                 throw new Exception($"Forum with {forumId} was not found");
             }
        
             return forum;
    }

    


    private void ValidateData(Forum forumdto)
    {
        if (string.IsNullOrEmpty(forumdto.Title)) throw new Exception("Title cannot be empty");
        if (string.IsNullOrEmpty(forumdto.Description)) throw new Exception("Description cannot be empty");
    }
}