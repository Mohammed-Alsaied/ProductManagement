using Api.Services;
using Products.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddInstallerFromAssembly<BaseServiceInstaller>(builder.Configuration);
builder.Services.AddInstallerFromAssembly<ProductInstaller>(builder.Configuration);
builder.Services.AddInstallerFromAssembly<FluentValidationServiceInstaller>(builder.Configuration);
builder.Services.AddInstallerFromAssembly<PresentationServiceInstaller>(builder.Configuration);
builder.Services.AddInstallerFromAssembly<InfrastructureServiceInstaller>(builder.Configuration);

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                   .AddEntityFrameworkStores<ApplicationDbContext>()
                   .AddDefaultTokenProviders();
builder.Services.AddScoped<IImageService, ImageService>();
////JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});

//Add AddAutoMapper Services
builder.Services.AddAutoMapper(typeof(Program).Assembly,
    typeof(Product).Assembly);
var app = builder.Build();
//middleware to logging evry request
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

