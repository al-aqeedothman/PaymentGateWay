using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PaymentGateWay.Core.Entities;
using PaymentGateWay.Core.Models;
using PaymentGateWay.Core.Repositories;

namespace PaymentGateWay.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly PaymentDbContext _context;
        public TransactionRepository(PaymentDbContext context)
        {
            _context = context;
        }
        public async Task<Transaction> AddAsync(Transaction input, CancellationToken ct = default)
        {
            await _context.Transaction.AddAsync(input);
            await _context.SaveChangesAsync();

            return input;
        }

        public async Task<double> CheckUserTransactionAsync(long userId, int month,
            CancellationToken ct = default)
        {
         return   await _context.Transaction.Where(transaction => transaction.CreatedById == userId &&
                                                            ((DateTime)transaction.CreatedDate).Month == month &&
                                                            transaction.TransactionTypeId !=
                                                            (long)Constant.TransactionType.Payment).SumAsync(transaction=> transaction.Amount);
        }


        public async Task<List<Transaction>> TransactionReport(TransactionFilterModel filter,long userId ,
            CancellationToken ct = default)
        {
            return await _context.Transaction.Where(transaction => transaction.CreatedById == userId &&
                                                                   (
                                                                       (filter.FromDate == null &&
                                                                        filter.ToDate == null)
                                                                       || (filter.FromDate != null &&
                                                                           filter.ToDate == null &&
                                                                           ((DateTime) transaction.CreatedDate).Date >=
                                                                           ((DateTime) filter.FromDate).Date)
                                                                       || (filter.FromDate == null &&
                                                                           filter.ToDate != null &&
                                                                           ((DateTime) transaction.CreatedDate).Date <=
                                                                           ((DateTime) filter.ToDate).Date)
                                                                       || (filter.FromDate != null &&
                                                                           filter.ToDate != null &&
                                                                           ((DateTime) transaction.CreatedDate).Date >=
                                                                           ((DateTime) filter.FromDate).Date &&
                                                                           ((DateTime) transaction.CreatedDate).Date <=
                                                                           ((DateTime) filter.ToDate).Date))
                                                                   &&(filter.TransactionTypeId==null || transaction.TransactionTypeId == filter.TransactionTypeId)
                                                                   ).Include(transaction=>transaction.TransactionType)
                .ToListAsync(ct);
        }
    }
}