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
    
    [ApiController]
    public class ScoreController : Controller
    {
        private IShellHighScoreService _shellHS;
        public ScoreController(IShellHighScoreService shellHS)
        {
            _shellHS = shellHS;
        }

        [Authorize]
        [HttpPost("api/user-score")]
        public async Task<IActionResult> UserSccore([FromBody] ScoreModel scoreModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userScore = await _shellHS.getUserScore(scoreModel.userLogin);
                    if(userScore is null)
                    {
                        return StatusCode(404);
                    }
                    return StatusCode(200, new { UserScore = userScore.ScoreDTM });
                }
                catch (Exception)
                {
                    throw new Exception("Something goes wrong");
                }
            }
            return BadRequest("Model is not valid");
        }
    }
}