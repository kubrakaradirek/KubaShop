using KubaShop.Basket.LoginServices;
using KubaShop.Basket.Services;
using KubaShop.Basket.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

//Bir kullan�c�n�n zorunlu olmas�n� de�i�kene atand�
var requireAuthorizePoliciy=new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

//"sub" mapplemesini kald�rmak i�in
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

//JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceBasket";
    opt.RequireHttpsMetadata = false;
});

//Servis konfig�rasyonlar�
builder.Services.AddScoped<ILoginService,LoginService>();
builder.Services.AddScoped<IBasketService,BasketService>();

//Http
builder.Services.AddHttpContextAccessor();

//RedisSettings konfig�rasyonlar�
builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection("RedisSettings"));

//RedisService konfig�rasyonlar�
builder.Services.AddSingleton<RedisService>(sp =>
{
    var redisSettings = sp.GetRequiredService<IOptions<RedisSettings>>().Value;
    var redis = new RedisService(redisSettings.Host, redisSettings.Port);
    redis.Connect();
    return redis;
});

//Kullan�c�n�n zorunlu giri�i i�in yukar�daki de�i�kende yaz�l�r
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePoliciy));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
