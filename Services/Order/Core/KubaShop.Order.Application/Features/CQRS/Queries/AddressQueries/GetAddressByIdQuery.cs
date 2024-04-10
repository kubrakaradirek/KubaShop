using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubaShop.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByIdQuery
    {
        //Bu class ta bizim Parametre --> Queries tutacak.Results klasöründeki adress resulttaki GetAddressByIdQuery'deki classın parametresini alır.
        public int Id { get; set; } //Parametre Id olacak
        //Controllerda bu classı çağıracağız ondan ctor metodu açtık.
        public GetAddressByIdQuery(int id)
        {
                Id = id;
        }
    }
}
