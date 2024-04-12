using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubaShop.Order.Application.Features.Mediator.Commands.OrderingCommands
{
    public class CreateOrderingCommand:IRequest //Bunu yazarak isteğin bu sınıf için olduğunu belirtmiş olduk.
    {
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
