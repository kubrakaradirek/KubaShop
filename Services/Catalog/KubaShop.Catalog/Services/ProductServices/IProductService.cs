using KubaShop.Catalog.Dtos.CategoryDtos;
using KubaShop.Catalog.Dtos.ProductDtos;

namespace KubaShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();  //Bütün verilerimizi getirecek metot
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);//mongodb de id string tanımlanıyor.
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
    }
}
