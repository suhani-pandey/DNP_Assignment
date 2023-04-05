using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Domain;

namespace Application.LogicImpl;

public class PostLogic:IPostLogic
{

    private readonly IPostDao postDao;
    private readonly IUserDAO userDao;
    private readonly IForumDao forumDao;

    public PostLogic(IPostDao postDao, IUserDAO userDao, IForumDao forumDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
        this.forumDao = forumDao;
    }

    public async Task<Post> CreatePostAsync(Post postDto)
    {
        User? user = await userDao.GetUserById(postDto.OwnerId);
        if (user==new User())
        {
            throw new Exception($"User with id{postDto.OwnerId} was not found");
        }

        Forum? forum = await forumDao.GetForumById(postDto.ForumId);
        if (forum==null)
        {
            throw new Exception($"Forum with id{postDto.ForumId} was not found");
        }
        
        ValidateData(postDto);
        Post created = new Post(forum,user, postDto.PostTitle,postDto.Body);
        Post existing= await postDao.CreatePostAsync(created);
        return existing;
    }

    private void ValidateData(Post post)
    {
        if (string.IsNullOrEmpty(post.PostTitle)) throw new Exception("Title field should not be empty");
        if (string.IsNullOrEmpty(post.Body)) throw new Exception("Description shouldnt be empty");
       
    }
}