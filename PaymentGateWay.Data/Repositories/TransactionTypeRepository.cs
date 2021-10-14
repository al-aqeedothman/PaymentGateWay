using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentGateWay.Core.Entities;
using PaymentGateWay.Core.Repositories;

namespace PaymentGateWay.Data.Repositories
{
    public class TransactionTypeRepository  : ITransactionTypeRepository
    {
        private readonly PaymentDbContext _context;
        public TransactionTypeRepository(PaymentDbContext context)
        {
            _context = context;
        }

        public async Task<List<TransactionType>> GetAllAsync(CancellationToken ct = default)
        {
            return await _context.TransactionType.ToListAsync(ct);
        }
    }
}