using AutoMapper;
using KubaShop.Catalog.Dtos.CategoryDtos;
using KubaShop.Catalog.Entities;
using KubaShop.Catalog.Settings;
using MongoDB.Driver;

namespace KubaShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper,IDatabaseSettings _databaseSettings) //ayaklandığında nesnesi oluşturulacak
        {
            //Üç adet aşama vardır. Connection => Database => Tablo veya mongodb koleksiyon
            var client = new MongoClient(_databaseSettings.ConnectionString);//overloadlarında connection string istiyor.Bizim settings işlemimiz appsettingstedir onun ise karşılığı IDatabaseSettings ifadesindedir.
            var database=client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection=database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }
        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value=_mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(value);//MongoDbde eklemek istemi => InsertOneAsync ile yapılır.
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryId == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values=await _categoryCollection.Find(x=>true).ToListAsync(); // Burada x bütün hepsini getir anlamında
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var values= await _categoryCollection.Find<Category>(x=>x.CategoryId==id).FirstOrDefaultAsync();//Bir tane id ye bağlı kategori getirmek istediğimiz için FirsOrDefaultAsync kullandık.
            return _mapper.Map<GetByIdCategoryDto>(values);  
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var values = _mapper.Map<Category>(updateCategoryDto);//Mappleme işlemi yapıldı.
            await _categoryCollection.FindOneAndReplaceAsync(x=>x.CategoryId==updateCategoryDto.CategoryId, values);//Burada MongoDb de update işlemi için => FindOneAndReplaceAsync kullanılır.
        }
    }
}
