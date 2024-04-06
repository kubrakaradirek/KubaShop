using KubaShop.Catalog.Dtos.ProductDetailDtos;
using KubaShop.Catalog.Dtos.ProductDtos;

namespace KubaShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();  //Bütün verilerimizi getirecek metot
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);//mongodb de id string tanımlanıyor.
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
    }
}
