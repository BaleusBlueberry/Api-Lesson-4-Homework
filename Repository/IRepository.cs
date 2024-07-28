using Api_Lesson_4_Homework.Models;

namespace Api_Lesson_4_Homework.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(string id);
        Task<IEnumerable<T?>> FindByName(string name);
        Task<T> AddItem(T item);
        Task<T?> UpdateItem(T item, string id);
        Task DeleteItem(int id);
    }
}
