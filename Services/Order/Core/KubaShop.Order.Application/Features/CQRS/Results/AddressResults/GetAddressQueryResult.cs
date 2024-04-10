using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubaShop.Order.Application.Features.CQRS.Results.AddressResults
{
    public class GetAddressQueryResult
    {
        // Read --> Results işlemlerini yapmaktadır. Resultslar CQRS tasarım desenine göre başında GET kelimesini almaktadır.
        // Bu class bize address classı içindeki propertyleri tutmamızı sağlar  ve bunları listelememizi sağlayacak.
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
