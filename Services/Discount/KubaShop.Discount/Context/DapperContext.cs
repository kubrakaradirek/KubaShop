using KubaShop.Discount.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace KubaShop.Discount.Context
{
    public class DapperContext:DbContext
    {
        //Dapper => İlişkisel veritabanlarında kullanılan bir ORM aracıdır. Dapper konfigürasyonları için işlemler
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
                _configuration = configuration;
            //Connection stringe atama yapacağım
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        //Tabloyu veritabanına yansıtmak için bağlantıyı burdan yapacağım.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MONSTER\\MSSQLSERVERR; initial Catalog=KubaShopDiscountDb; integrated Security=true");
        }
        public DbSet<Coupon> Coupons { get; set; }

        //Dapper dan ulaşacağımız için sistem datayla geliyor bu metot çağrıldığında yeni bir sql bağlantısı oluşturacaksın connection stringi de gönder
        public IDbConnection CreateConnection()=>new SqlConnection(_connectionString);
    }
}
