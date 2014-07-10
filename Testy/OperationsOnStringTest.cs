using System.Linq;
using LicencjatInformatyka_RMSE_.NewFolder3;
using NUnit.Framework;

namespace Testy
{
    [TestFixture]
    public class OperationsOnStringTest
    {
          [Test]
        public void Check_If_RemoveBeggining_Return_Good_Value_With_Right_Parameter()
        {
            string ruleFromDoc = "reguła(1,\"otrzymuje wpis\",[\"ocena z przedmiotów A,B,C  >=3 \",\"zapłacił czesne\"], 1)";
            string expectedValue="1,\"otrzymuje wpis\",[\"ocena z przedmiotów A,B,C  >=3 \",\"zapłacił czesne\"], 1)";
              var removeBegginingString = OperationsOnString.RemoveBeggining(ruleFromDoc);

              Assert.AreEqual(expectedValue,removeBegginingString);
        }
  
        [Test]
        public void Check_If_SplitRule_Generate_Table_Of_Two_Strings()
        {
            string ruleFromDoc = "1,\"otrzymuje wpis\",[\"ocena z przedmiotów A,B,C  >=3 \",\"zapłacił czesne\"], 1)";
            var splitedString = OperationsOnString.SplitRuleToTwoPartsConditionsAndAnother(ruleFromDoc);
            Assert.AreEqual(splitedString[0].Count(),2);
    

        }


  
           
    }
}
