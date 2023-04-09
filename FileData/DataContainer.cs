using Domain;

namespace FileData;

public class DataContainer
{
    public ICollection<User> Users { get; set; }
    public ICollection<Forum> Forums { get; set; }
    
}