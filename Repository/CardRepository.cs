using Api_Lesson_4_Homework.Models;
using Api_Lesson_4_Homework.Servises;
using Humanizer;
using MongoDB.Driver;

namespace Api_Lesson_4_Homework.Repository
{
    public class CardRepository(IMongoService mongo) : Repository<Card>(mongo)
    {
        protected readonly IMongoCollection<Card> _collection = mongo.GetCollection<Card>(typeof(Card).Name.Pluralize());

        public virtual async Task<IEnumerable<Card>?> FindByName(string name)
        {
            var cursor = await _collection.FindAsync(card =>
                card.Title.Contains(name) && card.Subtitle.Contains(name));
            if (cursor == null) return null;

            return await cursor.ToListAsync();
        }
        public virtual async Task<Card> AddItem(Card card)
        {
            await _collection.InsertOneAsync(card);
            return card;
        }

    }
}
