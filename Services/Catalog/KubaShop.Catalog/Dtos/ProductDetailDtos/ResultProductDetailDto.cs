namespace KubaShop.Catalog.Dtos.ProductDetailDtos
{
    public class ResultProductDetailDto
    {
        public string ProductDetailId { get; set; }
        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; } //Garanti süresi gibi durumlar eklenebilir.
        public string ProductId { get; set; }
    }
}
