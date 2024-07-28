using MongoDB.Driver;

namespace Api_Lesson_4_Homework.Servises
{
    public class MongoService : IMongoService
    {
        public readonly IMongoDatabase _database;
        public MongoService(IConfiguration config)
        {

            var connectionString = config.GetConnectionString("DefaultConnection");
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(config["DatabaseName"]);
        }

        //method
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }
    }
}
