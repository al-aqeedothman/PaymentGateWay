namespace PaymentGateWay.Core.Models
{
    public class CompanyUserVm
    {
        public string LoginName { get; set; }

        public string Password { get; set; }

        public long UserTypeId { get; set; }

        public CompanyAccountVm CompanyAccount { get; set; }
    }
}
