using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PaymentGateWay.Core.Entities;
using PaymentGateWay.Core.Models;

namespace PaymentGateWay.Core.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction> AddAsync(Transaction input, CancellationToken ct = default);
        Task<double> CheckUserTransactionAsync(long userId, int month, CancellationToken ct = default);
        Task<List<Transaction>> TransactionReport(TransactionFilterModel filter, long userId, CancellationToken ct = default);


    }


}