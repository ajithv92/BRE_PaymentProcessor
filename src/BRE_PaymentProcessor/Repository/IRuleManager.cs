using BRE_PaymentProcessor.Models;
using System.Collections.Generic;

namespace BRE_PaymentProcessor.Repository
{
    public interface IRuleManager
    {
        List<string> ExecuteRules(Payment payment);
        void AddRule(IRule rule);
    }
}
