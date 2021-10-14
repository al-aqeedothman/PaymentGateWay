using System.Threading;
using System.Threading.Tasks;
using PaymentGateWay.Core.Entities;

namespace PaymentGateWay.Core.Repositories
{
    public interface IAttachmentRepository
    {
        Task<Attachment> AddAsync(Attachment attachment, CancellationToken ct = default);
    }
}