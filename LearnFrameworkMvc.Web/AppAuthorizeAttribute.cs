using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using LearnFrameworkMvc.Module.Services;
using System.Security.Claims;

namespace LearnFrameworkMvc.Web
{
    public class AppAuthorizeAttribute : TypeFilterAttribute
    {
        public AppAuthorizeAttribute(params string[] permissions) : base(typeof(AuthorizeActionFilterAttribute))
        {
            Arguments = new object[] { permissions };
        }
    }

    public class AuthorizeActionFilterAttribute : Attribute, IAuthorizationFilter
    {
        public string[] Permissions { get; }

        private readonly IPermissionService _permissionService;

        public AuthorizeActionFilterAttribute(IPermissionService permissionService, params string[] permissions)
        {
            _permissionService = permissionService;
            Permissions = permissions;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string? claimId = context.HttpContext.User.FindFirst("Id")?.Value;
            if (string.IsNullOrEmpty(claimId))
            {
                context.Result = new ForbidResult();
            }

            var hasPermission = _permissionService.HasPermission(claimId!, Permissions[0]);
            if (!hasPermission)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
