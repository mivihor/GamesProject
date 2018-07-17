using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GamesProject.Models;
using GamesProject.BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using GamesProject.BusinessLogicLayer.DataTransferModels;
using GamesProject.Utils;

namespace GamesProject.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly IConfiguration _config;
        private IUserService _userService;
        private IPasswordHasher<UserDTM> _hasher;
        public TokenController(IConfiguration config, IUserService userService, IPasswordHasher<UserDTM> hasher)
        {
            _config = config;
            _userService = userService;
            _hasher = hasher;
        }


        [HttpPost("api/auth")]
        public async Task<IActionResult> CreateToken([FromBody] LoginModel loginModel)
        {
            try
            {
                IActionResult response = Unauthorized();
                var userDTM = await _userService.GetUserByLogin(loginModel.Login);
                
                if(userDTM != null)
                {
                    if(_hasher.VerifyHashedPassword(userDTM,userDTM.PasswordDTM,loginModel.Password) == PasswordVerificationResult.Success)
                    {
                        TokenIssuer tokenIssuer = new TokenIssuer(_config);
                        var tokenString = tokenIssuer.BuildToken(userDTM);
                        return Ok(new { token = tokenString });
                    }
                }
                return response;
            }catch(Exception ex)
            {
                throw new Exception("Failed to create Token");
            }

            BadRequest("Failed to issue token");
        }
    }
}