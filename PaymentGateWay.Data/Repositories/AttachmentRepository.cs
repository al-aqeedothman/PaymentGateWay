using System.Threading;
using System.Threading.Tasks;
using PaymentGateWay.Core.Entities;
using PaymentGateWay.Core.Repositories;

namespace PaymentGateWay.Data.Repositories
{
    public class AttachmentRepository : IAttachmentRepository
    {
        private readonly PaymentDbContext _context;
        public AttachmentRepository(PaymentDbContext context)
        {
            _context = context;
        }
        public async Task<Attachment> AddAsync(Attachment attachment, CancellationToken ct = default)
        {
            await _context.Attachment.AddAsync(attachment,ct);
            await _context.SaveChangesAsync(ct);
            await _context.Entry(attachment).ReloadAsync(ct);
            return attachment;
        }
    }
}