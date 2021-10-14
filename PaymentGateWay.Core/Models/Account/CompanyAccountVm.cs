namespace PaymentGateWay.Core.Models
{
    public class CompanyAccountVm
    {
        public string ContactName { get; set; }

        public string ContactPhone { get; set; }

        public double Balance { get; set; }

        public long BusinessCertificationId { set; get; }

        public long BusinessId { set; get; }

        public long BusinessTypeId { set; get; }
    }
}