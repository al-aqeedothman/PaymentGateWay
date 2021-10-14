namespace PaymentGateWay.Core.Models
{
    public class Constant
    {
        public const double IndividualMaxAmount = 20000;
        public enum UserType : long
        {

            SystemAdmin = 1,
            Individual = 2,
            Company = 3
        }

        public enum UserStatus : long
        {
            Active = 1,
            Inactive = 2,
            Pending = 3
        }

        public enum TransactionType : long
        {

            Withdrawal = 1,
            Refund = 2,
            Payment = 3
        }
    }
}