using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesProject.BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GamesProject.BusinessLogicLayer.DataTransferModels;
using GamesProject.Models;
using Microsoft.AspNetCore.Identity;
using GamesProject.Utils;

namespace GamesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserService _userService;
        private IPasswordHasher<UserDTM> _hasher;
        public UserController(IUserService userService, IPasswordHasher<UserDTM> hasher)
        {
            _userService = userService;
            _hasher = hasher;
        }

        [HttpPost("/create")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreationModel userCM )
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserCreationNormalization normalization = new UserCreationNormalization(_hasher);
                    UserDTM user = normalization.Normalize(userCM);
                    _userService.CreateUser(user);
                    return Ok("User has been sucessfully created");
                }
                catch (Exception ex)
                {
                    throw new Exception("Something goes wrong!");
                }
            }
            return BadRequest("Model is not valid ");
        }
    }
}