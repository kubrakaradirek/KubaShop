using KubaShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubaShop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingQuery:IRequest<List<GetOrderingQueryResult>> //IRequest=>Mediatr kütüphanesinin içinde yer alan bir interfacedir.
    {
        //GetOrderingQueryResult=> Bütün listeyi döndürecek
        //GetOrderingByIdQueryResult=> Sadece bir değer döndürecek aralarındaki fark budur.
    }
}
