using Dapper;
using KubaShop.Discount.Context;
using KubaShop.Discount.Dtos;

namespace KubaShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;
        public DiscountService(DapperContext dapperContext)
        {
                _context = dapperContext;
        }
        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            //query sorgusu yazdık
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code",createCouponDto.Code);
            parameters.Add("@rate",createCouponDto.Rate);
            parameters.Add("@isActive",createCouponDto.IsActive);
            parameters.Add("@validDate",createCouponDto.ValidDate);
            using(var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
                //dapperda bana parametre eklememi sağlayacak
            }
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "Delete From Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();   
            parameters.Add("couponId",id);
            using(var connections=_context.CreateConnection())
            {
                await connections.ExecuteAsync(query,parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "Select * From Coupons";
            using(var connection= _context.CreateConnection())
            {
                var values=await connection.QueryAsync<ResultDiscountCouponDto>(query); 
                return values.ToList();
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            string query = "Select * From Coupons Where CouponId=@couponId";
            var parameters=new DynamicParameters();
            parameters.Add("@couponId",id );
            using(var connection = _context.CreateConnection())
            {
                var values=await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query,parameters);
                return values;
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId=@couponId ";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            parameters.Add("@couponId", updateCouponDto.CouponId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
                //dapperda bana parametre eklememi sağlayacak
            }
        }
    }
}
