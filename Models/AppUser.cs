using AspNetCore.Identity.Mongo.Model;
using DnsClient.Protocol;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Api_Lesson_4_Homework.Models;

public class AppUser() : MongoUser<ObjectId>() //UserName, Email, PasswordHash, Id
{
    [BsonRequired]
    public required Name Name { get; set; }

    [BsonRequired]
    public required Image Image { get; set; }

    [BsonRequired]
    public required Address Address { get; set; }

    [BsonRequired]
    public bool IsBusiness { get; set; }

    public bool IsAdmin { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

