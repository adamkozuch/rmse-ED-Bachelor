using LicencjatInformatyka_RMSE_.Bases;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;
using LicencjatInformatyka_RMSE_.OperationsOnBases;

namespace LicencjatInformatyka_RMSE_.ViewModel
{
    internal class ActionsOnBase
    {
        private ViewModel _viewModel;
        private GatheredBases _bases;
        private ConclusionClass conclusion;

        public ActionsOnBase(GatheredBases bases, ViewModel model)
        {
            _viewModel = model;
            _bases = bases;
          conclusion  = new ConclusionClass(_bases, _viewModel);
        }

        public void CheckOutsideContradiction()
        {
            Contradiction.ReportAboutContradictionInRules(_bases);
        }
        public void CheckContradictionBetweenModelsAndRulebase()
        {
            Contradiction.CheckContradictionWIthModelsAndRulebase(_bases);
        }

        public void FillAskingConditionsTable()
        {
            
            conclusion.AskedConditions();
        }
       

        public void CheckContradictionWithConstrains()
        {
            Contradiction.CheckContradictionInConstrains(_bases, _bases.ConstrainBase.ConstrainList);
        }

        public void BackwardConcludeAction(Rule rule)
        {
            
                

                conclusion.BackwardConclude(rule);

            }
        
    }
}