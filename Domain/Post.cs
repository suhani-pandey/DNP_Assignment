namespace Domain;

public class Post
{
   
    public int postId { get; set; }
    public string  PostTitle { get; set; }
    public string  Body { get; set; }
    public User  CreatedBy { get;  }
    public Forum  BelongsToForum { get;  }

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