using System.Collections.Generic;
using System.Linq;
using System.Windows;
using LicencjatInformatyka_RMSE_.Bases;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;
using LicencjatInformatyka_RMSE_.ViewControls.AskWindows;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.OperationsOnBases.ConcludeFolder
{
    public class ConclusionClass
    {
      
        private readonly GatheredBases _bases;
        private readonly ViewModel _viewModel;
        private readonly ConstrainActions _constrainActions;
        private readonly ModelActions _modelActions;

        public ConclusionClass(GatheredBases bases, ViewModel viewModel)
        {
            _bases = bases;
            _viewModel = viewModel;
            _constrainActions = new ConstrainActions(this, _viewModel, bases);
            _modelActions = new ModelActions(this,_viewModel,bases);
        }

         public   void AskedConditions()
       {
           var askingConditionList= new List<string>();
            foreach (var rule in _bases.RuleBase.RulesList)
            {
                foreach (var condition in rule.Conditions)
                {
                    if (_bases.RuleBase.RulesList.Any(p => p.Conclusion == condition))
                    {
                       
                    }
                    else
                    {
                        if (CheckIfStringIsFact(condition, _bases.FactBase.FactList) == false)
                            //if()
                        {
                            foreach (var element in askingConditionList)
                            {
                                if (condition == element)
                                    goto label;
                            }
                            askingConditionList.Add(condition);
                        label:;
                        }
                    }
                }
                
            }
_viewModel.AskingConditionsList = askingConditionList;
        }

        public void FlatterRule(Rule flatteredRule)
        {
            var differenceList= new List<List<Rule>>();
            var tree = TreeOperations.ReturnComplexTreeAndDifferences(_bases, flatteredRule,out differenceList);
            var possibleTrees = TreeOperations.ReturnPossibleTrees(tree, differenceList);

            foreach (var possibleTree in possibleTrees)
            {
                var flatter = possibleTree.Where(p => p.Dopytywalny == true);
                foreach (var simpleTree in flatter)
                {
                    _viewModel.MainWindowText += simpleTree.rule.Conclusion+" ";
                }
                 flatter = possibleTree.Where(p => p.Dopytywalny == false);
                 _viewModel.MainWindowText += "\n"; //TODO: Wszystkie warunki dopytywalne coœ nie tak
                foreach (var simpleTree in flatter)
                {
                    _viewModel.MainWindowText +=  simpleTree.rule.NumberOfRule +" ";
                }
                _viewModel.MainWindowText +="\n";

            }


        }





        public bool BackwardConclude( Rule checkedRule)
        {
            var differenceList = new List<List<Rule>>();
            var tree = TreeOperations.ReturnComplexTreeAndDifferences(_bases, checkedRule,out differenceList);

            var possibleTrees = TreeOperations.ReturnPossibleTrees(tree, differenceList);


            foreach (var onePossibility in possibleTrees) //flattering all possible configurations of conditions
            {
                List<SimpleTree> askableTable = onePossibility.Where(var => var.Dopytywalny).ToList();

                // sprawdzamy czy jest w bazie faktow
                foreach (SimpleTree simpleTree in askableTable)
                {
                    if (CheckIfStringIsFact(simpleTree.rule.Conclusion, _bases.FactBase.FactList))
                        simpleTree.rule.ConclusionValue = true;
                }

                bool conclusionValue = CheckConclusionValueOrCountModel(askableTable); // Check if all asking are true

                if (conclusionValue)
                {
                    MessageBox.Show("Hipoteza prawdziwa");
                    return true;
                }
            }
            return false;
        }

        private bool CheckConclusionValueOrCountModel(List<SimpleTree> askingTable)
        {
            int i = 0;
            foreach (SimpleTree simpleTree in askingTable)
            {
                _constrainActions.ConstrainAsk(simpleTree);
                if (simpleTree.rule.Model)
                {
                    _modelActions.ProcessModel(simpleTree.rule.Conclusion);
                }

                if (simpleTree.rule.ConclusionValue)
                    i++;
                else
                {
                    _viewModel.CheckedRuleName = simpleTree.rule.Conclusion;
                   AskRuleValue window = new AskRuleValue(_viewModel);
                   
                    window.ShowDialog();  // TODO:Mo¿e wystapiæ bug zwi¹zany z zamknieciem okna x w lewym górnym rogu
                    
                    simpleTree.rule.ConclusionValue = _viewModel.CheckedRuleVal;

                    if (_viewModel.CheckedRuleVal)
                        i++;          
                }
            }

            if (i == askingTable.Count)
                return true; // hipoteza jest prawdziwa
            return false; //else trzeba sprawdzac dalej
        }

     

        public static
            List<string> FindConditionsOrReturnNull
            (string checkedCondition, List<Rule> baseList)
        {
            var lista = new List<string>();

            foreach (Rule rule in baseList)
            {
                if (rule.Conclusion == checkedCondition) // Checking if rule in rulebase is condition 
                {
                    lista.AddRange(rule.Conditions); //LINQ
                    // zwraca dowoln¹ liczbê zestawów warunkow( jakby by³y np. dwie reguly o tej samej nazwie)
                }
            }
            if (lista.Count == 0) // If not find conditions for rule return checked condition 
                return null; //    lista.Add(checkedCondition);

            return lista;
        }


        public static List<Rule> FindRulesWithParticularConclusion
            (string NameOfCondition, List<Rule> baseList)
        {
            var rulesThatMatch = new List<Rule>();

            foreach (Rule rule in baseList)
            {
                if (rule.Conclusion == NameOfCondition)
                {
                    rulesThatMatch.Add(rule);
                }
            }
            //If return empty list condition for ask (dopytywalny)
            return rulesThatMatch;
        }


 

        public static bool CheckIfStringIsFact(string nameOfConclusion, List<Fact> listOfFacts)
        {
            foreach (Fact factItem in listOfFacts)
            {
                if (factItem.FactName == nameOfConclusion)
                {
                    return true;
                }
            }
            return false;
        }
    }
    
    }
