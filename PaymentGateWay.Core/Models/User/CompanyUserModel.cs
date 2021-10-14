using System;

namespace PaymentGateWay.Core.Models
{
    public class CompanyUserModel : BaseModel
    {
       
        public string LoginName { get; set; }

        public string Password { get; set; }

        public UserTypeModel UserType { get; set; }

        public UserStatusModel UserStatus { get; set; }

        public CompanyAccountModel CompanyAccount { get; set; }
    }
}