using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TrueOnion.DOMAIN.Entities.Concretes
{
    public class User : BaseEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}