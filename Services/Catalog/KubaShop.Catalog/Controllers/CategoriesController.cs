using KubaShop.Catalog.Dtos.CategoryDtos;
using KubaShop.Catalog.Entities;
using KubaShop.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KubaShop.Catalog.Controller
{
    [AllowAnonymous]
    //[Authorize]//Giriş zorunluluğu
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
                _categoryService = categoryService;
        }
        [HttpGet] //Web API'lerde veri istemek için kullanılır.Tüm verileri getireceğimizde id kullanmadık.
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryService.GetAllCategoryAsync();//Değer döndüreceği için bir değişken tanımlayıp eşitledik.
            return Ok(values);
        }
        [HttpGet("{id}")] // Idye göre kategorileri getireceğimiz için id şeklinde aldım.
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var values=await  _categoryService.GetByIdCategoryAsync(id);
            return Ok(values);
        }
        [HttpPost] // HttpPost: Web API'de Veri tabanınına yeni veri eklemek için kullanılır.
        [AllowAnonymous]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            //Mapleme işlemini yaptığımız için Category classını alıp newleyerek yeni nesne yaratmadık.Direkt dtoları kullandık.Atamalara da ihtiyacımız kalmadı mapleme bize bu işlemi yapıyor.
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Yeni kategori başarıyla eklendi.");
        }
        [HttpDelete] //HttpDelete = Veritabanından Web API'de veri silmek için kullanılır.
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Kategori başarıyla silindi.");
        }
        [HttpPut] //HttpPut = Web API'de veritabanındaki bilgiyi güncellemek için kullanılır.
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Kategori başarıyla güncellendi.");
        }
    }
}
