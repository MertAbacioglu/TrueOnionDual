
using MongoDB.Bson.Serialization.Attributes;

namespace TrueOnion.DOMAIN.Entities.Concretes
{
    public  class Department : BaseEntity
    {

        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}
