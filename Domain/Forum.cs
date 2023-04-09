﻿namespace Domain;

public class Forum
{
    public int Id { get; set; }
    public string  Title { get; set; }
    public string  Description { get; set; }
     public  string? CreatedOn { get; set; }
    

     public Forum(string title, string description)
     {
         Title = title;
         Description = description;
     }
     
}