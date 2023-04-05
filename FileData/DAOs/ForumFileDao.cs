using Application.DAOInterfaces;
using Domain;

namespace FileData.DAOs;

public class ForumFileDao: IForumDao
{

    private readonly FileContext context;

    public ForumFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Forum> CreateForumAsync(Forum forumdto)
    {
        
        int id = 1;
        if (context.Forums.Any())
        {
            id = context.Forums.Max(f => f.Id);
            id++;
        }
        forumdto.Id = id;
        context.Forums.Add(forumdto);
        context.SaveChanges();

        return Task.FromResult(forumdto);
    }

    public Task<Forum?> GetForumById(int ForumId)
    {
        Forum? existing = context.Forums.FirstOrDefault(u => u.Id == ForumId);
        return Task.FromResult(existing);
    }
}