using BRE_PaymentProcessor.Models;
using BRE_PaymentProcessor.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRE_PaymentProcessor.Rules_Repository
{
    public class Rule_Commision: IRule
    {
        public string ApplyRule(Payment payment)
        {
            if (payment.PaymentType == PaymentType.PhysicalProduct || payment.IsBook)
            {
                return "Commission Payment to Agent";
            }
            return string.Empty;
        }
    }
}
