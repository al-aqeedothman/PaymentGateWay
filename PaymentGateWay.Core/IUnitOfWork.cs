using System;
using System.Threading.Tasks;
using PaymentGateWay.Core.Repositories;

namespace PaymentGateWay.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IAttachmentRepository Attachment { get; }
        ITransactionRepository Transaction { get; }
        ITransactionTypeRepository TransactionType { get; }
        IUserTypeRepository UserType { get; }
        IBusinessTypeRepository BusinessType { get; }


    }
}