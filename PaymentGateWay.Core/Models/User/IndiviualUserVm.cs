namespace PaymentGateWay.Core.Models
{
    public class IndiviualUserVm
    {
        public string LoginName { get; set; }

        public string Password { get; set; }

        public long UserTypeId { get; set; }

        public IndiviualAccountVm IndiviualAccount { get; set; }
    }
}
