using CoreBusiness.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Implementation
{
    public class JwtServiceAsync : IJwtServiceAsync
    {
        private readonly IConfiguration _configuration;
        public JwtServiceAsync(IConfiguration _configuration)
        {
            this._configuration = _configuration;
        }

        public string GenerateSecurityToken(List<string> userRoles, int UserId)
        {
            var claims = new List<Claim>
            {

                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            if (userRoles.Any())
            {
                foreach (var role in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            claims.Add(new Claim(JwtRegisteredClaimNames.NameId, UserId.ToString()));
            claims.Add(new Claim("UserId", UserId.ToString()));

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                                            issuer: _configuration["JwtSettings:Issuer"],
                                            audience: _configuration["JwtSettings:Audience"],
                                            claims: claims,
                                            expires: DateTime.Now.AddHours(24),
                                            signingCredentials: signingCredentials);


            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
