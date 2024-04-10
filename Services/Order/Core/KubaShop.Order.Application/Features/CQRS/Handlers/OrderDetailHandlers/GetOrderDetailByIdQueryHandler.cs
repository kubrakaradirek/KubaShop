using KubaShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using KubaShop.Order.Application.Features.CQRS.Results.OrderDetailResult;
using KubaShop.Order.Application.Interfaces;
using KubaShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubaShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResult
            {
                OrderDetailId = values.OrderDetailId,
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                ProductAmount = values.ProductAmount,
                ProductTotalPrice = values.ProductTotalPrice,
                OrderingId = values.OrderingId,
                ProductPrice = values.ProductPrice
            };
        }
    }
}
