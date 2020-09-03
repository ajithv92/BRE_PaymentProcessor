using BRE_PaymentProcessor.Models;

namespace BRE_PaymentProcessor.Repository
{
    public interface IRule
    {
        string ApplyRule(Payment payment);
    }
}
