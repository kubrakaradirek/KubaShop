namespace KubaShop.Basket.Dtos
{
    public class BasketItemDto
    {
        public string ProductId { get; set; }//Verilerimizi katalog mikroservisinden çekeceğimiz için ve orda string oldugu için string aldıkç
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
