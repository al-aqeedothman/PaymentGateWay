
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PaymentGateWay.Data;
using PaymentGateWay.Core.Entities;
using PaymentGateWay.Core.Repositories;

namespace PaymentGateWay.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly PaymentDbContext _context;
        public UserRepository(PaymentDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByUserNameAsync(string loginName, CancellationToken ct = default)
        {
            return await _context.User.Where(user => user.LoginName.ToLower().Equals(loginName.ToLower()))
                .Include(user => user.UserStatus)
                .Include(user=>user.UserType)
            .FirstOrDefaultAsync(ct);

        }
        public async Task<User> AddAsync(User input, CancellationToken ct = default)
        {
            await _context.User.AddAsync(input, ct);
            await _context.SaveChangesAsync(ct);
            await _context.Entry(input).ReloadAsync(ct);

            return input;
        }

        public async Task DeleteAsync(long id, CancellationToken ct = default)
        {
            var result = await _context.User.FindAsync(id);
            _context.User.Remove(result);
            await _context.SaveChangesAsync(ct);
        }

        public async Task<List<User>> GetAllAsync(CancellationToken ct = default)
        {
            return await _context.User
                .Include(user => user.UserStatus)
                .Include(user => user.UserType).ToListAsync(ct);
        }

        public async Task<User> GetByIdAsync(long id, CancellationToken ct = default)
        {
            return await _context.User.Where(user => user.Id == id).
                Include(user => user.UserType).FirstOrDefaultAsync(ct);
        }

        public async Task<User> UpdateAsync(User input, CancellationToken ct = default)
        {
            var update = await _context.User.FirstAsync(g => g.Id == input.Id);
            _context.Entry(update).CurrentValues.SetValues(input);
            await _context.SaveChangesAsync(ct);
            return input;
        }
    }
}
