using CleanArchitecture.WebAPI.Configurations;
using CleanArchitecture.WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallServices(builder.Configuration, builder.Host, typeof(IServiceInstaller).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseMiddlewareExtensions();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
