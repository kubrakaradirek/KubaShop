﻿using KubaShop.Order.Application.Features.CQRS.Results.OrderDetailResult;
using KubaShop.Order.Application.Interfaces;
using KubaShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubaShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
                _repository = repository;
        }
        public async Task<List<GetOrderDetailByIdQueryResult>> Handle()
        {
            var values=await _repository.GetAllAsync();
            return values.Select(x => new GetOrderDetailByIdQueryResult
            {
                OrderDetailId = x.OrderDetailId,
                ProductAmount = x.ProductAmount,
                OrderingId = x.OrderingId,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductTotalPrice = x.ProductTotalPrice
            }).ToList();
        }
    }
}
