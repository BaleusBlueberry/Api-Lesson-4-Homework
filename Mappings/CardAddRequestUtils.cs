using Api_Lesson_4_Homework.DTOs_Card;
using Api_Lesson_4_Homework.Models;

namespace Api_Lesson_4_Homework.Mappings;

public static class CardAddRequestExtensions
{
    public static Card ToCard(this CardAddRequest cardAddRequest, string userId)
    {
        return new Card
        {
            UserId = userId,
            Title = cardAddRequest.Title,
            Subtitle = cardAddRequest.Subtitle,
            Description = cardAddRequest.Description,
            Phone = cardAddRequest.Phone,
            Email = cardAddRequest.Email,
            Web = cardAddRequest.Web,
            Image = cardAddRequest.Image,
            Address = cardAddRequest.Address
        };
    }
}


