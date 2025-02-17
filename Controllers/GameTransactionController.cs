using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissors.DBContext;
using RockPaperScissors.DBModels;

namespace RockPaperScissors.Controllers
{
    public class TransactionRequest
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public decimal Amount { get; set; }
    }

    public class GameTransactionController : Controller
    {
        [ApiController]
        [Route("api/[controller]")]
        public class TransactionsController : ControllerBase
        {
            private readonly RPSDataContext _context;

            public TransactionsController(RPSDataContext context)
            {
                _context = context;
            }

            [HttpPost]
            public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionRequest request)
            {
                var fromUser = await _context.Users.FindAsync(request.FromUserId);
                var toUser = await _context.Users.FindAsync(request.ToUserId);

                if (fromUser == null || toUser == null) return NotFound("Пользователь не найден");
                if (fromUser.Balance < request.Amount) return BadRequest("Недостаточный баланс");

                fromUser.Balance -= request.Amount;
                toUser.Balance += request.Amount;

                var transaction = new GameTransaction
                {
                    Id = Guid.NewGuid(),
                    FromUserId = request.FromUserId,
                    ToUserId = request.ToUserId,
                    Amount = request.Amount,
                    CreatedAt = DateTime.Now,
                };

                _context.GameTransactions.Add(transaction);
                await _context.SaveChangesAsync();

                return Ok(transaction);
            }
        }

            public class CreateTransactionRequest
            {
                public Guid FromUserId { get; set; }
                public Guid ToUserId { get; set; }
                public uint Amount { get; set; }
            }

    }
}
