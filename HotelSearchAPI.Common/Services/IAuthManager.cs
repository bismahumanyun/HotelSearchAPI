using HotelSearchAPI.Common.DTOs;
using HotelSearchAPI.Common.Models;
using System.Threading.Tasks;

namespace HHotelSearchAPI.Common.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDTO userDTO);
        Task<string> CreateToken();
        Task<string> CreateRefreshToken();
        Task<TokenRequest> VerifyRefreshToken(TokenRequest request);
    }
}
