using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using PaymentGateWay.Core;
using PaymentGateWay.Core.Models;
using PaymentGateWay.Core.Services;

namespace PaymentGateWay.Services.Services
{
    public class LookupService : ILookupService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LookupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

    public async Task<List<UserTypeModel>> GetAllUserTypeAsync(CancellationToken ct = default)
        {
            var uerTypes = await _unitOfWork.UserType.GetAllAsync(ct);
            return _mapper.Map<List<UserTypeModel>>(uerTypes);
        }
    public async Task<List<TransactionTypeModel>> GetAllTransactionTypeAsync(CancellationToken ct = default)
        {
            var transactionTypes = await _unitOfWork.TransactionType.GetAllAsync(ct);
            return _mapper.Map<List<TransactionTypeModel>>(transactionTypes);
        }
    public async Task<List<BusinessTypeModel>> GetAllBusinessTypAsync(CancellationToken ct = default)
        {
         var businessTypes=  await _unitOfWork.BusinessType.GetAllAsync(ct);
         return _mapper.Map<List<BusinessTypeModel>>(businessTypes);
        }
    }
}