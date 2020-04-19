using System;
using Microsoft.AspNetCore.Components.Authorization;
using OpenEvaluation.Data;
using OpenEvaluation.Helpers;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.ProtectedBrowserStorage;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;

namespace OpenEvaluation.Service
{
    public class AuthenticationService : AuthenticationStateProvider
    {
        private readonly EvaluateContext _db;
        private readonly ProtectedSessionStorage _storage;
        private readonly IToastService _toastService;
        private readonly NavigationManager _navigation;

        public AuthenticationService(EvaluateContext dbContext, ProtectedSessionStorage storage, IToastService toastService, NavigationManager navigation)
        {
            _db = dbContext;
            _storage = storage;
            _toastService = toastService;
            _navigation = navigation;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var uId = await _storage.GetAsync<string>("UserId");
            var name = await _storage.GetAsync<string>("Name");
            var role = await _storage.GetAsync<string>("Role");
            var expireTime = await _storage.GetAsync<DateTime>("ExpireTime");

            ClaimsIdentity identity;

            if (string.IsNullOrWhiteSpace(uId) || string.IsNullOrWhiteSpace(role) || string.IsNullOrWhiteSpace(name) || expireTime < DateTime.Now)
            {
                identity = new ClaimsIdentity(); // No auth in session storage
            }
            else
            {
                _ = _storage.SetAsync("ExpireTime", DateTime.Now.AddHours(5));
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
            User user;
            if (userId == password)
            {
                user = _db.Users.SingleOrDefault(u => u.UserId == userId && string.IsNullOrEmpty(u.Password));
            }
            else
            {
                user = _db.Users.SingleOrDefault(u => u.UserId == userId && u.Password == Md5.GetMd5(userId + password));
            }
            if (user != null)
            {
                ClaimsIdentity identity;
                if (string.IsNullOrEmpty(user.Password))
                {
                    identity = new ClaimsIdentity(new[]
                    {
                        new Claim("UserId", user.UserId),
                        new Claim(ClaimTypes.Role,"NewUser"),
                        new Claim(ClaimTypes.Name,user.Name),
                    }, "NewUser");

                    _storage.SetAsync("UserId", user.UserId);
                    _storage.SetAsync("Name", user.Name);
                    _storage.SetAsync("Role", "NewUser");
                    _storage.SetAsync("ExpireTime", DateTime.Now.AddHours(5));
                }
                else
                {
                    identity = new ClaimsIdentity(new[]
                    {
                        new Claim("UserId", user.UserId),
                        new Claim(ClaimTypes.Role,user.Role.ToString()),
                        new Claim(ClaimTypes.Name,user.Name),
                    }, "Login Page");

                    _storage.SetAsync("UserId", user.UserId);
                    _storage.SetAsync("Name", user.Name);
                    _storage.SetAsync("Role", user.Role.ToString());
                    _storage.SetAsync("ExpireTime", DateTime.Now.AddHours(5));
                }

                var claims = new ClaimsPrincipal(identity);

                if (identity.FindFirst(ClaimTypes.Role).Value == "NewUser")
                {
                    _navigation.NavigateTo("/initpasswd", true);
                }

                NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claims)));
            }
            else
            {
                _toastService.ShowError("Incorrect username or password", "Login failed");
            }

        }

        public void Logout()
        {
            _storage.DeleteAsync("UserId");
            _storage.DeleteAsync("Name");
            _storage.DeleteAsync("Role");
            _storage.DeleteAsync("ExpireTime");

            var identity = new ClaimsIdentity();
            var claims = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claims)));
        }
    }
}
