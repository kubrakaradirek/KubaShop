using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubaShop.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class RemoveAddressCommand
    {
        public int Id { get; set; }
        //Nesne örneği üzerinden çağırılacağı için const metodu uyguladık.
        public RemoveAddressCommand(int id)
        {
                Id = id;
        }
    }
}
