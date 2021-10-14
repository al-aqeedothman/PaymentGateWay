namespace PaymentGateWay.Core.Models
{
    public class AuthenticationModel
    {
        public long Id { get; set; }
        public string LoginName { get; set; }
        public string RefreshToken { get; set; }
        public string Token { get; set; }
    }
}