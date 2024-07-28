using MongoDB.Driver;

namespace Api_Lesson_4_Homework.Servises
{
    public interface IMongoService
    {
        public IMongoCollection<T> GetCollection<T>(string name);
    }
}
