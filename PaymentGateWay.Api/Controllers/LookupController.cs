using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentGateWay.Core.Models;
using PaymentGateWay.Core.Services;

namespace PaymentGateWay.Api.Controllers
{
    [Route("api/Lookup")]
    public class LookupController : Controller
    {
        private readonly ILookupService _lookupService;
        public LookupController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        [HttpGet("UserTypes")]
        [Produces(typeof(List<UserTypeModel>))]
        public async Task<IActionResult> GetUserTypes( CancellationToken ct = default)
        {
            var result = await _lookupService.GetAllUserTypeAsync( ct);
            return Ok(result);
        }


        [HttpGet("TransactionTypes")]
        [Produces(typeof(List<TransactionTypeModel>))]
        public async Task<IActionResult> TransactionTypes( CancellationToken ct = default)
        {
            var result = await _lookupService.GetAllTransactionTypeAsync( ct);
            return Ok(result);
        }

        [HttpGet("BusinessTypes")]
        [Produces(typeof(List<BusinessTypeModel>))]
        public async Task<IActionResult> BusinessTypes( CancellationToken ct = default)
        {
            var result = await _lookupService.GetAllBusinessTypAsync( ct);
            return Ok(result);
        }
    }
}
