﻿using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json.Serialization;

namespace Api_Lesson_4_Homework.Models;

public class Card : IEntity
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string? Id { get; set; }

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

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<string> Likes { get; set; } = [];

    public string BizNumber { get; set; } = Guid.NewGuid().ToString();
    [Required]
    [JsonPropertyName("user_id")]
    public required string UserId { get; set; }
}
