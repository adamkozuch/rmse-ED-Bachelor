using System.Collections.Generic;
using System.Linq;
using System.Windows;
using LicencjatInformatyka_RMSE_.Bases;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;
using LicencjatInformatyka_RMSE_.ViewControls.AskWindows;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.OperationsOnBases.ConcludeFolder
{
    /// <summary>
    /// Class ConclusionClass.
    /// </summary>
    public class ConclusionClass
    {

        /// <summary>
        /// The _bases
        /// </summary>
        private readonly GatheredBases _bases;
        /// <summary>
        /// The _view model
        /// </summary>
        private readonly ViewModel _viewModel;
        /// <summary>
        /// The _constrain actions
        /// </summary>
        private readonly ConstrainActions _constrainActions;
        /// <summary>
        /// The _model actions
        /// </summary>
        private readonly ModelActions _modelActions;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConclusionClass"/> class.
        /// </summary>
        /// <param name="bases">The bases.</param>
        /// <param name="viewModel">The view model.</param>
        public ConclusionClass(GatheredBases bases, ViewModel viewModel)
        {
            _bases = bases;
            _viewModel = viewModel;
            _constrainActions = new ConstrainActions(this, _viewModel, bases);
            _modelActions = new ModelActions(this,_viewModel,bases);
        }

        /// <summary>
        /// Askeds the conditions.
        /// </summary>
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

         /// <summary>
         /// Flatters the rule.
         /// </summary>
         /// <param name="flatteredRule">The flattered rule.</param>
        public void FlatterRule(Rule flatteredRule)
        {
            var differenceList= new List<List<Rule>>();
            var tree = TreeOperations.ReturnComplexTreeAndDifferences(_bases, flatteredRule,out differenceList);
            var possibleTrees = TreeOperations.ReturnPossibleTrees(tree, differenceList);

            foreach (var possibleTree in possibleTrees)
            {
                var flatter = possibleTree.Where(p => p.Askable == true);
                foreach (var simpleTree in flatter)
                {
                    _viewModel.MainWindowText1 += simpleTree.rule.Conclusion+" ";
                }
                 flatter = possibleTree.Where(p => p.Askable == false);
                 _viewModel.MainWindowText1 += "\n"; //TODO: Wszystkie warunki dopytywalne coœ nie tak
                foreach (var simpleTree in flatter)
                {
                    _viewModel.MainWindowText1 +=  simpleTree.rule.NumberOfRule +" ";
                }
                _viewModel.MainWindowText1 +="\n";

            }


        }





        /// <summary>
        /// Backwards the conclude.
        /// </summary>
        /// <param name="checkedRule">The checked rule.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool BackwardConclude( Rule checkedRule)
        {
            var differenceList = new List<List<Rule>>();
            var tree = TreeOperations.ReturnComplexTreeAndDifferences(_bases, checkedRule,out differenceList);

            var possibleTrees = TreeOperations.ReturnPossibleTrees(tree, differenceList);


            foreach (var onePossibility in possibleTrees) //flattering all possible configurations of conditions
            {
                List<SimpleTree> askableTable = onePossibility.Where(var => var.Askable).ToList(); //If askable simple tree can be a model,condition of rule or condition of constrain

                // sprawdzamy czy jest w bazie faktow
                foreach (SimpleTree simpleTree in askableTable)
                {
                    if (CheckIfStringIsFact(simpleTree.rule.Conclusion, _bases.FactBase.FactList))
                        simpleTree.ConclusionValue = true;
                }

                bool conclusionValue = CheckConclusionValueOrCountModel(askableTable); // Check if all asking are true

                if (conclusionValue)
                {

                    MessageBox.Show("Hipoteza prawdziwa");

                    //TODO : trzeba wyzerowaæ bazy
                    return true;
                }
            }
            MessageBox.Show("Hipoteza niepotwierdzona brak informacji");
            return false;
            //TODO : trzeba wyzerowaæ bazy
        }

        /// <summary>
        /// Checks the conclusion value or count model.
        /// </summary>
        /// <param name="askingTable">The asking table.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool CheckConclusionValueOrCountModel(List<SimpleTree> askingTable)
        {
            int i = 0;
            foreach (SimpleTree simpleTree in askingTable)
            {
              
                _constrainActions.ConstrainAsk(simpleTree);
                if (simpleTree.Model)
                {
                    var checker=   CheckIfStringIsFact(simpleTree.rule.Conclusion, _bases.FactBase.FactList);

                    if (checker==false) 
                    {
                        var value  = _modelActions.ProcessModel(simpleTree.rule.Conclusion);

                        if (value == null)
                        {
                            MessageBox.Show("Brak danych do ukonkretnienia modelu " + simpleTree.rule.Conclusion);
                            _bases.FactBase.FactList.Add(new Fact()
                            {
                                FactName = simpleTree.rule.Conclusion,
                                FactValue = false
                            });

                        }
                        else
                        {
                            _bases.FactBase.FactList.Add(new Fact()
                            {
                                FactName = simpleTree.rule.Conclusion,
                                FactValue = (bool)value
                            });
                            if ((bool) value)
                            {
                                i++;
                                IfParentTrueWrite(simpleTree);
                            }
                            else
                            {
                                break;
                            }
                            //TODO: trzeba sprawdziæ czy warunek jest faktem
                            simpleTree.ConclusionValue = (bool)value;
                            
                        }
                    }
                }
                else
                if (simpleTree.ConclusionValue)
                    i++;
                else
                {
                    _viewModel.AskingRuleValueMethod(simpleTree);

                    if (_viewModel.CheckedRuleVal)
                    {
                        i++;
                        IfParentTrueWrite(simpleTree);
                            //todo: i tutaj trzeba sprawdziæ czy jakaœ regu³a siê nie odblokowa³a
                    }
                }
            }

            if (i == askingTable.Count)
                return true; // hipoteza jest prawdziwa
            return false; //else trzeba sprawdzac dalej
        }

        private void IfParentTrueWrite(SimpleTree simpleTree)
        {
            if (simpleTree.Askable)
            {
                _viewModel.MainWindowText1 += simpleTree.rule.Conclusion + " Fakt \n";

            }
            int i = 0;
            if (simpleTree.Parent != null)
            {
                foreach (var simple in simpleTree.Parent.Children)
                {
                    if (simple.ConclusionValue)
                        i++;
                }

                if (i == simpleTree.Parent.Children.Count)
                {
                    _viewModel.MainWindowText2 += simpleTree.Parent.rule.Conclusion + " Wynik \n";
                    IfParentTrueWrite(simpleTree.Parent);
                }
            }

            
        }


        /// <summary>
        /// Finds the conditions or return null.
        /// </summary>
        /// <param name="checkedCondition">The checked condition.</param>
        /// <param name="baseList">The base list.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
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


        /// <summary>
        /// Finds the rules with particular conclusion.
        /// </summary>
        /// <param name="NameOfCondition">The name of condition.</param>
        /// <param name="baseList">The base list.</param>
        /// <returns>List&lt;Rule&gt;.</returns>
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




        /// <summary>
        /// Checks if string is fact.
        /// </summary>
        /// <param name="nameOfConclusion">The name of conclusion.</param>
        /// <param name="listOfFacts">The list of facts.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
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
