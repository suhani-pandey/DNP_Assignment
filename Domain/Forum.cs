using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Forum
{
    [Key]
    public int Id { get; set; }
    public string?  Title { get; set; }
    public string?  Description { get; set; }
     public  string? CreatedOn { get; set; }
     public string? CreatedBy { get; set; }
    

    
     public Forum(string title, string description,string? createdBy)
     {
         Title = title;
         Description = description;
         CreatedBy = createdBy;
     }

     public Forum()
     {
     }
}