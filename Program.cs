using Api_Lesson_4_Homework.Models;
using Api_Lesson_4_Homework.Repository;
using Api_Lesson_4_Homework.Servises;
using AspNetCore.Identity.Mongo;
using MongoDB.Bson;

namespace Api_Lesson_4_Homework;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddIdentityMongoDbProvider<AppUser, AppRole, ObjectId>(identity =>
        {
            identity.Password.RequiredLength = 9;
            identity.Password.RequireLowercase = true;
            identity.Password.RequireUppercase = true;
            identity.Password.RequireDigit = true;
            identity.User.RequireUniqueEmail = true;
            identity.Password.RequireNonAlphanumeric = true;
            identity.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        }, mongo =>
        {
            mongo.ConnectionString = connectionString;
        });

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSingleton<IMongoService, MongoService>();

        builder.Services.AddSingleton<IRepository<Card>, CardRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

