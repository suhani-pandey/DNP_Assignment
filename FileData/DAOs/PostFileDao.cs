using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Domain;

namespace FileData.DAOs;

public class PostFileDao:IPostDao
{
    private readonly FileContext fileContext;

    public PostFileDao(FileContext fileContext)
    {
        this.fileContext = fileContext;
    }

    public Task<Post> CreatePostAsync(Post post)
    {
        int id = 1;
        if (fileContext.Posts.Any())
        {
            id = fileContext.Posts.Max(f => f.postId);
            id++;
        }
        post.postId = id;
        fileContext.Posts.Add(post);
        fileContext.SaveChanges();

        return Task.FromResult(post);
    }
}