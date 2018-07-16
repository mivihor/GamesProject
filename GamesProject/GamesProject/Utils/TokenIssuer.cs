using Microsoft.Extensions.Configuration;
using GamesProject.BusinessLogicLayer.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GamesProject.Utils
{
    public class TokenIssuer
    {
        private IConfiguration _config;
        public TokenIssuer(IConfiguration config)
        {
            _config = config;
        }

        public string BuildToken(UserDTM userDTM)
        {
            var claims = new []{
                new Claim(JwtRegisteredClaimNames.Sub, userDTM.LoginDTM),
                new Claim(JwtRegisteredClaimNames.FamilyName, userDTM.SurnameDTM),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["AuthOption:SigningKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["AuthOption:Issuer"],
                _config["AuthOption:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
