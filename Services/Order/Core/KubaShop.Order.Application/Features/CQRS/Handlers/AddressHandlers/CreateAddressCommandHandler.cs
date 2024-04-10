using KubaShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using KubaShop.Order.Application.Interfaces;
using KubaShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubaShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
                _repository = repository;
        }
        //Handlerlarde genelde bir metot yazılır.Her sınıf bir işlem yapmalı. Handle metodu CQRS dizayn patternde kullanılan bir metot ismidir.
        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreateAsync(new Address
            {
                //Mapleme yapmadığımız için atamaları yapıyoruz
                City=createAddressCommand.City,
                Detail=createAddressCommand.Detail,
                District=createAddressCommand.District,
                UserId=createAddressCommand.UserId
            });
        }
    }
}
