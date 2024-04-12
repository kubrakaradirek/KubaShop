using KubaShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using KubaShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using KubaShop.Order.Application.Interfaces;
using KubaShop.Order.Application.Services;
using KubaShop.Order.Persistence.Context;
using KubaShop.Order.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

//JWT 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceOrder";
    opt.RequireHttpsMetadata = false;
});

//context sýnýfý
builder.Services.AddDbContext<OrderContext>();

builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddApplicationService(builder.Configuration);

// Add services to the container.

#region
//------------- Address-------------
builder.Services.AddScoped<GetAddressQueryHandler>();
builder.Services.AddScoped<GetAddressByIdQueryHandler>();
builder.Services.AddScoped<CreateAddressCommandHandler>();
builder.Services.AddScoped<UpdateAddressCommandHandler>();
builder.Services.AddScoped<RemoveAddressCommandHandler>();

//------------- Order Detail-------------
builder.Services.AddScoped<GetOrderDetailQueryHandler>();
builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
builder.Services.AddScoped<RemoveOrderDetailCommandHandler>();
#endregion

builder.Services.AddControllers();
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
