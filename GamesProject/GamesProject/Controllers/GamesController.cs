using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesProject.BusinessLogicLayer.Interfaces;
using GamesProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : Controller
    {
        public IShellGame _shellGame { get; set; }
        public IShellHighScoreService _shellHS;
        public GamesController(IShellGame shellGame, IShellHighScoreService shellHS)
        {
            _shellGame = shellGame;
            _shellHS = shellHS;
        }

        [Authorize]
        [HttpPost("api/shell-game")]
        public async Task<IActionResult> ShellGame([FromBody] ShellGameModel userInput)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int randResult = _shellGame.GameRandomize();
                    bool checkResult = _shellGame.CheckResult(randResult, userInput.userResult);
                    if (checkResult)
                    {
                        _shellGame.win(userInput.Bid, userInput.Login);
                        return Ok(Json(new {ShellGameResult=true, CurrentScore = _shellHS.getUserScore(userInput.Login) }));
                    }
                    else
                    {
                        _shellGame.loose(userInput.Bid, userInput.Login);
                        return Ok(Json(new { ShellGameResult = false, CurrentScore = _shellHS.getUserScore(userInput.Login) }));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.StackTrace);
                }
            }
            return BadRequest("Model is not valid");
        }
    }
}