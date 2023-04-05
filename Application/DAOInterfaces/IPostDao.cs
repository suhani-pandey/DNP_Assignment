using Domain;

namespace Application.DAOInterfaces;

public interface IPostDao
{
    Task<Post> CreatePostAsync(Post post);
}