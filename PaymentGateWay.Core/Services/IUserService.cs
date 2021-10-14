using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PaymentGateWay.Core.Models;


namespace PaymentGateWay.Core.Services
{
    public interface IUserService
    {
        long? GetUserId(ClaimsPrincipal User);
        Task<bool> IsAdmin(long? userId);
        Task<CompanyUserModel> AddCompanyUserAsync(CompanyUserVm input, CancellationToken ct = default);
        Task<bool> ApproveUserAsync(long userId, CancellationToken ct = default);
         
        Task<IndiviualUserModel> AddIndiviualUserAsync(IndiviualUserVm input, CancellationToken ct = default);

        Task<AuthenticationModel> LoginAsync(LoginModel input, CancellationToken ct = default);
        Task<string> RefreshToken(RefreshTokenModel Model);
        Task<CompanyUserModel> GetUserByIdAsync(long id, CancellationToken ct = default);
        Task<List<CompanyUserModel>> GetAllUsersAsync(UserFilterModel filter, CancellationToken ct = default);
        Task<CompanyUserModel> UpdateUserAsync(CompanyUserModel input, CancellationToken ct = default);
        Task DeleteUserAsync(long id, CancellationToken ct = default);

        Task<AttachmentModel> UploadBusinessCertificationAsync(long? userId,  IFormFile file, CancellationToken ct = default);
    }
}