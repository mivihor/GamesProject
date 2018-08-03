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
using System.ComponentModel.DataAnnotations;

namespace GamesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserService _userService;
        private IPasswordHasher<UserDTM> _hasher;
        private IShellHighScore _highScoreService;
        public UserController(IUserService userService, IPasswordHasher<UserDTM> hasher, IShellHighScore highScoreService)
        {
            _userService = userService;
            _hasher = hasher;
            _highScoreService = highScoreService;
    }

        [HttpPost("/api/create")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreationModel userCM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserCreationNormalization normalization = new UserCreationNormalization(_hasher);
                    UserDTM user = await normalization.Normalize(userCM);
                    if (_userService.ifUserExist(user))
                        return StatusCode(406, $"User with login {user.LoginDTM} already exist");
                    _userService.CreateUser(user);
                    _highScoreService.CreationScoreSetUp(user.LoginDTM);
                    return StatusCode(201);
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