using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KubaShop.Catalog.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }
        [BsonIgnore]//BSON=Binary JSON => JSON biçiminin binary formatta saklanmış halidir.MongoDb de dökümanların network üzerinde taşınmasında, diske yazılmasında ve data manipülasyonunda BSON biçimi aktif olarak kullanılır.
        //BsonIgnore=>MongoDb'de bir belge veya koleksiyon içinde belirli alanların dikkate alınmamasını ifade eder.
        public Category Category { get; set; }

    }
}
