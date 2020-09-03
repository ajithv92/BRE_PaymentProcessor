using BRE_PaymentProcessor.Models;
using BRE_PaymentProcessor.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BRE_PaymentProcessor.Implementation
{
    public class RuleManager : IRuleManager
    {
        private List<IRule> _rules = new List<IRule>();

        public RuleManager()
        {

        }

        public List<string> ExecuteRules(Payment payment)
        {
            return (_rules.Select(rule =>
            {
                return rule.ApplyRule(payment);
            })).ToList();
        }


        public void AddRule(IRule rule)
        {
            _rules.Add(rule);
        }
    }
}
