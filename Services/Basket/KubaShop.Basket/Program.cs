using KubaShop.Basket.LoginServices;
using KubaShop.Basket.Services;
using KubaShop.Basket.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

//Bir kullanýcýnýn zorunlu olmasýný deðiþkene atandý
var requireAuthorizePoliciy=new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

//"sub" mapplemesini kaldýrmak için
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

//JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceBasket";
    opt.RequireHttpsMetadata = false;
});

//Servis konfigürasyonlarý
builder.Services.AddScoped<ILoginService,LoginService>();
builder.Services.AddScoped<IBasketService,BasketService>();

//Http
builder.Services.AddHttpContextAccessor();

//RedisSettings konfigürasyonlarý
builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection("RedisSettings"));

//RedisService konfigürasyonlarý
builder.Services.AddSingleton<RedisService>(sp =>
{
    var redisSettings = sp.GetRequiredService<IOptions<RedisSettings>>().Value;
    var redis = new RedisService(redisSettings.Host, redisSettings.Port);
    redis.Connect();
    return redis;
});

//Kullanýcýnýn zorunlu giriþi için yukarýdaki deðiþkende yazýlýr
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
