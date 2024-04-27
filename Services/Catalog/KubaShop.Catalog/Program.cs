using KubaShop.Catalog.Services.AboutServices;
using KubaShop.Catalog.Services.BrandServices;
using KubaShop.Catalog.Services.CategoryServices;
using KubaShop.Catalog.Services.FeatureServices;
using KubaShop.Catalog.Services.FeatureSliderServices;
using KubaShop.Catalog.Services.OfferDiscountServices;
using KubaShop.Catalog.Services.ProductDetailServices;
using KubaShop.Catalog.Services.ProductImageServices;
using KubaShop.Catalog.Services.ProductServices;
using KubaShop.Catalog.Services.SpecialOfferServices;
using KubaShop.Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Reflection;//Assembyly=> Kullanmak i�in gerekli ad alan�d�r.

var builder = WebApplication.CreateBuilder(args);

//JWT 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];//appsettinjsondan gelecek
    opt.Audience = "ResourceCatalog";//sen geleceksin identity den appsettings yazd���m�z yetkilendirmede bununla �al��acaks�n anlam�na gelir
    opt.RequireHttpsMetadata = false;//appsettingjsonda https de�il http diye belirtti�imiz i�in
});

//AddScoped => Bana ICategoryService �a�r�ld���nda categoryService s�n�f�n�da �a��rmaya yarar.Const metotu i�in konfig�rasyonlar� tamamland�.
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IFeatureSliderService, FeatureSliderService>();
builder.Services.AddScoped<ISpecialOfferService, SpecialOfferService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<IOfferDiscountService, OfferDiscountService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IAboutService, AboutService>();

//AutoMapper i�in gerekli konfig�rasyonlar
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//AppSettings i�in gerekli konfig�rasyonlar
//GetSection yapt���m�z yer appsettings.json dosyas�ndaki DatabaseSettings yazan yer oraya da istedi�imiz ad� verebiliriz �zel bir kullan�m ad� de�ildir.
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

//Burada yapt���m serviceprovider konfig�rasyonu DatabaseSettings s�n�f�m�n i�inde bilgilere ula�acak.
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});


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
