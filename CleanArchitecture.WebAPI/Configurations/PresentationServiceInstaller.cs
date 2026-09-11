using CleanArchitecture.Domain.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi;

namespace CleanArchitecture.WebAPI.Configurations;

public sealed class PresentationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
    {
        services.Configure<EMailOptions>(configuration.GetSection("EmailOptions"));

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy =>
                policy
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .SetIsOriginAllowed(policy => true));
        });

        services.AddControllers().AddApplicationPart(typeof(CleanArchitecture.Presentation.AssemblyReference).Assembly);

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(setup =>
        {
            const string schemeId = JwtBearerDefaults.AuthenticationScheme; // "Bearer"

            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                BearerFormat = "JWT",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = schemeId,
                Description = "Put **_ONLY_** your JWT Bearer token on textbox below!"
            };

            // 1. Güvenlik Tanımını Ekle
            setup.AddSecurityDefinition(schemeId, jwtSecurityScheme);

            // 2. OpenApiSecuritySchemeReference nesnesine şema adını (ve isteğe bağlı dökümanı) geçin
            setup.AddSecurityRequirement(document => new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference(schemeId, document)] = new List<string>()
            });
        });
    }
}
