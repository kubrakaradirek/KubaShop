using KubaShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using KubaShop.Order.Application.Features.CQRS.Results.AddressResults;
using KubaShop.Order.Application.Interfaces;
using KubaShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubaShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        //Bu bir listeleme işlemi id ye göre getirme ve tüm listeleme işlemlerinde query handler diyeceğiz.Ama ekleme-silme-güncelleme de command handler diyeceğiz.
        private readonly IRepository<Address> _repository;
        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
                _repository = repository;
        }
        //Task içinde benden bir değer istiyor bende neyi listelemek istiyorum resultstaki değeri id ye göre listemeişlemi yapıyor.İçine bir parametre istiyor oda query olacak çünkü query bizim istediğimiz parametreyi tutuyordu
        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetAddressByIdQueryResult
            {
                AddressId = values.AddressId,
                UserId = values.UserId,
                District = values.District,
                City = values.City,
                Detail = values.Detail,
            };
        }
    }
}
