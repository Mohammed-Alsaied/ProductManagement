namespace Common.Configurations
{
    public class BaseServiceInstaller : IInstaller
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseUnitOfWork<>), typeof(BaseUnitOfWork<>));
        }

    }
}
