using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubaShop.Order.Domain.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public string ProductId { get; set; }//MongoDb 
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; } //tutar miktar
        public decimal ProductTotalPrice { get; set; }
        public int OrderingId { get; set; }//Toplam sipariş için
        public Ordering Ordering { get; set; }
    }
}
