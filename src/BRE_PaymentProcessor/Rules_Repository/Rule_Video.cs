using BRE_PaymentProcessor.Models;
using BRE_PaymentProcessor.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRE_PaymentProcessor.Rules_Repository
{
    public class Rule_Video: IRule
    {
        public string ApplyRule(Payment payment)
        {
            return payment.PaymentType == PaymentType.Video ? "Add Free First Aid Video" : string.Empty;
        }
    }
}
