using System.ComponentModel.DataAnnotations;

namespace Api_Lesson_4_Homework.Models
{
    public class Image
    {
        [Required, Url]
        [MinLength(14)]
        public required string Url { get; set; }

        [Required]
        [MinLength(2), MaxLength(256)]
        //[StringLength(256, MinimumLength = 2)]
        public required string Alt { get; set; }
    }
}
