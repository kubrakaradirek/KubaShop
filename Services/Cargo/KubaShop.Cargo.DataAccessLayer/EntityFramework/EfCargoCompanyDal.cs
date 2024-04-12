using KubaShop.Cargo.DataAccessLayer.Abstract;
using KubaShop.Cargo.DataAccessLayer.Concrete;
using KubaShop.Cargo.DataAccessLayer.Repositories;
using KubaShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubaShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCompanyDal:GenericRepository<CargoCompany>,ICargoCompanyDal
    {
        public EfCargoCompanyDal(CargoContext context):base(context)
        {

        }
    }
}
