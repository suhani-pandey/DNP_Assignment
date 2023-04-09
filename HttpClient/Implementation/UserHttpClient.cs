using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Domain;
using Domain.Dtos;
using HttpClient.ClientInterface;

namespace HTTPClient.Implementation;

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
    
    
    public async Task<IEnumerable<User>> GetUsers(int id)
    {
        HttpResponseMessage responseMessage = await client.GetAsync($"User/{id}");
        string result = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        IEnumerable<User> users = JsonSerializer.Deserialize<IEnumerable<User>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        // Console.WriteLine("--------------test---------------------");
        return users;
    }
    
    public static string? Jwt { get; private set; } = "";

     public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; } = null!;
    
    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        string payload = jwt.Split('.')[1];
        byte[] jsonBytes = ParseBase64WithoutPadding(payload);
        Dictionary<string, object>? keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuePairs!.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!));
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2:
                base64 += "==";
                break;
            case 3:
                base64 += "=";
                break;
        }

        return Convert.FromBase64String(base64);
    }
    
    private static ClaimsPrincipal CreateClaimsPrincipal()
    {
        if (string.IsNullOrEmpty(Jwt))
        {
            return new ClaimsPrincipal();
        }
    
        IEnumerable<Claim> claims = ParseClaimsFromJwt(Jwt);
    
        ClaimsIdentity identity = new(claims, "jwt");
    
        ClaimsPrincipal principal = new(identity);
        return principal;
    }
    
    
    
    public async Task LoginAsync(string username, string password)
    {
        UserLoginDtos userLoginDto = new()
        {
            Username = username,
            Password = password
        };

        HttpResponseMessage response = await client.PostAsJsonAsync("user/login", userLoginDto);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }

        string token = responseContent;
        Jwt = token;

        ClaimsPrincipal principal = CreateClaimsPrincipal();

        OnAuthStateChanged.Invoke(principal);
    }

    public Task LogoutAsync()
    {
        Jwt = null;
        ClaimsPrincipal principal = new();
        OnAuthStateChanged.Invoke(principal);
        return Task.CompletedTask;
    }

    // public async Task RegisterAsync(User user)
    // {
    //     string userAsJson = JsonSerializer.Serialize(user);
    //     StringContent content = new(userAsJson, Encoding.UTF8, "application/json");
    //     HttpResponseMessage response = await client.PostAsync("https://localhost:7130/user/register", content);
    //     string responseContent = await response.Content.ReadAsStringAsync();
    //
    //     if (!response.IsSuccessStatusCode)
    //     {
    //         throw new Exception(responseContent);
    //     }
    // }

    public Task<ClaimsPrincipal> GetAuthAsync()
    {
        ClaimsPrincipal principal = CreateClaimsPrincipal();
        return Task.FromResult(principal);
    }
    

}