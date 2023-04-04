namespace Domain;

public class Forum
{
    public string  Title { get; set; }
    public string  Description { get; set; }
    public DateTime  DateTime { get; set; }

    public Forum()
    {
    }

    public Forum(string title, string description, DateTime dateTime)
    {
        Title = title;
        Description = description;
        DateTime = dateTime;
    }
}