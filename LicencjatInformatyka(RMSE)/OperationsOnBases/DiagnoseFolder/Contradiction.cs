using System.Collections.Generic;
using System.Linq;
using System.Windows;
using LicencjatInformatyka_RMSE_.Bases;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.OperationsOnBases.DiagnoseFolder
{
    /// <summary>
    ///     Class Contradiction.
    /// </summary>
    public static class Contradiction
    {
        public static bool MethodForContradiction
            (GatheredBases bases, Rule ruleForCheck, int count, List<List<Rule>> differenceList,out SimpleTree tree)
        {
            
            tree = new SimpleTree { rule = ruleForCheck };
            IEnumerable<SimpleTree> parentWithoutChildren;

            int i = 0;
            do
            {
                parentWithoutChildren = TreeOperations.TreeToEnumerable(tree).Where(p => p.Children.Count == 0).
                    Where(p => p.Dopytywalny == false);

                foreach (SimpleTree parentWithoutChild in parentWithoutChildren)
                {
                    TreeOperations.ExpandBrunchOrMakeAskable(bases, parentWithoutChild, differenceList);
                    i++;

                    if (i == count)
                    {          
                        return false;  // method not finished tree after i iterations
                    }  //TODO: ta pętla nie jest odporna na sprzeczność
                }
            } while (parentWithoutChildren.Count() != 0);

            return true; // method finished tree and there is no contradiction
        }

        #region OutsideContradiction
        /// <summary>
        ///     Checks the outside contradiction.
        ///     Ta metoda będzie slużyła jedynie do stwierdzenia że sprzeczność występuje
        ///     natomiast żeby diagnozowac kolejne reguły trzeba bedzie wymyślić coś innego
        /// </summary>
        /// <param name="bases">The bases.</param>
        public static List<Rule> CheckOutsideContradiction(GatheredBases bases, bool reportIncluded)
        {
            var contradictedRules = new List<Rule>();
            foreach (Rule RuleI in bases.RuleBase.RulesList)
            {
                
                var differenceList = new List<List<Rule>>();
                int numberForCheck = 100;
                do
                {
                    var tree = new SimpleTree();
                    var complexTreeValue = MethodForContradiction(bases, RuleI, numberForCheck, differenceList,out tree);

                    if (complexTreeValue == false)
                    {
                        IEnumerable<SimpleTree> currentEndOfTree =
                            TreeOperations.TreeToEnumerable(tree).Where(p => p.Children.Count == 0);

                        foreach (SimpleTree currentEnd in currentEndOfTree)
                        {
                            //TODO: metoda nie sprawdza wszystkich regul albo i sprawdza
                            SimpleTree node = currentEnd;
                            SimpleTree checkedValue = currentEnd;

                            while (node.Parent != null)
                            {

                                node.rule = node.Parent.rule;
                                if (checkedValue == node)
                                {
                                    if (reportIncluded)
                                    {
                                        MessageBox.Show(
                                            "W bazie występuje sprzeczność przejdź do dniagnoz bazy aby poznać szczegóły");
                                        
                                        reportIncluded = false; //TODO:tymczasowe rozwiązanie trzeba jakoś przerwać metodę
                                    }
                                    AddRuleToContradictionTable(contradictedRules, RuleI);
                                    break;
                                }
                            }
                        }

                        numberForCheck = numberForCheck*2;
                        // in case that there is no contradiction but 
                        // also tree is not finished number is double

                    }
                    else
                    {
                        break;
                    }
                } while (contradictedRules.Count == 0);

            }
            return contradictedRules;
        }


        public static void AddRuleToContradictionTable
            (List<Rule> table, Rule rule)
        {
            int i = table.Count(VARIABLE => VARIABLE != rule);

            if (table.Count == i)
                table.Add(rule);
        }


        public static void ReportAboutContradictionInRules(GatheredBases bases, ViewModel _viewModel)
        {
            List<Rule> listWithContradiction = CheckOutsideContradiction(bases,false);

            foreach (Rule rule in listWithContradiction)
            {
                CheckSelfContradiction(rule);

              
                for (int count = 1; count < 100; count++)  //TODO:nie powinno być stałej w pętli for
                {
                     var tree = new SimpleTree();
                     var differenceList = new List<List<Rule>>();
                     MethodForContradiction(bases, rule, count,differenceList,out tree);

                    IEnumerable<SimpleTree> ListOfTreesElements =
                        TreeOperations.TreeToEnumerable(tree).Where(p => p.Children.Count == 0);

                    foreach (SimpleTree treeElement in ListOfTreesElements)
                    {
                        string s = "";
                        SimpleTree copyOfTree = treeElement;
                        if (treeElement.rule.NumberOfRule == rule.NumberOfRule) 
                        {
                            bool boolValue = true;
                            while (copyOfTree.Parent.rule != rule) 
                            {
                                if (boolValue == false)
                                {
                                    copyOfTree = copyOfTree.Parent;
                                }
                                boolValue = false;

                                s += copyOfTree.rule.NumberOfRule + "==>";
                                
                            }
                          //TODO:Tutaj okienko raportujące
                            _viewModel.MainWindowText +="Poprzez podstawienie następujących reguł otrzymasz sprzeczność zewnetrzną :"+ s + "\n";
                            goto Res;
                        }
                    }
                }

                Res:;
            }
        }

        private static void CheckSelfContradiction(Rule rule)
        {
            foreach (string condition in rule.Conditions)
            {
                if (condition == rule.Conclusion)
                    MessageBox.Show("Reguła " + rule.NumberOfRule + " jest samosprzeczna");
                break;
            }
        }

        #endregion
        /// <summary>
        ///     Checks the contradiction w ith models and rulebase.
        /// </summary>
        /// <param name="bases">The bases.</param>
        /// 
        ///
        #region ModelContradiction
        public static void CheckContradictionWIthModelsAndRulebase(GatheredBases bases)
        {
            foreach (Rule rule in bases.RuleBase.RulesList)
            {
                var differenceList = new List<List<Rule>>();
                var tree = TreeOperations.ReturnComplexTreeAndDifferences(bases, rule,out differenceList);

             var askingConditions = TreeOperations.TreeToEnumerable
                    (tree).Where(p => p.Dopytywalny);//TODO:uta niekoniecznie prawidłowo zmieniona logika

                foreach (SimpleTree condition in askingConditions)
                {
                    IEnumerable<Model> models =
                        bases.ModelsBase.ModelList.Where(p => p.Conclusion == condition.rule.Conclusion);
                    if (models.Count() != 0)
                    {
                        // trzeba zebrać wszystkie warunki startowe
                        // jeszcze zrobić mały research 

                        foreach (Model model in models)
                        {
                            var list = new List<string>();
                            List<string> listOfStartedConditions = GatherStartConditions
                                (model, bases, list);
                            //TODO:Z tego co się orientuję nie ma tu sprawdzenia warunkow startowych
                            // z modelami relacyjnymi oraz modeli arytmetycznych z modelami arytmetycznymi 
                            CheckContradictionBetweenRulesAndStartedConditions
                                (listOfStartedConditions, condition);
                       //     CheckContradictionBetweenModelsAndStartedConditions();
                          // CheckContradictionBetweenArithmeticModels();
                        }
                    }
                }
            }

            MessageBox.Show("Modele i reguly ok");
        }

        // metode mozna wykozystac do modeli relacyjnych jako warunki startowe
        /// <summary>
        ///     Checks the contradiction between rules and started conditions.
        /// </summary>
        /// <param name="listOfStartedConditions">The list of started conditions.</param>
        /// <param name="ruleForCheck">The rule for check.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool CheckContradictionBetweenRulesAndStartedConditions
            (List<string> listOfStartedConditions, SimpleTree ruleForCheck)
        {
            int i = 0;
            while (ruleForCheck.Parent != null)
            {
                if (i != 0)
                    ruleForCheck = ruleForCheck.Parent;
                foreach (string startedCondition in listOfStartedConditions)
                {
                    if (startedCondition == ruleForCheck.rule.Conclusion)
                    {
                        MessageBox.Show("Konflikt pomiędzy modelami i regułami" + startedCondition);
                        return false;
                    }
                }
                i++;
            }
            return true;
        }

    
        /// <summary>
        ///     Gathers the start conditions.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="bases">The bases.</param>
        /// <param name="r">The r.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        private static List<string> GatherStartConditions(Model model, GatheredBases bases, List<string> r)
        {
            if (model.StartCondition != "bez warunku")
                r.Add(model.StartCondition);

            if (model.ModelType == "simple")
            {
                IEnumerable<Model> models = bases.ModelsBase.ModelList.Where(p => p.Conclusion == model.FirstArg);
                foreach (Model model1 in models)
                {
                    r.AddRange(GatherStartConditions(model1, bases, r)); //
                }
                models = bases.ModelsBase.ModelList.Where(p => p.Conclusion == model.SecoundArg);
                foreach (Model model1 in models)
                {
                    r.AddRange(GatherStartConditions(model1, bases, r)); //
                }
            }
            if (model.ModelType == "extended")
            {
                foreach (string argument in model.ArgumentsList)
                {
                    string argument1 = argument;

                    IEnumerable<Model> models = bases.ModelsBase.ModelList.Where(p => p.Conclusion == argument1);

                    foreach (Model model1 in models)
                    {
                        r.AddRange(GatherStartConditions(model1, bases, r)); //
                    }
                }
            }
            return r;
        }
        #endregion
        /// <summary>
        ///     Checks the contradiction in constrains.
        /// </summary>
        /// <param name="bases">The bases.</param>
        /// <param name="constrainsList">The constrains list.</param>

        #region ConstrainContradiction
        public static void CheckContradictionInConstrains
            (GatheredBases bases, List<Constrain> constrainsList)
        {
            foreach (var constrain in constrainsList)
            {
                foreach (var rule in bases.RuleBase.RulesList)
                {
                   var differenceTable = new List<List<Rule>>();

                   var tree = TreeOperations.ReturnComplexTreeAndDifferences(bases, rule,out differenceTable);

                    List<List<SimpleTree>> possibleTrees = TreeOperations.ReturnPossibleTrees(tree,differenceTable);


                    foreach (var flatteredRule in possibleTrees)
                    {
                        int count = (from flatteredConditions in flatteredRule
                            from constrainCondition in constrain.ConstrainConditions
                            where flatteredConditions.Dopytywalny
                            where constrainCondition == flatteredConditions.rule.Conclusion
                            select flatteredConditions).Count();

                        if (count > 1) // If more than one there is a contradiction
                            MessageBox.Show("Sprzeczność pomiędzy regułą " + rule.NumberOfRule + " i ograniczeniem" +
                                            constrain.NumberOfLimit);
                    }
                }
            }
        }
        #endregion
    }
}