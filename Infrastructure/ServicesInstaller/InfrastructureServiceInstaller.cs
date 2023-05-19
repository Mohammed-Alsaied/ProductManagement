public class InfrastructureServiceInstaller : IInstaller
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options
                .UseSqlServer(connectionString, builder => builder.MigrationsAssembly("Infrastructure"))
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
        services.AddScoped<DbContext, ApplicationDbContext>();
        //services.AddIdentity<IdentityUser, IdentityRole>()
        //                   .AddEntityFrameworkProductss<ApplicationDbContext>()
        //                   .AddDefaultTokenProviders();

    }
}