using System;
using System.Collections.Generic;
using System.IO;
using LicencjatInformatyka_RMSE_.Additional;
using LicencjatInformatyka_RMSE_.NewFolder1;
using LicencjatInformatyka_RMSE_.NewFolder2;
using LicencjatInformatyka_RMSE_.OperationsOnBases;
using NUnit.Framework;

namespace Testy
{
    [TestFixture]
    public class UnitTest1
    {
        public UnitTest1(ViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        GatheredBases bases = new GatheredBases();
        private ViewModel _viewModel;

        private void FillBase(GatheredBases _bases)
        {
           
            //var a =new Rule();
            //var b = new Rule();
            //var c =new Rule();
            //var d =new Rule();
            //a.Conclusion = "a";
            //b.Conclusion = "b";
            //c.Conclusion = "c";
            //d.Conclusion = "d";
            //a.Conditions= new List<string>(){"b"};
            //a.Conditions = new List<string>() { "c" };
            //c.Conditions = new List<string>() { "d" };
            //bases.RuleBase.RulesList.Add(a);
            //bases.RuleBase.RulesList.Add(b);
            //bases.RuleBase.RulesList.Add(c);
            //bases.RuleBase.RulesList.Add(d);


            bases.RuleBase.ReadRules("REstudent.BED");
            
            //Constrain cons = new Constrain(new List<string>(){"d","e"},1 );
            //bases.ConstrainBase.ConstrainList.Add(cons);
        }


        [Test]
        public void TestMethod1()
        {
            bases.RuleBase.ReadRules("REstudent.BED");

            ConclusionClass conclusionClass= new ConclusionClass(bases, _viewModel);
            conclusionClass.BackwardConclude(bases.RuleBase.RulesList[3]);


        }
    }
}
