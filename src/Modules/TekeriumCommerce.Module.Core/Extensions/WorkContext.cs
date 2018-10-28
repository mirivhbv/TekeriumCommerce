using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TekeriumCommerce.Infrastructure;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Module.Core.Models;

namespace TekeriumCommerce.Module.Core.Extensions
{
    public class WorkContext : IWorkContext
    {
        private const string UserGuidCookiesName = "TekeriumUserGuid";
        private const long GuestRoleId = 3;

        private User _currentUser;
        private readonly UserManager<User> _userManager;
        private readonly HttpContext _httpContext;
        private readonly IRepository<User> _userRepository;

        public WorkContext(UserManager<User> userManager, IHttpContextAccessor contextAccessor, IRepository<User> userRepository)
        {
            _userManager = userManager;
            _httpContext = contextAccessor.HttpContext;
            _userRepository = userRepository;
        }

        public async Task<User> GetCurrentUser()
        {
            if (_currentUser != null)
            {
                return _currentUser;
            }

            var contextUser = _httpContext.User;
            _currentUser = await _userManager.GetUserAsync(contextUser);

            if (_currentUser != null)
            {
                return _currentUser;
            }

            var userGuid = GetUserFromCookies();
            if (userGuid.HasValue)
            {
                _currentUser = _userRepository.Query().Include(x => x.Roles)
                    .FirstOrDefault(x => x.UserGuid == userGuid);
            }

            if (_currentUser != null && _currentUser.Roles.Count == 1 &&
                _currentUser.Roles.First().RoleId == GuestRoleId)
            {
                return _currentUser;
            }

            userGuid = Guid.NewGuid();
            var dummyEmail = string.Format("{0}@guest.tekerium.com", userGuid);
            _currentUser = new User
            {
                FullName = "Guest",
                UserGuid = userGuid.Value,
                Email = dummyEmail,
                UserName = dummyEmail,
                Culture = GlobalConfiguration.DefaultCulture
            };

            var abc = await _userManager.CreateAsync(_currentUser, "fullILlop2");
            await _userManager.AddToRoleAsync(_currentUser, "guest");
            SetUserGuidCookies(_currentUser.UserGuid);
            return _currentUser;
        }

        private Guid? GetUserFromCookies()
        {
            if (_httpContext.Request.Cookies.ContainsKey(UserGuidCookiesName))
            {
                return Guid.Parse(_httpContext.Request.Cookies[UserGuidCookiesName]);
            }

            return null;
        }

        private void SetUserGuidCookies(Guid userGuid)
        {
            _httpContext.Response.Cookies.Append(UserGuidCookiesName, _currentUser.UserGuid.ToString(),
                new CookieOptions
                {
                    Expires = DateTime.UtcNow.AddYears(5),
                    HttpOnly = true,
                    IsEssential = true
                });
        }
    }
}