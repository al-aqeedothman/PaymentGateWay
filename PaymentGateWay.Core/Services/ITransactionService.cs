using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PaymentGateWay.Core.Models;

namespace PaymentGateWay.Core.Services
{
    public interface ITransactionService
    {
        Task<TransactionModel> AddTransactionAsync(double amount , long transactionTypeId , long userId, CancellationToken ct = default);
        Task<List<TransactionModel>> TransactionReport(TransactionFilterModel filter, long userId, CancellationToken ct = default);
    }
}