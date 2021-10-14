using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using PaymentGateWay.Core.Services;
using System.Threading.Tasks;
using AutoMapper;
using PaymentGateWay.Core;
using PaymentGateWay.Core.Entities;
using PaymentGateWay.Core.Models;

namespace PaymentGateWay.Services.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public async Task<TransactionModel> AddTransactionAsync(double amount, long transactionTypeId, long userId,
            CancellationToken ct = default)
        {

            var user = await _unitOfWork.User.GetByIdAsync(userId, ct);
            if ((user.UserTypeId == (long)Constant.UserType.Individual)
                && (transactionTypeId == (long)Constant.TransactionType.Refund ||
                   transactionTypeId == (long)Constant.TransactionType.Refund))
            {
                if ((await _unitOfWork.Transaction.CheckUserTransactionAsync(userId, DateTime.Now.Month, ct)) >=
                    Constant.IndividualMaxAmount)
                    throw new ConstraintException("");
            }
            var transaction = new Transaction
            {
                Amount = amount,
                TransactionTypeId = transactionTypeId,
                CreatedById = userId,
                CreatedDate = DateTime.Now,
              
            };

            transaction = await _unitOfWork.Transaction.AddAsync(transaction, ct);
            return _mapper.Map<TransactionModel>(transaction);
        }

        public async Task<List<TransactionModel>> TransactionReport(TransactionFilterModel filter, long userId,
            CancellationToken ct = default)
        {
           var report= await _unitOfWork.Transaction.TransactionReport(filter , userId , ct);
           return _mapper.Map<List<TransactionModel>>(report);
        }
    }
}