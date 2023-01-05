using SiKoperasi.Auth.Contract;
using SiKoperasi.Web.Common;
using SiKoperasi.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers().AddControllersAsServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddService(builder.Configuration);
builder.Services.AddRouting(opt => opt.LowercaseUrls = true);
builder.Services.AddControllers();

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    //using var scope = app.Services.CreateScope();
    //var roleSvc = scope.ServiceProvider.GetRequiredService<IRoleService>();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    else
    {
        app.UseSwagger();
        app.UseSwaggerUI(op => op.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
    }

    app.UseAuthentication();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    //app.UseMiddleware<PermissionAuthenticationMiddleware>(roleSvc);
    app.UseExceptionHandler("/error");
    app.MapControllers();

    app.Run();
}