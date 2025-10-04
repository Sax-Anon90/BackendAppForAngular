using Data.Models.Auth;
using Data.Models.BaseResponse;

namespace CoreBusiness.Interfaces
{
    public interface IAuthenticationRepositoryAsync
    {
        Task<BaseReponse<AuthResponse>> AuthenticateUserAsync(AuthRequest authRequest);
    }
}
