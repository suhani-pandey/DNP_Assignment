namespace Domain.Dtos;

public class PostCreationDto
{
    public int OwnerId { get;  }
    public int ForumId { get; }
    public string  Title { get; set; }  
    public string Body { get; set; }

    public PostCreationDto(int ownerId, int forumId, string title, string body)
    {
        OwnerId = ownerId;
        ForumId = forumId;
        Title = title;
        Body = body;
    }
}