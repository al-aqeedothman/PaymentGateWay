using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PaymentGateWay.Core.Entities;

namespace PaymentGateWay.Core.Repositories
{
    public interface IBusinessTypeRepository
    {

        Task<List<BusinessType>> GetAllAsync(CancellationToken ct = default);
    }
}