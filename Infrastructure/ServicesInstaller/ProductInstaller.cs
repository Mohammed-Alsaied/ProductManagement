using Products.Repositories;

public class ProductInstaller : IInstaller
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IValidator<ProductForCreateDto>, ProductForCreateDtoValidator>();
        services.AddScoped<IValidator<ProductForUpdateDto>, ProductForUpdateDtoValidator>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductUnitOfWork, ProductUnitOfWork>();
    }
}
