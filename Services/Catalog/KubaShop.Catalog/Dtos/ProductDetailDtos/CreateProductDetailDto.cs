namespace KubaShop.Catalog.Dtos.ProductDetailDtos
{
    public class CreateProductDetailDto
    {
        //Id otomatik atandığından Id i yazılmadı.
        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; } //Garanti süresi gibi durumlar eklenebilir.
        public string ProductId { get; set; }
    }
}
