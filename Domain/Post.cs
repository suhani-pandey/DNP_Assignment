namespace Domain;

public class Post
{
    public string  PostTitle { get; set; }
    public string  Body { get; set; }
    public DateTime DateTime { get; set; }
    public string  CreatedBy { get; set; }

    public Post()
    {
    }

    public Post(string postTitle, string body, DateTime dateTime, string createdBy)
    {
        PostTitle = postTitle;
        Body = body;
        DateTime = dateTime;
        CreatedBy = createdBy;
    }
}