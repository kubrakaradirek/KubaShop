using KubaShop.Catalog.Dtos.SpecialOfferDtos;
using KubaShop.Catalog.Services.SpecialOfferServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KubaShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly ISpecialOfferService _SpecialOfferService;
        public SpecialOffersController(ISpecialOfferService SpecialOfferService)
        {
            _SpecialOfferService = SpecialOfferService;
        }
        [HttpGet] //Web API'lerde veri istemek için kullanılır.Tüm verileri getireceğimizde id kullanmadık.
        public async Task<IActionResult> SpecialOfferList()
        {
            var values = await _SpecialOfferService.GetAllSpecialOfferAsync();//Değer döndüreceği için bir değişken tanımlayıp eşitledik.
            return Ok(values);
        }
        [HttpGet("{id}")] // Idye göre kategorileri getireceğimiz için id şeklinde aldım.
        public async Task<IActionResult> GetSpecialOfferById(string id)
        {
            var values = await _SpecialOfferService.GetByIdSpecialOfferAsync(id);
            return Ok(values);
        }
        [HttpPost] // HttpPost: Web API'de Veri tabanınına yeni veri eklemek için kullanılır.
        [AllowAnonymous]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            //Mapleme işlemini yaptığımız için SpecialOffer classını alıp newleyerek yeni nesne yaratmadık.Direkt dtoları kullandık.Atamalara da ihtiyacımız kalmadı mapleme bize bu işlemi yapıyor.
            await _SpecialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return Ok("Özel teklif başarıyla eklendi.");
        }
        [HttpDelete] //HttpDelete = Veritabanından Web API'de veri silmek için kullanılır.
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _SpecialOfferService.DeleteSpecialOfferAsync(id);
            return Ok("Özel teklif başarıyla silindi.");
        }
        [HttpPut] //HttpPut = Web API'de veritabanındaki bilgiyi güncellemek için kullanılır.
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _SpecialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return Ok("Özel teklif başarıyla güncellendi.");
        }
    }
}
