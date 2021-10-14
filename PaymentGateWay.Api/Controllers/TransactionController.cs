using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using PaymentGateWay.Core.Models;
using PaymentGateWay.Core.Services;

namespace PaymentGateWay.Api.Controllers
{
    [Route("api/Transaction")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IUserService _userService;
        public TransactionController(ITransactionService transactionService , IUserService userService)
        {
            _userService = userService;
            _transactionService = transactionService;
        }

        [HttpPost("Payment")]
        [Produces(typeof(TransactionModel))]
        public async Task<IActionResult> AddPayment([Required][FromQuery] double amount, CancellationToken ct = default)
        {
            var userId = _userService.GetUserId(User);
           if (userId == null) 
               return Unauthorized();
            var result = await _transactionService.AddTransactionAsync(amount, (long)Constant.TransactionType.Payment, (long)userId, ct);
            return Ok(result);
        }

        [HttpPost("Withdrawal")]
        [Produces(typeof(TransactionModel))]
        public async Task<IActionResult> Withdrawal([Required][FromQuery] double amount, CancellationToken ct = default)
        {
            var userId = _userService.GetUserId(User);
            if (userId == null)
                return Unauthorized();
            var result = await _transactionService.AddTransactionAsync(amount, (long)Constant.TransactionType.Withdrawal, (long)userId, ct);
            return Ok(result);
        }

        [HttpPut("Refund")]
        [Produces(typeof(TransactionModel))]
        public async Task<IActionResult> Refund([Required][FromQuery] double amount, CancellationToken ct = default)
        {
            var userId = _userService.GetUserId(User);
            if (userId == null)
                return Unauthorized();
            var result = await _transactionService.AddTransactionAsync(amount, (long)Constant.TransactionType.Refund, (long)userId, ct);
            return Ok(result);
        }
    }
}