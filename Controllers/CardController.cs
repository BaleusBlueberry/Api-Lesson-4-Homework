using Api_Lesson_4_Homework.DTOs_Card;
using Api_Lesson_4_Homework.Mappings;
using Api_Lesson_4_Homework.Models;
using Api_Lesson_4_Homework.Repository;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_Lesson_4_Homework.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly IRepository<Card> _repo;

        public CardController(IRepository<Card> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostCard([FromBody] CardAddRequest dto)
        {
            var card = dto.ToCard("TheUserId");
            var result = await _repo.AddItem(card);

            return CreatedAtAction(nameof(Get), new { id = card.Id }, card);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCards()
        {
            var cards = await _repo.GetAll();
            return Ok(cards);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var card = await _repo.GetById(id);
            if (card == null) return NotFound();
            return Ok(card);
        }
    }
}