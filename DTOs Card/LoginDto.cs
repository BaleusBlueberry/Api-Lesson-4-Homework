using System.ComponentModel.DataAnnotations;

namespace Api_Lesson_4_Homework.Mappings
{
    public class LoginDto
    {
        [Required, EmailAddress, MaxLength(256)]
        public required string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*-]).{7,20}$",
            ErrorMessage = "Password must be 7 to 20 characters and contain at least one lowercase letter, one uppercase letter, one digit, and one special characters.")]
        public required string Password { get; set; }
    }
}
