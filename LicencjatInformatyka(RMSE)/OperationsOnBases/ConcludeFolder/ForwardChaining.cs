using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using LicencjatInformatyka_RMSE_.Bases;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.OperationsOnBases.ConcludeFolder
{
    public class ForwardChaining
    {
        private readonly GatheredBases _bases;
        private readonly ConclusionClass _conclusion;
        private readonly ViewModel _viewModel;
        private readonly ConstrainActions _constrainActions;

        public ForwardChaining(GatheredBases bases, ConclusionClass conclusion, ViewModel viewModel,
            ConstrainActions constrainActions)
        {
            _bases = bases;
            _conclusion = conclusion;
            _viewModel = viewModel;
            _constrainActions = constrainActions;
        }


        private static bool allConcrete = false;

        public void Forward()
        {
            foreach (var constrain in  _bases.ConstrainBase.ConstrainList)
            {
                _constrainActions.AskForConstrainValue(constrain);
            }


            while (allConcrete == false)
            {
                ReportConclusionResult();

                foreach (var rule in _bases.RuleBase.RulesList)
                {
                    bool isFact = ConclusionClass.CheckIfStringIsFact(rule.Conclusion, _bases.FactBase.FactList);

                    if (isFact == false)
                    {
                        int i = 0;
                        foreach (var condition in rule.Conditions)
                        {
                            i = CheckCondition(condition, i);

                            
                        }
                         if (i == rule.Conditions.Count)
                            {
                                InputResult(rule);
                                break;
                            }


                        
                    }
                }
                if (_conclusion.AskedConditions() == _bases.FactBase.FactList.Count)
                    allConcrete = true;
            }
        }






        private void InputResult(Rule rule)
        {
            var tableOfFacts = new List<Fact>();
            foreach (var con in rule.Conditions)
            {
                tableOfFacts.AddRange(_bases.FactBase.FactList.Where(p => p.FactName == con));
            }
            if (tableOfFacts.Where(p => p.FactValue == true).Count() == rule.Conditions.Count)
            {
                _bases.FactBase.FactList.Add(new Fact()
                {
                    FactName = rule.Conclusion,
                    FactValue = true
                });
                //todo: tutaj można wypisać że okazało się że ta reguła jest prawdą
            }
            else
            {
                _bases.FactBase.FactList.Add(new Fact()
                {
                    FactName = rule.Conclusion,
                    FactValue = false
                });
            }
        }

        private int CheckCondition(string condition, int i)
        {
            var conc = ConclusionClass.CheckIfStringIsFact(condition, _bases.FactBase.FactList);
            //TODO:trzeba sprawdzic metodę która sprawdza czy string jest faktem
            if (conc)
                i++;
            else
            {
                var value = ConclusionClass.FindConditionsOrReturnNull
                    (condition, _bases.RuleBase.RulesList);

                if (value == null)
                    if (IsModel(condition) == false)
                    {
                        _viewModel.AskingForwardRuleValueMethod(condition);
                        i++;
                    }
                    else
                    {
                        //todo:jeszcze trzeba będzie przelecieć przez 
                    }
            }
            return i;
        }

        private void ReportConclusionResult()
        {
            string s = "Z wnioskowania w przód wynikają następujące fakty \n";
            foreach (var fact in _bases.FactBase.FactList)
            {
                if (fact.FactValue)
                    s += fact.FactName + "\n";
            }

            foreach (var fact in _bases.FactBase.FactList)
            {
                if (fact.FactValue==false)
                    s +="Nieprawdą jest :"+ fact.FactName + "\n";
            }
            _viewModel.MainWindowText1 = s;
        }


        private bool IsModel(string passedName)
        {
            foreach (var model in _bases.ModelsBase.ModelList)
            {
                if (passedName == model.Conclusion)
                    return true;
            }
            return false;
        }
    }
}