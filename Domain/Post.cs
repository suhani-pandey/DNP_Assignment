namespace Domain;

public class Post
{
    public int OwnerId { get;  }
    public int ForumId { get; set; }
    public int postId { get; set; }
    public string  PostTitle { get; set; }
    public string  Body { get; set; }
    public User  CreatedBy { get; set; }
    public Forum  BelongsToForum { get; set; }

    public Post()
    {
    }

    public Post(Forum belongsToForum,User user, string postTitle,string description)
    {
        PostTitle = postTitle;
        BelongsToForum = belongsToForum;
        CreatedBy = user;
        Body = description;
    }
}