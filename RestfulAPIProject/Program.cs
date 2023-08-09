using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RestfulAPIProject.Infrastructure.Context;
using RestfulAPIProject.Infrastructure.Repositories.Concrete;
using RestfulAPIProject.Infrastructure.Repositories.Interfaces;
using RestfulAPIProject.Infrastructure.Settings;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

builder.Services.AddAutoMapper(typeof(RestfulAPIProject.Infrastructure.AutoMapper.Mapper));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Restful API",
        Version = "v1",
        Description = "Restful API",
        Contact = new OpenApiContact()
        {
            Email = "gunes.ismt@gmail.com",
            Name = "�smet Gunes",
            Url = new Uri("https://github.com/Gunes-Ismet")
        },
        License = new OpenApiLicense()
        {
            Name = "MIT License",
            Url = new Uri("https://en.wikipedia.org/wiki/MIT_License")
        }
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using Bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            },
            Scheme = "Auth",
            Name = "Bearer",
            In = ParameterLocation.Header
        },
        new List<string>()
    }

});

    var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);

    options.IncludeXmlComments(xmlCommentFullPath);

});


var appSettingSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingSection);

var appSettings = appSettingSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options2 =>
    {
        options2.RequireHttpsMetadata = true;
        options2.SaveToken = true;
        options2.TokenValidationParameters = new TokenValidationParameters
        {
            // Token de�erinin bu uygulamaya ait olup olmad���n� anlamam�z� sa�layan Security Key do�rulamas�
            ValidateIssuerSigningKey = true,

            // Security Key do�rulamas� i�in SymmetricSecurityKey nesnesi arac�l��� ile mevcut keyi belirtiyoruz
            IssuerSigningKey = new SymmetricSecurityKey(key),

            // Uygulamadaki token'�n Audience de�erini belirledik (Audience : Eri�ebilecek kimlikler)
            ValidateAudience = false,

            // Uygulamadaki token'�n issuer de�erini belirledik (Issuer : Token de�erini da��tacak ki�iler)
            ValidateIssuer = false,
        };
    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
