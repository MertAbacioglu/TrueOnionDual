using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using TrueOnion.DOMAIN.Entities;
using TrueOnion.DOMAIN.Entities.Concretes;

namespace TrueOnion.PERSISTINCE.Configurations.MongoConfigurations
{
    public class MongoMap : BsonClassMap<BaseEntity>
    {
        public void ConfigureMongoMapping()
        {
            IEnumerable<Type> baseEntityTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsSubclassOf(typeof(BaseEntity)) && !t.IsAbstract);

            foreach (Type type in baseEntityTypes)
            {
                if (!IsClassMapRegistered(type))
                {

                    Type classMapDefinition = typeof(BsonClassMap<>);
                    Type classMapType = classMapDefinition.MakeGenericType(type);
                    BsonClassMap? classMap = (BsonClassMap)Activator.CreateInstance(classMapType);
                    BsonClassMap.RegisterClassMap(classMap);
                }
            }

        }
    }
}