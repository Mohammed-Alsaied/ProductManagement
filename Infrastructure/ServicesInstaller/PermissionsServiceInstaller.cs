namespace Common.ServicesInstaller
{
    public class PermissionsServiceInstaller : IInstaller
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<PermissionManager>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IPermissionUnitOfWork, PermissionUnitOfWork>();
        }
    }
}
