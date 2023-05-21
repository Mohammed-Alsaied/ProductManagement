namespace Infrastructure.Auth
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var permissionManager = scope.ServiceProvider.GetRequiredService<PermissionManager>();

                await context.Database.EnsureCreatedAsync();

                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }

                if (!await roleManager.RoleExistsAsync("User"))
                {
                    await roleManager.CreateAsync(new IdentityRole("User"));
                }

                var adminRole = await roleManager.FindByNameAsync("Admin");
                await permissionManager.CreateAsync(new Permission { Action = Action.View, Resource = Resource.Products, Role = adminRole, RoleId = adminRole.Id });
                await permissionManager.CreateAsync(new Permission { Action = Action.Create, Resource = Resource.Products, Role = adminRole, RoleId = adminRole.Id });
                await permissionManager.CreateAsync(new Permission { Action = Action.Update, Resource = Resource.Products, Role = adminRole, RoleId = adminRole.Id });
                await permissionManager.CreateAsync(new Permission { Action = Action.Delete, Resource = Resource.Products, Role = adminRole, RoleId = adminRole.Id });
                await permissionManager.CreateAsync(new Permission { Action = Action.Upload, Resource = Resource.Products, Role = adminRole, RoleId = adminRole.Id });
            }
        }
    }

}
