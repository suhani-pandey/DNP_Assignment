using Domain;
using Domain.Dtos;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreatePostAsync(PostCreationDto post);
}