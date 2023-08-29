using eCom_api.DTOs;

namespace eCom_api.Interfaces;

public interface IAdminRepository
{
    public Task<UserLoginDTO> LoginAdmin(UserLoginDTO responseDTO);
    public Task<UserLoginDTO> RegisterAdmin(AdminRegisterDTO response);
    public Task<bool> UserExist(string response);
    public Task<UserTokenDTO> generateToken(UserLoginDTO userLoginDTO);
}
