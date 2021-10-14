
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PaymentGateWay.Core.Models;
using PaymentGateWay.Core.Services;
using System.Net;

namespace PaymentGateWay.Api.Controllers
{

    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
     

        public UserController(IUserService userService)
        {
            _userService = userService;
          
        }



        [HttpPost("CompanyRegistration")]
        [Produces(typeof(CompanyUserModel))]
        public async Task<IActionResult> AddCompany([Required][FromBody] CompanyUserVm model, CancellationToken ct = default)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.AddCompanyUserAsync(model, ct);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("IndividualRegistration")]
        [Produces(typeof(IndiviualUserModel))]
        public async Task<IActionResult> AddIndividual([Required][FromBody] IndiviualUserVm model, CancellationToken ct = default)
        {
            var result = await _userService.AddIndiviualUserAsync(model, ct);
            return Ok(result);
        }


        [HttpPost("Login")]
        [Produces(typeof(string))]
        public async Task<IActionResult> Login([Required][FromBody] LoginModel model, CancellationToken ct = default)
        {
            var user = await _userService.LoginAsync(model, ct);
            if (user == null)
                return Unauthorized();           
            return Ok(user);
        }


        [HttpPost("RefreshToken")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshTokenModel model)
        {
            var result = await _userService.RefreshToken(model);
            if (string.IsNullOrEmpty(result)) return BadRequest();
            return Ok(result);

        }
        [HttpPost("Approve/UserId")]
        [Produces(typeof(string))]
        public async Task<IActionResult> Approve([Required] long userId, CancellationToken ct = default)
        {
            var isAdmin =await _userService.IsAdmin(_userService.GetUserId(User));
            if (! isAdmin)
                return Unauthorized();
            var result = await _userService.ApproveUserAsync(userId, ct);
            return Ok(result);
        }


        [HttpGet("GetByID/Id")]
        [Produces(typeof(CompanyUserModel))]
        public async Task<IActionResult> GetById(long id, CancellationToken ct = default)
        {
            var userId = _userService.GetUserId(User);
            if (userId == null)
                return Unauthorized();
            var result = await _userService.GetUserByIdAsync(id, ct);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        [Produces(typeof(List<CompanyUserModel>))]
        public async Task<IActionResult> GetAll([Required] UserFilterModel  filter ,CancellationToken ct = default)
        {
            var isAdmin = await _userService.IsAdmin(_userService.GetUserId(User));
            if (!isAdmin)
                return Unauthorized();
            var result = await _userService.GetAllUsersAsync(filter,ct); 
            return Ok(result);
        }

        [HttpPut("Update")]
        [Produces(typeof(CompanyUserModel))]
        public async Task<IActionResult> Update([Required][FromBody] CompanyUserModel model, CancellationToken ct = default)
        {
            var userId = _userService.GetUserId(User);
            if (userId == null)
                return Unauthorized();
            var result = await _userService.UpdateUserAsync(model, ct);
            return Ok(result);
        }

        [HttpDelete("Delete")]

        public async Task<IActionResult> Delete(long id, CancellationToken ct = default)
        {
            var userId = _userService.GetUserId(User);
            if (userId == null)
                return Unauthorized();
            await _userService.DeleteUserAsync(id, ct);
            return NoContent();
        }

        [HttpGet("UserTypes")]
        [Produces(typeof(List<UserTypeModel>))]
        public async Task<IActionResult> GetUserTypes([Required] UserFilterModel filter, CancellationToken ct = default)
        {
            var result = await _userService.GetAllUsersAsync(filter, ct);
            return Ok(result);
        }
    }
}
