using AspNetCore.Identity.Mongo.Model;
using MongoDB.Bson;

namespace Api_Lesson_4_Homework.Models
{
    public class AppRole(): MongoRole<ObjectId>()
    {

    }
}
