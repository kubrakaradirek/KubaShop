using KubaShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using KubaShop.Order.Application.Features.Mediator.Results.OrderingResults;
using KubaShop.Order.Application.Interfaces;
using KubaShop.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubaShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
    {
        //İstek yapılan yer IRequest interfacesini tutan sınıftır=>GetOrderingQuery 
        //Bu istek nerden karşılanacak liste olarak=>GetOrderingQueryResult
        private readonly IRepository<Ordering> _repository;
        public GetOrderingQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        //Bu metot mediator handle aracılığı ile implement edilmiştir.
        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=>new GetOrderingQueryResult
            {
                OrderingId = x.OrderingId,
                OrderDate = x.OrderDate,
                TotalPrice = x.TotalPrice,
                UserId = x.UserId
            }).ToList();
        }
        //CancellationToken => Örneğin bir sayfada post yapmak istiyoruz tıkladık sayfada dolmaya devam ediyor yükleniyor diyelim ama dolmuyor sekmeyi veya tarayıcıyı kapatmaya çalıştığımızda işlem iptal olsun mu diye görev yükleniyor.
    }
}
