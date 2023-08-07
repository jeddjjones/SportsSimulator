using System.Net;

namespace SimWars.Services.Auth;
public interface IAuthenticationApiService {
  Task Init();
  Task<HttpStatusCode> LoginAsync(string email, string password);
  Task<HttpStatusCode> ValidateAuthToken();
  Task LogoutAsync(bool shouldNavigate = true);
  Task<bool> HasValidAuthToken();
  Task<string> LastUsedEmail();
  Task<HttpStatusCode> RequestPasswordResetAsync(string email);
  Task<string> RequestPasswordResetUrl(string email);
  Task<HttpStatusCode> ResetPasswordAsync(string token, string password);
}