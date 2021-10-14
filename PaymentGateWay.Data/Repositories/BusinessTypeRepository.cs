using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentGateWay.Core.Entities;
using PaymentGateWay.Core.Repositories;

namespace PaymentGateWay.Data.Repositories
{
    public class BusinessTypeRepository : IBusinessTypeRepository
    {
        private readonly PaymentDbContext _context;
        public BusinessTypeRepository(PaymentDbContext context)
        {
            _context = context;
        }

        public async Task<List<BusinessType>> GetAllAsync(CancellationToken ct = default)
        {
            return await _context.BusinessType.ToListAsync(ct);
        }
    }
}