using Microsoft.AspNetCore.Components.Authorization;
using OpenEvaluation.Data;
using OpenEvaluation.Helpers;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.ProtectedBrowserStorage;

namespace OpenEvaluation.Service
{
    public class AuthenticationService : AuthenticationStateProvider
    {
        private readonly EvaluateContext _db;
        private readonly ProtectedSessionStorage _storage;

        public AuthenticationService(EvaluateContext dbContext, ProtectedSessionStorage storage)
        {
            _db = dbContext;
            _storage = storage;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var uId = await _storage.GetAsync<string>("UserId");
            var name = await _storage.GetAsync<string>("Name");
            var role = await _storage.GetAsync<string>("Role");

            ClaimsIdentity identity;

            if (string.IsNullOrWhiteSpace(uId) || string.IsNullOrWhiteSpace(role) || string.IsNullOrWhiteSpace(name))
            {
                identity = new ClaimsIdentity(); // No auth in session storage
            }
            else
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim("UserId", uId),
                    new Claim(ClaimTypes.Role,role),
                    new Claim(ClaimTypes.Name,name), 
                }, "Session");
            }

            var claims = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(claims));
        }

        public void Login(string userId, string password)
        {

            var user = _db.Users.FirstOrDefault(u => u.UserId == userId && u.Password == Md5.GetMd5(userId + password));
            if (user != null)
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim("UserId", user.UserId),
                    new Claim(ClaimTypes.Role,user.Role.ToString()),
                    new Claim(ClaimTypes.Name,user.Name),
                }, "Session");

                _storage.SetAsync("UserId", user.UserId);
                _storage.SetAsync("Name", user.Name);
                _storage.SetAsync("Role", user.Role.ToString());

                var claims = new ClaimsPrincipal(identity);

                NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claims)));
            }

        }

        public void Logout()
        {
            _storage.DeleteAsync("UserId");
            _storage.DeleteAsync("Name");
            _storage.DeleteAsync("Role");

            var identity = new ClaimsIdentity();
            var claims = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claims)));
        }
    }
}
