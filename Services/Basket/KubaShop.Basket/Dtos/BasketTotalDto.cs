namespace KubaShop.Basket.Dtos
{
    public class BasketTotalDto
    {
        //Burada sepetteki toplam ücreti tutacağız

        public string UserId { get; set; }//Identityden gelecek ve string alınır.
        public string DiscountCode { get; set; }//İndirim kodu
        public int DiscountRate { get; set; }//İndirim oranı
        public List<BasketItemDto> BasketItems { get; set; }
        public decimal TotalPrice { get => BasketItems.Sum(x => x.Price * x.Quantity); }
    }
}
