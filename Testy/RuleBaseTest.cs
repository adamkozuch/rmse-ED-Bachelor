using LicencjatInformatyka_RMSE_.NewFolder2;
using LicencjatInformatyka_RMSE_.NewFolder4;
using NUnit.Framework;

namespace Testy
{
   [TestFixture]
    public class RuleBaseTest
    {
        


     [Test]
    public void Check_If_Conclusion_Is_Added_Correctly()
     {
         var rule = Rule();

         Assert.AreEqual("otrzymuje wpis",rule.Conclusion);
     }

     [Test]
     public void Check_If_There_Is_Enough_Conditions()
     {
         var rule = Rule();     
         Assert.AreEqual(rule.Conditions.Count, 2);
     }



       private static Rule Rule()
       {
           string ruleFromDoc = "reguła(1,\"otrzymuje wpis\",[\"ocena z przedmiotów A,B,C  >=3 \",\"zapłacił czesne\"], 1) ";
           var NewRuleBase = new RuleBase();

           var rule = NewRuleBase.CreateRule(ruleFromDoc);
           return rule;
       }
    }
}
