using Api_Lesson_4_Homework.auth;
using Api_Lesson_4_Homework.Mappings;
using Api_Lesson_4_Homework.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api_Lesson_4_Homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        IJwtTokenService JwtTokenService
    ) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            AppUser user = dto.ToAppUser();
            var result = await userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await userManager.FindByEmailAsync(dto.Email);

            if (user == null) return Unauthorized("user not found");

           /* var result = await signInManager.PasswordSignInAsync(dto.Email, dto.Password, false, false);*/
           var isLoggedIn = await userManager.CheckPasswordAsync(user, dto.Password);

            if (isLoggedIn)
            {
                var token = await JwtTokenService.CreateToken(user);
                return Ok(token);
            }

            //TODO : Implement JWT Token
            return Unauthorized();
        }
    }
}
