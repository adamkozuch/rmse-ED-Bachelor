using System;
using LicencjatInformatyka_RMSE_.Bases;

namespace LicencjatInformatyka_RMSE_.OperationsOnBases.ConcludeFolder
{
    internal class ForwardChaining
    {

        public void Forward(GatheredBases bases)
        {


            foreach (var rule in bases.RuleBase.RulesList)
            {
                foreach (var condition in rule.Conditions)
                {
                    var value = ConclusionOperations.FindConditionsOrReturnNull
                        (condition, bases.RuleBase.RulesList);

                    if (value == null)
                        if (IsModel() == false)
                            if (ConclusionOperations.CheckIfStringIsFact(condition, bases.FactBase.FactList) == false) ;
                    // int i = 0;  //dopytaj
                }
                


            }

        }





        private bool IsModel()
        {
            throw new NotImplementedException();
        }
    }
}
