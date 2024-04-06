using KubaShop.Catalog.Dtos.ProductDtos;
using KubaShop.Catalog.Dtos.ProductImageDtos;

namespace KubaShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();  //Bütün verilerimizi getirecek metot
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);//mongodb de id string tanımlanıyor.
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
    }
}
