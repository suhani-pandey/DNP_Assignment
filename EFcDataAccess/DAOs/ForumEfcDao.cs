using Application.DAOInterfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFcDataAccess.DAOs;

public class ForumEfcDao : IForumDao
{
    private readonly ForumContext context;

    public ForumEfcDao(ForumContext context)
    {
        this.context = context;
    }

    public async Task<Forum> CreateForumAsync(Forum forumdto)
    {
        EntityEntry<Forum> forumToCreate = await context.Forums.AddAsync(forumdto);
        forumdto.CreatedOn = DateTime.Now.ToString("f");
        await context.SaveChangesAsync();
        return forumToCreate.Entity;
    }

    public async Task<Forum?> GetForumById(int forumId)
    {
        Forum? getForumById = await context.Forums.FindAsync(forumId);
        return getForumById;
    }

    public async Task<IEnumerable<Forum>> GetAllForumAsync(Forum forum)
    {
        IQueryable<Forum> getAllForum =context.Forums.AsQueryable();
        if (forum.Title!=null)
        {
            getAllForum = getAllForum.Where(f => f.Title.ToLower().Equals(forum.Title));
        }

        IEnumerable<Forum> result = await getAllForum.ToListAsync();
        return result;
    }
}