using Api_Lesson_4_Homework.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AspNetCore.Identity.Mongo;
using MongoDB.Bson;

namespace Api_Lesson_4_Homework.auth
{

    public class Utils
    {
        public static void setupJwt(WebApplicationBuilder builder)
        {
            var jwtSettings = JwtSettings.NewInstance();
            builder.Configuration.GetSection("JwtSettings").Bind(jwtSettings);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience
                };
            });
        }
        public static void setupIdentity(WebApplicationBuilder builder)
        {
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
        }
    }
}
