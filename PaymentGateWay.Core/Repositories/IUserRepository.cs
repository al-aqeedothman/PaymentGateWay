using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PaymentGateWay.Core.Entities;

namespace PaymentGateWay.Core.Repositories
{
  public  interface IUserRepository
    {
        Task<User> GetByUserNameAsync(string userName, CancellationToken ct = default);
        Task<User> AddAsync(User input, CancellationToken ct = default);
        Task<User> GetByIdAsync(long id, CancellationToken ct = default);
        Task<List<User>> GetAllAsync(CancellationToken ct = default);
        Task<User> UpdateAsync(User input, CancellationToken ct = default);
        Task DeleteAsync(long id, CancellationToken ct = default);
    }
}
