using BRE_PaymentProcessor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRE_PaymentProcessor.Repository
{
    public interface IRule
    {
        string ApplyRule(Payment payment);
    }
}
