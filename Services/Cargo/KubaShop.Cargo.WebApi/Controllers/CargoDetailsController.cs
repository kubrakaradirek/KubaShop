using KubaShop.Cargo.BusinessLayer.Abstract;
using KubaShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using KubaShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KubaShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _CargoDetailService;
        public CargoDetailsController(ICargoDetailService CargoDetailService)
        {
            _CargoDetailService = CargoDetailService;
        }
        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _CargoDetailService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail CargoDetail = new CargoDetail()
            {
                SenderCustomer = createCargoDetailDto.SenderCustomer,
                Barcode = createCargoDetailDto.Barcode,
                ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
                CargoCompanyId=createCargoDetailDto.CargoCompanyId
            };
            _CargoDetailService.TInsert(CargoDetail);
            return Ok("Kargo detayları  başarıyla oluşturuldu.");
        }
        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _CargoDetailService.TDelete(id);
            return Ok("Kargo detayları  başarıyla silindi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var values = _CargoDetailService.TGetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail CargoDetail = new CargoDetail()
            {
                CargoDetailId=updateCargoDetailDto.CargoDetailId,
                SenderCustomer=updateCargoDetailDto.SenderCustomer,
                ReceiverCustomer=updateCargoDetailDto.ReceiverCustomer,
                Barcode=updateCargoDetailDto.Barcode,
                CargoCompanyId=updateCargoDetailDto.CargoCompanyId
            };
            _CargoDetailService.TUpdate(CargoDetail);
            return Ok("Kargo detayları başarıyla güncellendi.");
        }
    }
}
