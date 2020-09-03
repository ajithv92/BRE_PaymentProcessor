namespace BRE_PaymentProcessor.Models
{
    public class Payment
    {
        public PaymentType PaymentType { get; set; }
        public string ProductName { get; set; }
        public bool IsBook { get; set; }
    }
}
