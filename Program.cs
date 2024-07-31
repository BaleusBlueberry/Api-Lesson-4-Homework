using Api_Lesson_4_Homework.auth;
using Api_Lesson_4_Homework.Models;
using Api_Lesson_4_Homework.Repository;
using Api_Lesson_4_Homework.Servises;

namespace Api_Lesson_4_Homework;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        Utils.setupJwt(builder);
        Utils.setupIdentity(builder);
        // Add services to the container.

        //DI: use the appsettings.json file to fill the JwtSettings object
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
        builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

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

       /* app.UseHttpsRedirection();*/

        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

