using BRE_PaymentProcessor.Models;
using BRE_PaymentProcessor.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRE_PaymentProcessor.Rules_Repository
{
    public class Rule_PhysicalProduct: IRule
    {
        public string ApplyRule(Payment payment)
        {
            return payment.PaymentType == PaymentType.PhysicalProduct ? "Generate Packing Slip" : string.Empty;
        }
    }
}
