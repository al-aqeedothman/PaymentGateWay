using System;
using System.Threading.Tasks;
using PaymentGateWay.Core;
using PaymentGateWay.Core.Repositories;
using PaymentGateWay.Data.Repositories;

namespace PaymentGateWay.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PaymentDbContext _context;
        private UserRepository _userRepository;
        private AttachmentRepository _attachmentRepository;
        private TransactionRepository _transactionRepository;
        private TransactionTypeRepository _transactionTypeRepository;
        private UserTypeRepository _userTypeRepository;
        private BusinessTypeRepository _businessTypeRepository;
        public UnitOfWork(PaymentDbContext context)
        {
            this._context = context;
        }

        public IUserRepository User => _userRepository = _userRepository ?? new UserRepository(_context);
        public IAttachmentRepository Attachment => _attachmentRepository = _attachmentRepository ?? new AttachmentRepository(_context);
        public ITransactionRepository Transaction => _transactionRepository = _transactionRepository ?? new TransactionRepository(_context);

        public ITransactionTypeRepository TransactionType => _transactionTypeRepository = _transactionTypeRepository ?? new TransactionTypeRepository(_context);
        public IUserTypeRepository UserType => _userTypeRepository = _userTypeRepository ?? new UserTypeRepository(_context);
        public IBusinessTypeRepository BusinessType => _businessTypeRepository = _businessTypeRepository ?? new BusinessTypeRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}