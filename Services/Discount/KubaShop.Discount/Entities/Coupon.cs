namespace KubaShop.Discount.Entities
{
    public class Coupon
    {
        public int CouponId { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; } //Kuponun indirim oranı kaç
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }//Kupon geçerlilik tarihi
    }
}
