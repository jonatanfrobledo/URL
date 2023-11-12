using UrlShortener.Data;
using UrlShortener.Entities;
using UrlShortener.Services.Interfaces;
using UrlShortener.Models;

namespace UrlShortener.Services.Implementations
{
    public class UserService : IUserService
    {
        private UrlShortenerContext _context;
        public UserService(UrlShortenerContext context)
        {
            _context = context;
        }

        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.Email == authRequestBody.Email && p.Password == authRequestBody.Password);
        }

        public void Create(CreateUserDto dto)
        {
            User newUser = new User()
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }


    }
}
