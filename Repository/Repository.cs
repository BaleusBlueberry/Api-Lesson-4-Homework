using Api_Lesson_4_Homework.Models;
using Api_Lesson_4_Homework.Servises;
using Humanizer;
using MongoDB.Driver;

namespace Api_Lesson_4_Homework.Repository
{
    public class Repository<T>(IMongoService mongo) : IRepository<T> where T : IEntity
    {
        protected readonly IMongoCollection<T> _collection = mongo.GetCollection<T>(typeof(T).Name.Pluralize());
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var items = await _collection.FindAsync(i => true);
            return await items.ToListAsync();
        }

        public virtual async Task<T?> GetById(string id)
        {
            return await _collection.Find(i => i.Id == id).FirstOrDefaultAsync();

        }

        public virtual async Task<IEnumerable<T>?> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> AddItem(T item)
        {
            await _collection.InsertOneAsync(item);
            return item;
        }

        public virtual async Task<T?> UpdateItem(T item, string id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task DeleteItem(int id)
        {
            throw new NotImplementedException();
        }
    }
}