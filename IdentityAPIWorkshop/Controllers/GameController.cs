using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IdentityAPIWorkshop.Models;
using IdentityAPIWorkshop.Data;
using Microsoft.AspNetCore.Authorization;

namespace IdentityAPIWorkshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class GameController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public GameController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/game
        [HttpPost]
        public CreateGameViewModel Post()
        {
            var publicId = Guid.NewGuid().ToString();
            var answer = new Random().Next(10);
            _context.Add(new GameModel() { PublicId = publicId, Answer = answer });
            _context.SaveChanges();
            return new CreateGameViewModel() { GameId = publicId };
        }
    }
}
