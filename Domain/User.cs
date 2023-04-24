using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain;

public class User
{
    public int id { get; set; }
    public string  username { get; set; }
    public string  password { get; set; }
    public string  rePassword { get; set; }
    
    [JsonIgnore]
    public ICollection<Forum>? Forums { get; set; }

    public User()
    {
    }

    public User(string username, string password,string rePassword)
    {
        this.username = username;
        this.password = password;
        this.rePassword = rePassword;
    }

    public User(string username)
    {
        this.username = username;
    }
}