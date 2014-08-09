using System;
using System.Collections.Generic;
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
        private ConstrainActions _constrainActions;

        public ActionsOnBase(GatheredBases bases, ViewModel model)
        {
            _viewModel = model;
            _bases = bases;
          conclusion  = new ConclusionClass(_bases, _viewModel);
          _constrainActions = new ConstrainActions(conclusion, _viewModel, _bases);
        }
       
        

       
        public void FlatterRule(Rule rule)
        {
           conclusion.FlatterRule(rule);
        }

       

       

        public void FillAskingConditionsTable()
        {
            
            conclusion.AskedConditions();
        }
       

       

        #region Redundancy

        public void CheckConstrainsRedundancy()
        {
            var delegateMethod = new RedundancyMethod(Redundancy.CheckRedundancyWithConstrain);
            Redundancy.GeneralCheckRedundancyMethod(_bases, delegateMethod);       
        }
        public void CheckRedundancyInRules()
        {
            RedundancyMethod delegateMethod = new RedundancyMethod(Redundancy.CheckRedundancyWithRules);
            Redundancy.GeneralCheckRedundancyMethod(_bases, delegateMethod);
        }
        #endregion


        #region contradiction
        public void CheckOutsideContradiction()
        {
            Contradiction.CheckOutsideContradiction(_bases, true);
        }

        public void ReportAboutOutsideContradiction()
        {
            Contradiction.ReportAboutContradictionInRules(_bases, _viewModel);
        }

        public void CheckContradictionWithConstrains()
        {
            Contradiction.CheckContradictionWithConstarinsMethod(_bases);
        }

        public void CheckContradictionBetweenModelsAndRulebase()
        {
            Contradiction.CheckContradictionWIthModelsAndRulebase(_bases);
        }
        #endregion

        public void BackwardConcludeAction(Rule rule)
        {
                conclusion.BackwardConclude(rule);
        }

        public void ForwardConcludeAction()
        {
            var forward = new ForwardChaining(_bases, conclusion, _viewModel,_constrainActions);
            forward.Forward();
        }
    }
}