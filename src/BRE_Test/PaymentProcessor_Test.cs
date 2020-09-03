using BRE_PaymentProcessor.Implementation;
using BRE_PaymentProcessor.Models;
using BRE_PaymentProcessor.Repository;
using BRE_PaymentProcessor.Rules_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BRE_Test
{
    [TestClass]
    class PaymentProcessor_Test
    {
        private IRuleManager ruleManager;

        public PaymentProcessor_Test()
        {
            ruleManager = new RuleManager();
        }

        [TestMethod]
        public void Add_Physical_Product_Rule()
        {
            Payment payment = new Payment
            {
                PaymentType = PaymentType.PhysicalProduct,
                ProductName = "Computer"
            };
            IRule rule = new Rule_PhysicalProduct();
            ruleManager.AddRule(rule);
            var ruleResult = ruleManager.ExecuteRules(payment);
            bool isPhysicalRuleApplied = ruleResult.Contains("Generate Packing Slip");
            Assert.IsTrue(isPhysicalRuleApplied);
        }

        [TestMethod]
        public void Add_Book_Rule()
        {
            Payment payment = new Payment
            {
                PaymentType = PaymentType.PhysicalProduct,
                ProductName = "Harry Potter Book",
                IsBook = true
            };
            IRule rule = new Rule_Book();
            ruleManager.AddRule(rule);
            var ruleResult = ruleManager.ExecuteRules(payment);
            bool isBookRuleApplied = ruleResult.Contains("Packaging Slip for Royalty Department");
            Assert.IsTrue(isBookRuleApplied);
        }

        [TestMethod]
        public void Add_Book_And_Physical_Rule()
        {
            Payment payment = new Payment
            {
                PaymentType = PaymentType.PhysicalProduct,
                ProductName = "Harry Potter Book",
                IsBook = true
            };
            IRule rule = new Rule_Book();
            ruleManager.AddRule(rule);
            // Both rule so that both rules will be added to rule result;
            rule = new Rule_PhysicalProduct();
            ruleManager.AddRule(rule);
            var ruleResult = ruleManager.ExecuteRules(payment);
            bool isBookRuleApplied = ruleResult.Contains("Packing Slip for Royalty Department");
            Assert.IsTrue(isBookRuleApplied);
            bool isPhysicalRuleApplied = ruleResult.Contains("Generate Packing Slip");
            Assert.IsTrue(isPhysicalRuleApplied);
        }

        [TestMethod]
        public void Add_Membership_Rule()
        {
            Payment payment = new Payment
            {
                PaymentType = PaymentType.Membership,
                ProductName = "Golf Club Membership",
                IsBook = false
            };
            IRule rule = new Rule_MemberShip();
            ruleManager.AddRule(rule);
            rule = new Rule_Email();
            ruleManager.AddRule(rule);
            var ruleResult = ruleManager.ExecuteRules(payment);
            bool isMembershipRuleApplied = ruleResult.Contains("Activate Membership");
            Assert.IsTrue(isMembershipRuleApplied);
            bool isActivationMailSent = ruleResult.Contains("Mail To Owner About Membership Activation");
            Assert.IsTrue(isActivationMailSent);
        }

        [TestMethod]
        public void Add_Upgrade_Membership_Rule()
        {
            Payment payment = new Payment
            {
                PaymentType = PaymentType.UpgradeMemberShip,
                ProductName = "Golf Club Membership",
                IsBook = false
            };
            IRule rule = new Rule_UpgradeMembership();
            ruleManager.AddRule(rule);
            rule = new Rule_Email();
            ruleManager.AddRule(rule);
            var ruleResult = ruleManager.ExecuteRules(payment);
            bool isMembershipUpgradeRuleApplied = ruleResult.Contains("Upgrade Membership");
            Assert.IsTrue(isMembershipUpgradeRuleApplied);
            bool isActivationMailSent = ruleResult.Contains("Mail To Owner About Membership Upgradation");
            Assert.IsTrue(isActivationMailSent);
        }

        [TestMethod]
        public void Add_Video_Rule()
        {
            Payment payment = new Payment
            {
                PaymentType = PaymentType.Video,
                ProductName = "Learning to Ski",
                IsBook = false
            };
            IRule rule = new Rule_Video();
            ruleManager.AddRule(rule);
            var ruleResult = ruleManager.ExecuteRules(payment);
            bool isVideoRuleApplied = ruleResult.Contains("Add Free First Aid Video");
            Assert.IsTrue(isVideoRuleApplied);
        }

        [TestMethod]
        public void Add_Commission_Rule_For_Physical_Product()
        {
            Payment payment = new Payment
            {
                PaymentType = PaymentType.PhysicalProduct,
                ProductName = "Mobile",
                IsBook = false
            };
            IRule rule = new Rule_Commision();
            ruleManager.AddRule(rule);
            var ruleResult = ruleManager.ExecuteRules(payment);
            bool isCommissionRuleApplied = ruleResult.Contains("Commission Payment to Agent");
            Assert.IsTrue(isCommissionRuleApplied);
        }

        [TestMethod]
        public void Add_Commission_Rule_For_Book()
        {
            Payment payment = new Payment
            {
                PaymentType = PaymentType.Book,
                ProductName = "My Story",
                IsBook = true
            };
            IRule rule = new Rule_Commision();
            ruleManager.AddRule(rule);
            var ruleResult = ruleManager.ExecuteRules(payment);
            bool isCommissionRuleApplied = ruleResult.Contains("Commission Payment to Agent");
            Assert.IsTrue(isCommissionRuleApplied);
        }
    }
}
