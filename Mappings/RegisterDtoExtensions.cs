using Api_Lesson_4_Homework.Models;

namespace Api_Lesson_4_Homework.Mappings
{
    public static class RegisterDtoExtensions
    {
        public static AppUser ToAppUser(this RegisterDto registerDto)
        {
            return new AppUser
            {
                //we need to login with email
                UserName = registerDto.Email,
                Email = registerDto.Email,
                PhoneNumber = registerDto.Phone,

                //Password is ignored for now - the framrwork will add it

                Name = registerDto.Name,
                Image = registerDto.Image,
                Address = registerDto.Address,
                IsBusiness = registerDto.IsBusiness,
            };
        }
    }
}
