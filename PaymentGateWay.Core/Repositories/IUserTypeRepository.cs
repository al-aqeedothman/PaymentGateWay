using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PaymentGateWay.Core.Entities;

namespace PaymentGateWay.Core.Repositories
{
    public interface IUserTypeRepository
    {
        Task<List<UserType>> GetAllAsync(CancellationToken ct = default);
    }
}