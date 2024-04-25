using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KubaShop.Catalog.Entities
{
    public class Category
    {
        //MongoDb kullanılacaktır.İlişkisel veritabanı olmadığı için MongoDb'de id ler string değerde tutulur.
        //MongoDb de id olduğunu belirtmek için iki tane attribute var.
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // Id'nin benzersiz yani unique olduğunu belirtmek için BsonType.ObjectId kullanılır.
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
