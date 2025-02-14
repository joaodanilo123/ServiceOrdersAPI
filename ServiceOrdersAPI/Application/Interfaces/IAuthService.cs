using ServiceOrdersManagement.Application.DTOs;

namespace ServiceOrdersManagement.Application.Interfaces
{
    public interface IAuthService
    {
        
        TokenDTO Login(LoginDTO loginDto);

    }
}
