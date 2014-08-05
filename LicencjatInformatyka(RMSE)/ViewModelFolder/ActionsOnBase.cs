using LicencjatInformatyka_RMSE_.Bases;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;
using LicencjatInformatyka_RMSE_.OperationsOnBases.ConcludeFolder;
using LicencjatInformatyka_RMSE_.OperationsOnBases.DiagnoseFolder;

namespace LicencjatInformatyka_RMSE_.ViewModelFolder
{
    public class ActionsOnBase
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
        public void CheckRedundancyInRules()
        {

Redundancy.Invoke(_bases);       
        }
        

        public void CheckOutsideContradiction()
        {

            Contradiction.CheckOutsideContradiction(_bases,true);
        }

        public void FlatterRule(Rule rule)
        {
           conclusion.FlatterRule(rule);
        }

        public void ReportAboutOutsideContradiction()
        {
            Contradiction.ReportAboutContradictionInRules(_bases,_viewModel);
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