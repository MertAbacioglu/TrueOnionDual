using Bogus;
using Microsoft.EntityFrameworkCore;
using TrueOnion.DOMAIN.Entities.Concretes;

namespace TrueOnion.PERSISTINCE.Seeds
{
    public static class FakeDataGenerator
    {
        static FakeDataGenerator()
        {
            Init();
        }
        public static void Init()
        {
            #region FakeDepartmentDatas
            Faker<Department> departmentFaker = new();
            departmentFaker.StrictMode(false)
            .RuleFor(x => x.Name, x => x.Commerce.Department())
            .RuleFor(x => x.CreatedDate, x => x.Date.Between(new DateTime(2020, 3, 14), DateTime.Now))
            .RuleFor(x => x.Users, x => null)
            .RuleFor(x => x.Id, x => Guid.NewGuid());
            Departments = departmentFaker.Generate(10);
            #endregion

            #region FakeProductDatas
            Faker<User> userFaker = new();
            userFaker.StrictMode(false)
            .RuleFor(x => x.Id, x => Guid.NewGuid())
            .RuleFor(x => x.CreatedDate, x => x.Date.Between(new DateTime(2020, 3, 14), DateTime.Now))
            .RuleFor(x => x.FirstName, x => x.Person.FirstName)
            .RuleFor(x => x.LastName, x => x.Person.LastName)
            .RuleFor(x => x.Email, x => x.Person.Email)
            .RuleFor(x => x.DepartmentId, x => x.PickRandom(Departments).Id);
            Users = userFaker.Generate(30);
            #endregion
        }
        public static List<Department> Departments { get; set; }
        public static List<User> Users { get; set; }





    }
}