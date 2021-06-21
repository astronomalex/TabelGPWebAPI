using TabelGPWebAPI.Entities;

namespace TabelGPWebAPI.interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}