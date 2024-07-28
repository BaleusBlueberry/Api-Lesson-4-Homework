using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using Api_Lesson_4_Homework.Models;
using Api_Lesson_4_Homework.Mappings;
using Image = Api_Lesson_4_Homework.Models.Image;

namespace Api_Lesson_4_Homework.DTOs_Card
{
    public class CardAddRequest
    {
        [Required, MinLength(2), MaxLength(256)]
        public required string Title { get; set; }

        [Required, MinLength(2), MaxLength(256)]
        public required string Subtitle { get; set; }

        [Required, MinLength(2), MaxLength(1024)]
        public required string Description { get; set; }

        [Required, MinLength(9), MaxLength(20), Phone]
        public required string Phone { get; set; }

        [Required, EmailAddress, MinLength(5)]
        public required string Email { get; set; }
        public string? Web { get; set; }
        [Required]
        public required Image Image { get; set; }
        [Required]
        public required Address Address { get; set; }
    }
}
