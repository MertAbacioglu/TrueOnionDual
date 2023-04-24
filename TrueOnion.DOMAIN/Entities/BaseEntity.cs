using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TrueOnion.DOMAIN.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
        }
        
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
