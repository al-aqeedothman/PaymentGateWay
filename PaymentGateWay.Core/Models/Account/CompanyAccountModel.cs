namespace PaymentGateWay.Core.Models
{
    public class CompanyAccountModel :BaseModel
    {
        public string ContactName { get; set; }

        public string ContactPhone { get; set; }

        public double Balance { get; set; }

        public long BusinessId { set; get; }

        public BusinessTypeModel BusinessType { set; get; }

        public AttachmentModel BusinessCertification { set; get; }
    }
}