using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IdentityAPIWorkshop.Models;
using IdentityAPIWorkshop.Data;
using System.Security.Claims;

namespace ReactWorkshop.Controllers
{
    [Route("api/[controller]/{gameId}/{guess}")]
    [ApiController]
    public class GuessController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public GuessController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public GuessViewModel Get(string gameId, int guess)
        {
            var game = _context.Games.Where(g => g.PublicId == gameId).FirstOrDefault();

            if (game == null)
            {
                return new GuessViewModel() { Correct = false };
            }

            var correct = game.Answer == guess;
            if (correct)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if(userId == null)
                {
                    throw new ArgumentNullException("userId");
                }

                var highscore = _context.Highscores.SingleOrDefault(e => e.UserId == userId);
                if (highscore == null)
                {
                    highscore = new HighscoreModel()
                    {
                        UserId = userId,
                        Score = 1
                    };
                    _context.Highscores.Add(highscore);
                }
                else
                {
                    highscore.Score++;
                }
                _context.SaveChanges();
            }

            return new GuessViewModel() { Correct = game.Answer == guess };
        }
    }
}
