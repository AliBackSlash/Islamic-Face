#region Initialize builder


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
#endregion

#region register DbContext

builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddDbContext<AppDbContext>(bl => bl.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    p => p.MigrationsAssembly(typeof(AppDbContext).Assembly)

    ));
#endregion

builder.Configuration.GetSection("JWT").Get<JWT>();

#region Call Registers class
builder.Services.AddApiLayerServices();
#endregion

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
