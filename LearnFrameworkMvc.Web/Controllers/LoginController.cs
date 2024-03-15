using LearnFrameworkMvc.Module.Helpers;
using LearnFrameworkMvc.Module.Models.Login;
using LearnFrameworkMvc.Module.Services;
using LearnFrameworkMvc.Web.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace LearnFrameworkMvc.Web.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IPermissionService _permissionService;

        public LoginController(ILogger<LoginController> logger, IPermissionService permissionService)
        {
            _logger = logger;
            _permissionService = permissionService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var claimEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            if (claimEmail != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return PartialView();
        }

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Authenticate(LoginModel model)
		{
            var user = await _permissionService.IsAuthenticate(model);
            if (user == null)
            {
                return Redirect("/Login");
            }


            var claims = new List<Claim>
            {
                new(ClaimTypes.Email, user.Email),
                new("FullName", user.Fullname),
                new(ClaimTypes.Role, user.Roles)
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = model.RememberMe,
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);


            if (!string.IsNullOrEmpty(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
