using UrlShortener.Entities;
using UrlShortener.Models;

namespace UrlShortener.Services.Interfaces
{
    public interface IUserService
    {
        void Create(CreateUserDto dto);

        User? ValidateUser(AuthenticationRequestBody authRequestBody);
    }
}
