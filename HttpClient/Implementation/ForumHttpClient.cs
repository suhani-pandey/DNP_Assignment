using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Domain;
using HttpClient.ClientInterface;

namespace HTTPClient.Implementation;

public class ForumHttpClient: IForumService
{

    private readonly System.Net.Http.HttpClient httpClient;

    public ForumHttpClient(System.Net.Http.HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task CreateForum(Forum forum)
    {
        HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("/Forum", forum);

        if (!responseMessage.IsSuccessStatusCode)
        {
            string result = await responseMessage.Content.ReadAsStringAsync();
            throw new Exception(result);
        }

    }

    public async Task<IEnumerable<Forum>> GetForums()
    {
        HttpResponseMessage responseMessage = await httpClient.GetAsync("/Forum");
        string result = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        ICollection<Forum> forum = JsonSerializer.Deserialize<ICollection<Forum>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return forum;
    }

    public async Task<Forum> GetForumById(int forumId)
    {
        HttpResponseMessage responseMessage = await httpClient.GetAsync($"/Forum/{forumId}");
        string result = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        Forum forum = JsonSerializer.Deserialize<Forum>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return forum;
    }
}