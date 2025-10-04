using CoreBusiness.Interfaces;
using Data.Context;
using Data.Models.Auth;
using Data.Models.BaseResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Implementation
{
    public class AuthenticationRepositoryAsync : IAuthenticationRepositoryAsync
    {
        private readonly IUserRolesRepositoryAsync _userRolesRepository;
        private readonly IJwtServiceAsync _jwtService;
        private readonly AppDbContext _appDbContext;
        public AuthenticationRepositoryAsync(IUserRolesRepositoryAsync _userRolesRepository,
            IJwtServiceAsync _jwtService, AppDbContext _appDbContext)
        {
            this._userRolesRepository = _userRolesRepository;
            this._jwtService = _jwtService;
            this._appDbContext = _appDbContext;

        }

        public async Task<BaseReponse<AuthResponse>> AuthenticateUserAsync(AuthRequest authRequest)
        {
            var user = await _appDbContext.Users.SingleOrDefaultAsync(x => x.Email == authRequest.Email);

            if (user is null)
                return new BaseReponse<AuthResponse>() { Succeeded = false, Message = "Invalid Credentials", };

            if (!BCrypt.Net.BCrypt.Verify(authRequest.Password, user.PasswordHash))
                return new BaseReponse<AuthResponse>() { Succeeded = false, Message = "Invalid Credentials" };

            var userRoles = await _userRolesRepository.GetUserRolesAsync(user.Id);

            var authToken = _jwtService.GenerateSecurityToken(userRoles.ToList(), user.Id);

            return new BaseReponse<AuthResponse>
            {
                Succeeded = true,
                Message = "Successful authentication",
                ResponseData = new AuthResponse()
                {
                    FullName = user.FullName,
                    EmployeeId = user.Id,
                    Token = authToken
                }
            };
        }
    }
}
