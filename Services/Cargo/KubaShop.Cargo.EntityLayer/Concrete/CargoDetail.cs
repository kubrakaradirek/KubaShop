using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubaShop.Cargo.EntityLayer.Concrete
{
    public class CargoDetail
    {
        //Bu bir adet tablomuz
        //1- X Ticaret-Ali Yıldız-Barcode:001122-Yurtiçi Kargo
        //2- Y Ticaret-Mehmet Öztürk-Barcode:002233-Ptt

        //2.TABLO
        //1-001122-Bostancı Yurtiçi Kargo
        //2-001122-Gebze Transfer Merkezi-10.02.2024
        //3-001122-Sakarya Serdivan-12.02.2024
        //4-001122-Dağıtıma çıktı-12.02.2024
        //5-001122-Teslim edildi.

        //3.Kargo firmaları
        public int CargoDetailId { get; set; }
        public string SenderCustomer  { get; set; }
        public string ReceiverCustomer { get; set; }//Alıcı müşteri mongodb den id alacağımız için 
        public int Barcode { get; set; }
        public int CargoCompanyId { get; set; }
        public CargoCompany CargoCompany { get; set; }
    }
}
