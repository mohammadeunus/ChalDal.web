using eCom_api.DTOs;

namespace eCom_api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AdminLoginDTO adminLoginDTO);
    }
}
