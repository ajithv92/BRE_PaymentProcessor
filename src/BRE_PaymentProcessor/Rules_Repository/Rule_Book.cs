using BRE_PaymentProcessor.Models;
using BRE_PaymentProcessor.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRE_PaymentProcessor.Rules_Repository
{
    public class Rule_Book: IRule
    {
        public string ApplyRule(Payment payment)
        {
            if (payment.IsBook)
            {
                return "Packaging Slip for Royalty Department";
            }
            return string.Empty;
        }
    }
}
