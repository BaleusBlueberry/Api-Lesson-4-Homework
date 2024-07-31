using Api_Lesson_4_Homework.Models;

namespace Api_Lesson_4_Homework.auth;

public interface IJwtTokenService
{
    Task<String> CreateToken(AppUser user);
}
