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
        forumdto.CreatedOn = DateTime.Now.ToString("dddd , MMM dd yyyy,hh:mm");
        context.Forums.Add(forumdto);
        context.SaveChanges();

        return Task.FromResult(forumdto);
    }

    public Task<Forum?> GetForumById(int ForumId)
    {
        Forum? existing = context.Forums.FirstOrDefault(u => u.Id == ForumId);
        return Task.FromResult(existing);
    }

    public Task<IEnumerable<Forum>> GetAllForumAsync(Forum forum)
    {
        IEnumerable<Forum> forums = context.Forums.AsEnumerable();
        if (forum.Title!=null)
        {
            forums = context.Forums.Where(u =>
                u.Title.Contains(forum.Title, StringComparison.OrdinalIgnoreCase) & u.Description.Contains(forum.Description));
        }

        return Task.FromResult(forums);
    }
}