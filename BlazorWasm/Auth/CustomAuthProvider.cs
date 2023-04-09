using System.Security.Claims;
// using BlazorWasm.Services;
using HttpClient.ClientInterface;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorWasm.Auth;

public class CustomAuthProvider : AuthenticationStateProvider
{
    
    private readonly IUserService userService;

    public CustomAuthProvider(IUserService userService)
    {
        this.userService = userService;
         userService.OnAuthStateChanged += AuthStateChanged;
    }
    
    private void AuthStateChanged(ClaimsPrincipal principal)
    {
        NotifyAuthenticationStateChanged(
            Task.FromResult(
                new AuthenticationState(principal)
            )
        );
    }
    
    
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsPrincipal principal = await userService.GetAuthAsync();
        
        return new AuthenticationState(principal);
    }
}