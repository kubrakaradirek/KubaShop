using KubaShop.DtoLayer.CatalogDtos.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace KubaShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Category")]//buraya gideceksin Web Api' a gelen istekleri Route niteliği ile yönlendirebiliriz.
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CategoryController(IHttpClientFactory httpClientFactory)
        {
                _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult>  Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Listesi";
            ViewBag.v0 = "Kategori İşlemleri";
            //Kategorilerin api consume işlemleri
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:9696/api/Categories");//Kategoriyi bize bu porttan okumamızı sağlar.
            if (responseMessage.IsSuccessStatusCode)//IsSuccessStatusCode ==> Okunan değer kodu başarılı olması anlamına gelir.200 döndürmesidir.
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();//Veriler json formatında olduğu için string şekilde okunması
                var values=JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);//Deserialize ==> Verileri Json formattan metine dönüştürür.Listeleme veya Idye göre getirme işlemleri için kullanılır.
                //Serialize ==> Verileri metin formattan Json formatına dönüştürür.Genelde ekle-güncelle de kullanılır.
                //Jsondata da bu listeleme işleminin frontende karşılayacağı property değeri olmalıdır.O yüzden bir katman gerekiyor.
                return View(values);    
            }
            return View();
        }
        [HttpGet]
        [Route("CreateCategory")]
        public IActionResult CreateCategory()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Yeni Kategori Girişi";
            ViewBag.v0 = "Kategori İşlemleri";
            return View();
        }
        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var client=_httpClientFactory.CreateClient();//Parametre olarak gönderilen değer alındı.
            var jsonData=JsonConvert.SerializeObject(createCategoryDto);//String ifade Json formatına dönüştürüldü.
            StringContent stringContent=new StringContent(jsonData,Encoding.UTF8,"application/json");//Encoding.UTF8==>Türkçe karakterleride alır.Content olarak atandı jsonData=Content,Dil Desteği=Encoding.UTF8, mediator="application/json
            var responseMessage = await client.PostAsync("https://localhost:9696/api/Categories", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:9696/api/Categories?id=" + id);//Service katmanında DeleteCategoryde direkt id aldığı için böyle iletildi.404 dönüyordu Hata ?id= ile çözüldü.
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }
        [Route("UpdateCategory/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Güncelleme Sayfası";
            ViewBag.v0 = "Kategori İşlemleri";
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:9696/api/Categories/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("UpdateCategory/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateCategoryDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:9696/api/Categories/",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }
    }
}
