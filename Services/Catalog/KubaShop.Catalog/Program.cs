using KubaShop.Catalog.Services.CategoryServices;
using KubaShop.Catalog.Services.ProductDetailServices;
using KubaShop.Catalog.Services.ProductImageServices;
using KubaShop.Catalog.Services.ProductServices;
using KubaShop.Catalog.Settings;
using Microsoft.Extensions.Options;
using System.Reflection;//Assembyly=> Kullanmak için gerekli ad alanýdýr.

var builder = WebApplication.CreateBuilder(args);

//AddScoped => Bana ICategoryService çaðrýldýðýnda categoryService sýnýfýnýda çaðýrmaya yarar.Const metotu için konfigürasyonlarý tamamlandý.
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();

//AutoMapper için gerekli konfigürasyonlar
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//AppSettings için gerekli konfigürasyonlar
//GetSection yaptýðýmýz yer appsettings.json dosyasýndaki DatabaseSettings yazan yer oraya da istediðimiz adý verebiliriz özel bir kullaným adý deðildir.
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

//Burada yaptýðým serviceprovider konfigürasyonu DatabaseSettings sýnýfýmýn içinde bilgilere ulaþacak.
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

app.UseAuthorization();

app.MapControllers();

app.Run();
