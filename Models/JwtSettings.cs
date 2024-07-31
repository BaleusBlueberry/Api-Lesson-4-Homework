namespace Api_Lesson_4_Homework.Models
{
    public class JwtSettings
    {
        public required string SecretKey { get; set; }
        public required string Issuer { get; set; }
        public required string Audience { get; set; }

        public static JwtSettings NewInstance() =>
            new() { Audience = "", Issuer = "", SecretKey = "" };
    }
}
