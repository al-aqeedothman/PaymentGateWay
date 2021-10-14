using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentGateWay.Core.Entities;
using PaymentGateWay.Core.Models;
using PaymentGateWay.Core.Repositories;

namespace PaymentGateWay.Data.Repositories
{
    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly PaymentDbContext _context;
        public UserTypeRepository(PaymentDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserType>> GetAllAsync(CancellationToken ct = default)
        {
            return await _context.UserType.Where(userType => userType.Id != (long)Constant.UserType.SystemAdmin).ToListAsync(ct);
        }
    }
}