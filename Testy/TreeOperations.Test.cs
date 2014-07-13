using System;
using System.Collections.Generic;
using System.Linq;
using LicencjatInformatyka_RMSE_.NewFolder2;
using LicencjatInformatyka_RMSE_.NewFolder4;
using LicencjatInformatyka_RMSE_.OperationsOnBases;
using NUnit;
using NUnit.Framework;

namespace Testy
{
    [TestFixture]
    public class TreeOperationsTest
    {

            RuleBase rules = new RuleBase();
        private void method()
        {
            
            Rule r = new Rule(1, "Dziadek", new List<string>() { "Ojciec" }, true);
            Rule r1 = new Rule(2, "Dziadek", new List<string>() { "Ciocia" }, true);
            Rule r2 = new Rule(3, "Ciocia", new List<string>() { "Corka" }, true);
            Rule r22 = new Rule(5, "Ciocia", new List<string>() { "Syn" }, true);
            Rule r3 = new Rule(4, "Syn", new List<string>() { "Julek" }, true);
            rules.RulesList.Add(r);
            rules.RulesList.Add(r1);
            rules.RulesList.Add(r2);
            rules.RulesList.Add(r3);
            rules.RulesList.Add(r22);

        }



        [Test]
        public void BuildComplexTree_Check_If_Return_Key_And_Value_With_Good_Count()
        {
            method();

        var tree =     TreeOperations.ReturnComplexTreeAndDifferences(rules.RulesList, rules.RulesList[1]);
            int treeCount =TreeOperations.TreeToEnumerable( tree.Values.First()).Count();
            int dvideListCount = tree.Keys.Count;

            Assert.AreEqual(6,treeCount);// sześć elementow , cztery reguly
            Assert.AreEqual(1,dvideListCount);





        }
    }
}
