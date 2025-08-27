#region Initialize builder


using IslamicFace.Presentation.API.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
#endregion

#region register DbContext

builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;
   
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
{
    options.TokenLifespan = TimeSpan.FromHours(1);
});

builder.Services.AddDbContext<AppDbContext>(bl => bl.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    p => p.MigrationsAssembly(typeof(AppDbContext).Assembly)

    ));

#endregion
builder.Services.AddHttpContextAccessor();

#region Configer JWT Bearer
var JWTValues = builder.Configuration.GetSection("JWT").Get<JWT>();
builder.Services.AddSingleton(JWTValues);
builder.Services.AddAuthentication(op =>
{
    op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(ops =>
{
    ops.RequireHttpsMetadata = false;
    ops.SaveToken = false;
    ops.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateLifetime = true,
        ValidateIssuer = true,
        ValidIssuer = JWTValues!.Issuer,
        ValidateAudience = true,
        ValidAudience = JWTValues!.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTValues!.SigningKey))
    };
});

#endregion

builder.Configuration.GetSection("JWT").Get<JWT>();
builder.Services.AddScoped<IFileService, FileService>();

#region Call Registers class
builder.Services.AddApiLayerServices();
#endregion

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate(); // This applies any pending migrations
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "v1"));
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseStaticFiles();

app.Run();
