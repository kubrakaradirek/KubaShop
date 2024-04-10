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
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAddressCommand command)
        {
            var values=await _repository.GetByIdAsync(command.AddressId);
            values.Detail=command.Detail;
            values.City=command.City;
            values.District=command.District;
            values.UserId=command.UserId;   
            await _repository.UpdateAsync(values);
        }
    }
}
