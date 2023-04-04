using System.Net.Http.Json;
using System.Text.Json;
using Domain;
using HttpClient.ClientInterface;

namespace HTTPClient.Implementaion;

public class UserHttpClient:IUserService
{

    private readonly System.Net.Http.HttpClient client;

    public UserHttpClient(System.Net.Http.HttpClient client)
    {
        this.client = client;
    }


    public async Task<User> CreateUser(User user)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/User", user);
        string result = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        User users = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return users;
    }
}