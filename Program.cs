using System.Text;
using CondoProj;
using CondoProj.Interfaces;
using CondoProj.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ITowerService, TowerService>();
builder.Services.AddScoped<IApartmentService, ApartmentService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });

//var jwtSettings = builder.Configuration.GetSection("JwtSettings");
//var secretKey = jwtSettings["SecretKey"] ?? "AndromedaIsMyFavoriteGalaxy010";

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = jwtSettings["Issuer"] ?? "https://localhost:7198",
//        ValidAudience = jwtSettings["Audience"] ?? "https://localhost:7198",
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))

//    };
//});

builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CondoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CondoConnectionString"));
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
