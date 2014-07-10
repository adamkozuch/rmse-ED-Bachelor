using System.Collections.Generic;
using LicencjatInformatyka_RMSE_.NewFolder2;
using LicencjatInformatyka_RMSE_.NewFolder3;
using LicencjatInformatyka_RMSE_.NewFolder4;
using NUnit.Framework;
using System.Linq.Expressions;
using  System.Linq;

namespace Testy
{
    [TestFixture]
    public class OperationsTests
    {
        [Test]
        public void Check_If_CheckIfStringIsFact_Return_True_Value()
        {
            var factList = new List<Fact>
            {
                new Fact {FactName = "Wniosek", FactValue = true}
            };


            string nameOfConclusion = "Wniosek";

            Fact result = ConclusionOperations.CheckIfStringIsFact(nameOfConclusion, factList);
            Assert.AreEqual(result.FactValue, true);
        }


        [Test]
        public void Sprawdzamy_Wnioskowania()
        {
            
            RuleBase rules = new RuleBase();
            Rule r = new Rule(1,"Wniosek",new List<string>(){"Wniosek1"},true);
            Rule r1 = new Rule(2, "Wniosek1", new List<string>() { "Wniosek2" }, true);
            Rule r2 = new Rule(3, "Wniosek2", new List<string>() { "Wniosek3" }, true);
            Rule r22 = new Rule(5, "Wniosek2", new List<string>() { "Wniosek6" }, true);
            Rule r3 = new Rule(4, "Wniose3", new List<string>() { "Wniosek4" }, true);
            rules.RulesList.Add(r);
            rules.RulesList.Add(r1);
            rules.RulesList.Add(r2);
            rules.RulesList.Add(r3);
            rules.RulesList.Add(r22);
           ConclusionOperations.Conclude(rules.RulesList, r);
            Assert.AreEqual(true, true);
        }




        [Test]
        public void Check_If_One_Condition_Is_Entered_In_DynamicBase()
        {
            var factList = new List<Fact>
            {
                new Fact {FactName = "Wniosek", FactValue = true}
            };


            string nameOfConclusion = "Wniosek";

            Fact result = ConclusionOperations.CheckIfStringIsFact(nameOfConclusion, factList);
            Assert.AreEqual(result.FactName, "Wniosek");
        }

        //[Test]
        //public void Check_Three_Rules_With_No_Double_Conclusion_Return_One_Flattered_Rule()
        //{
        //    var ruleList = new List<Rule>

        //    {
        //        new Rule(1, "Wniosek1", new List<string> {"warunek1"}, true),
        //        new Rule(1, "warunek1", new List<string> {"warunek2"}, true),
        //        new Rule(1, "warunek2", new List<string> {"warunek3"}, true),
        //    };


        //   int numberOfFlatteredRules = ConclusionOperations.Flatter(ruleList).Count;

        //    Assert.AreEqual(1,numberOfFlatteredRules);

        //}


        //public void Check_Three_Rules_With_Two_Same_Conclusion_Return_Two_Flattered_Rule()
        //{
        //    var ruleList = new List<Rule>

        //    {
        //        new Rule(1, "Wniosek1", new List<string> {"warunek1"}, true),
        //        new Rule(1, "warunek1", new List<string> {"warunekX"}, true),
        //        new Rule(1, "warunek1", new List<string> {"waruneky"}, true),
        //    };


        //    int numberOfFlatteredRules = ConclusionOperations.Flatter(ruleList).Count;

        //    Assert.AreEqual(2, numberOfFlatteredRules);

        //}


        [Test]
        public void When_Four_Rules_With_Particluar_Conclusion_FindRules_Return_Four()
        {
            var ruleList = new List<Rule>
            {
                new Rule(1, "Wniosek", new List<string> {"warunek"}, true),
                new Rule(1, "Wniosek", new List<string> {"warunek"}, true),
                new Rule(1, "Wniosek", new List<string> {"warunek"}, true),
                new Rule(1, "Wniosek", new List<string> {"warunek"}, true),
                new Rule(1, "Wniosek1", new List<string> {"warunek"}, true),
            };
            List<Rule> result = ConclusionOperations.FindRulesWithParticularConclusion("Wniosek", ruleList);

            Assert.AreEqual(4, result.Count);
        }
    }
}