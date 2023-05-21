namespace AuthPermission.PermissionManage
{
    public class MustHavePermissionAttribute : AuthorizeAttribute
    {
        private readonly string _action;
        private readonly string _resource;
        private readonly UserManager<AppUser> _userManager;

        public MustHavePermissionAttribute(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public MustHavePermissionAttribute(string action, string resource)
        {
            _action = action;
            _resource = resource;
        }

        //public void OnAuthorization(AuthorizationFilterContext context)
        //{
        //    var user = _userManager.GetUserAsync(context.HttpContext.User).Result;

        //    if (user == null)
        //    {
        //        context.Result = new UnauthorizedResult();
        //        return;
        //    }
        //    if (!context.HttpContext.User.HasClaim("role", "admin"))
        //    {
        //        context.Result = new ForbidResult();
        //    }
        //    var roleManager = context.HttpContext.RequestServices.GetRequiredService<RoleManager<IdentityRole>>();
        //    var permissionManager = context.HttpContext.RequestServices.GetRequiredService<PermissionManager>();

        //    var userRole = _userManager.GetRolesAsync(user).Result.FirstOrDefault();

        //    if (string.IsNullOrEmpty(userRole))
        //    {
        //        context.Result = new ForbidResult();
        //        return;
        //    }

        //    var role = roleManager.FindByNameAsync("admin").Result;

        //    if (role == null)
        //    {
        //        context.Result = new ForbidResult();
        //        return;
        //    }

        //    var permission = permissionManager.GetPermissionByRole(role, "Products");

        //    if (permission == null)
        //    {
        //        context.Result = new ForbidResult();
        //        return;
        //    }
        //}
    }

}
