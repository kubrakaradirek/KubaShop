using KubaShop.Catalog.Dtos.FeatureDtos;

namespace KubaShop.Catalog.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();  //Bütün verilerimizi getirecek metot
        Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
        Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
        Task DeleteFeatureAsync(string id);//mongodb de id string tanımlanıyor.
        Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id);
    }
}
