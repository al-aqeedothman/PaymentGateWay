namespace PaymentGateWay.Core.Models
{
    public class TransactionModel :BaseModel
    {
        
        public double Amount { get; set; }

        public TransactionTypeModel TransactionType { get; set; }
    }
}