using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PaymentGateWay.Core.Models;

namespace PaymentGateWay.Core.Services
{
    public interface ILookupService
    {
        Task<List<UserTypeModel>> GetAllUserTypeAsync(CancellationToken ct = default);
        Task<List<TransactionTypeModel>> GetAllTransactionTypeAsync(CancellationToken ct = default);
        Task<List<BusinessTypeModel>> GetAllBusinessTypAsync(CancellationToken ct = default);
    }
}