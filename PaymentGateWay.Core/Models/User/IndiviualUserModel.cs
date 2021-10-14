namespace PaymentGateWay.Core.Models
{
    public class IndiviualUserModel : BaseModel
    {
        public string LoginName { get; set; }

        public string Password { get; set; }

        public UserTypeModel UserType { get; set; }

        public UserStatusModel UserStatus { get; set; }

        public IndiviualAccountModel IndiviualAccount { get; set; }
    }
}