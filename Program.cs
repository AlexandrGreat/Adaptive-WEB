using LR6.Controllers;
using LR6.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using LR6.Extensions;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Insert JWT Token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {{
    new OpenApiSecurityScheme{
        Reference=new OpenApiReference{
            Type=ReferenceType.SecurityScheme,
            Id="Bearer"
        }
    },
        new string[]{ }}
    });
    c.OperationFilter<CustomHeaderFilter>();
});


builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme=JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.TokenValidationParameters = new TokenValidationParameters {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)),
        ValidateIssuerSigningKey = true,
        ValidateIssuer=true,
        ValidateAudience=true,
        ValidateLifetime=true,
        ValidIssuer = config["JwtSettings:Issuer"],
        ValidAudience = config["JwtSettings:Audience"]
    };
});
builder.Services.AddAuthorization();

builder.Services.AddSingleton<UserRepository>(); //Used AddSingleton to imitate work with DB: every request used the same object
builder.Services.AddSingleton<ProductRepository>();
builder.Services.AddSingleton<ReviewRepository>();
builder.Services.AddSingleton<LoginService>();
builder.Services.AddSingleton<PasswordService>();
builder.Services.AddSingleton<LR9Service>();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>,SwaggerConfigOptions>();

builder.Services.AddControllers();

builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ApiVersionReader = new HeaderApiVersionReader("api-version");
    config.ReportApiVersions = true;
});
builder.Services.AddVersionedApiExplorer();

var app = builder.Build();

var versionDescProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        foreach (var desc in versionDescProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json", $"LR API - {desc.GroupName.ToUpper()}");
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
