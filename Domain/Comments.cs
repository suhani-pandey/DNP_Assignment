namespace Domain;

public class Comments
{
    public Comments(string? createdBy, string? message)
    {
        CreatedBy = createdBy;
        Message = message;
    }

    public string?  CreatedBy { get; set; }
    public string?  Message { get; set; }
    public DateOnly DateOnly { get; set; }
}