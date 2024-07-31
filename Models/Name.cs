using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Api_Lesson_4_Homework.Models;

public class Name
{
    [Required, MinLength(2), MaxLength(256)]
    public required string First { get; set; }
    [Required, MinLength(2), MaxLength(256)]
    public required string Last { get; set; }
    [ValidateNever]
    [MinLength(2), MaxLength(256)]
    public string? Middle { get; set; } = "";
}

