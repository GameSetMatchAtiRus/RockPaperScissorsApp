using Microsoft.AspNetCore.Mvc;
using RockPaperScissors.DBContext;
using RockPaperScissors.DBModels;
using System;

namespace RockPaperScissors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly RPSDataContext _context;

        public MatchController(RPSDataContext context)
        {
            _context = context;
        }

        // POST /api/match
        [HttpPost]
        public async Task<IActionResult> CreateMatch([FromBody] MatchHistory request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user1 = await _context.Users.FindAsync(request.Player1Id);
            var user2 = await _context.Users.FindAsync(request.Player2Id);

            if (user1 == null || user2 == null)
                return NotFound();

            if (user1.Balance < request.Bet || user2.Balance < request.Bet)
                return BadRequest("Недостаточный баланс одного из игроков.");

            user1.Balance -= request.Bet;
            user2.Balance -= request.Bet;

            var match = new MatchHistory
            {
                Bet = request.Bet,
                Player1Id = request.Player1Id,
                Player2Id = request.Player2Id,
                PlayedAt = DateTime.Now
            };

            _context.MatchHistory.Add(match);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Матч создан.", MatchId = match.Id });
        }
    }
}
