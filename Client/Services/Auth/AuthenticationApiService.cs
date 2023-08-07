using System.Net;
using System.Security.Claims;
using Blazored.LocalStorage;
using Client.Services.Cloud;
using Client.Services.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SimWars.Shared.Common;

namespace SimWars.Services.Auth;

public class AuthenticationApiService : AuthenticationStateProvider, IAuthenticationApiService {
  private readonly ILocalStorageService _localStorage;
  private readonly NavigationManager _navigation;
  private IEnumerable<Claim>? _claims;

  private string? _token;
  private readonly LPI.CloudApi.Auth _authApi;
  private readonly LPI.CloudApi.User _userApi;
  private readonly LPI.CloudApi.Support _supportApi;
  private ClaimsIdentity? _identity;

  public AuthenticationApiService(ILocalStorageService localStorage, ICloudService cloudService, NavigationManager navigation) {
    _localStorage = localStorage;
    _navigation = navigation;
    _authApi = new LPI.CloudApi.Auth(cloudService.HttpService);
    _userApi = new LPI.CloudApi.User(cloudService.HttpService);
    _supportApi = new LPI.CloudApi.Support(cloudService.HttpService);
  }

  public string? Email { get; set; }

  public async Task Init() {
    _token = await GetCachedAuthTokenAsync();
    _claims = LPI.CloudApi.Auth.ParseClaimsFromJwt(_token);
    _identity = new ClaimsIdentity(_claims, "jwt");
  

  public Task<bool> HasValidAuthToken() {
    if (string.IsNullOrEmpty(_token) || _claims == null) {
      return Task.FromResult(false);
    }

    return Task.FromResult(!_authApi.HasTokenExpired(_identity));
  }

  public async Task<string> LastUsedEmail() {
    return await _localStorage.GetItemAsync<string>(StorageConstants.Email);
  }

  public async Task<HttpStatusCode> LoginAsync(string email, string password) {

    var resp = await _authApi.Login(email, password);
    if (resp.IsSuccessful && resp.Data != null) {
      await CacheAuthToken(email, resp.Data.Token);
      await Init();
      await GetAuthenticationStateAsync();
    }

    return resp.StatusCode;
  }

  public async Task<HttpStatusCode> ValidateAuthToken() {
    var resp = await _authApi.IsAuthorized();
    return resp.StatusCode;
  }

  public async Task LogoutAsync(bool shouldNavigate = true) {
    await ClearCacheAsync();
    _token = null;
    _claims = null;

    if (!shouldNavigate)
      return;

    NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

    _navigation.NavigateTo("/login");
  }

  public async Task<HttpStatusCode> RequestPasswordResetAsync(string email) {
    try {
      var resp = await _userApi.PasswordResetRequest(email);
      return resp.StatusCode;
    } catch {
      return HttpStatusCode.ServiceUnavailable;
    }
  }

  public async Task<string> RequestPasswordResetUrl(string email) {
    try {
      var resp = await _supportApi.UserPasswordResetUrl(email);
      return resp.Data ?? string.Empty;
    } catch {
      // ignore
    }

    return "";
  }

  public async Task<HttpStatusCode> ResetPasswordAsync(string token, string password) {
    try {
      var resp = await _userApi.ResetPassword(token, password);
      return resp.StatusCode;
    } catch {
      return HttpStatusCode.ServiceUnavailable;
    }
  }

  public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
    var token = await GetCachedAuthTokenAsync();

    _identity = new ClaimsIdentity();
    _authApi.HttpComms.SetBearerToken(null);

    // Generate claimsIdentity from cached token
    if (!string.IsNullOrEmpty(token)) {
      _identity = new ClaimsIdentity(LPI.CloudApi.Auth.ParseClaimsFromJwt(token), "jwt");
      _authApi.HttpComms.SetBearerToken(token.Replace("\"", ""));
    }

    if (!CloudApi.RequestSuccessful(await ValidateAuthToken())) {
      await ClearCacheAsync();
      _identity = new ClaimsIdentity();
    }

    var user = new ClaimsPrincipal(_identity);
    var state = new AuthenticationState(user);

    NotifyAuthenticationStateChanged(Task.FromResult(state));
    return state;
  }

  private async Task CacheAuthToken(string? email, string? token) {
    await _localStorage.SetItemAsync(StorageConstants.Email, email);
    await _localStorage.SetItemAsync(StorageConstants.AuthToken, token);
  }

  private async Task ClearCacheAsync() {
    await _localStorage.RemoveItemAsync(StorageConstants.AuthToken);
  }

  private ValueTask<string> GetCachedAuthTokenAsync() {
    return _localStorage.GetItemAsync<string>(StorageConstants.AuthToken);
  }
}