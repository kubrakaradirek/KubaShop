using KubaShop.Catalog.Dtos.CategoryDtos;

namespace KubaShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        //Category crud işlemlerini metotların imzalarını tutacak
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();  //Bütün verilerimizi getirecek metot
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);//mongodb de id string tanımlanıyor.
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id); 

    }
}
