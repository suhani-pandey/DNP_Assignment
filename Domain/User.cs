namespace Domain;

public class User
{
    public int id { get; set; }
    public string  username { get; set; }
    public string  password { get; set; }
    public string  rePassword { get; set; }

    public User()
    {
    }

    public User(string username, string password,string rePassword)
    {
        this.username = username;
        this.password = password;
        this.rePassword = rePassword;
    }
}