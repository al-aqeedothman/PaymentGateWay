using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentGateWay.Core.Models;
using PaymentGateWay.Core.Services;

namespace PaymentGateWay.Api.Controllers
{
    [Route("api/Report")]
    public class ReportController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IUserService _userService;
        public ReportController(ITransactionService transactionService, IUserService userService)
        {
            _userService = userService;
            _transactionService = transactionService;
        }

        [HttpGet("TransactionReport")]
        [Produces(typeof(List<CompanyUserModel>))]
        public async Task<IActionResult> TransactionReport([Required] TransactionFilterModel filter, CancellationToken ct = default)
        {
            var userId = _userService.GetUserId(User);
            if (userId== null)
                return Unauthorized();
            var result = await _transactionService.TransactionReport(filter,(long) userId, ct);
            return Ok(result);
        }
        
    }
}