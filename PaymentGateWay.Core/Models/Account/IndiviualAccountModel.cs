namespace PaymentGateWay.Core.Models
{
    public class IndiviualAccountModel :BaseModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ContactName { get; set; }

        public string ContactPhone { get; set; }

        public double Balance { get; set; }
    }
}