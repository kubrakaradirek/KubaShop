namespace KubaShop.Catalog.Dtos.ProductImageDtos
{
    public class UpdateProductImageDto
    {
        public string ProductImageId { get; set; } //Ürünlerin resimleri için 3 farklı resimle çalışacağız
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string ProductId { get; set; }
    }
}
