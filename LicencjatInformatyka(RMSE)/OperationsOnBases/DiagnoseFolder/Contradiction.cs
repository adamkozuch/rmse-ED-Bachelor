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
        

        #region OutsideContradiction
     public static bool MethodForContradiction
            (GatheredBases bases, Rule ruleForCheck, int count, List<List<Rule>> differenceList,out SimpleTree tree)
        {
            
            tree = new SimpleTree { rule = ruleForCheck };
            IEnumerable<SimpleTree> parentWithoutChildren;

            int _number = 0;
            do
            {
                parentWithoutChildren = TreeOperations.TreeToEnumerable(tree).Where(p => p.Children.Count == 0).
                    Where(p => p.Askable == false);

                foreach (SimpleTree parentWithoutChild in parentWithoutChildren)
                {
                    TreeOperations.ExpandBrunchOrMakeAskable(bases, parentWithoutChild, differenceList);
                    _number++;

                    if (_number == count)
                    {          
                        return false;  // method not finished tree after _number iterations
                    }  //TODO: ta pętla nie jest odporna na sprzeczność
                }
            } while (parentWithoutChildren.Count() != 0);

            return true; // method finished tree and there is no contradiction
        }

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
                                        
                                        reportIncluded = false; //TODO : tymczasowe rozwiązanie trzeba jakoś przerwać metodę
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
            int i = table.Count(p => p != rule);

            if (table.Count == i)
                table.Add(rule);
        }


        public static void ReportAboutContradictionInRules(GatheredBases bases, ViewModel _viewModel)
        {
            List<Rule> listWithContradiction = CheckOutsideContradiction(bases,false);

            foreach (Rule rule in listWithContradiction)
            {
                CheckSelfContradiction(rule);

              
                for (int count = 1; count < 1000; count++)  //TODO:nie powinno być stałej w pętli for
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
                            _viewModel.MainWindowText1 +="Poprzez podstawienie następujących reguł otrzymasz sprzeczność zewnetrzną :"+ s + "\n";
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
      
        #region ModelContradiction
        public static void CheckContradictionWIthModelsAndRulebase(GatheredBases bases)
        {
            foreach (Rule rule in bases.RuleBase.RulesList)
            {
                List<List<Rule>> differenceList;
                var tree = TreeOperations.ReturnComplexTreeAndDifferences(bases, rule,out differenceList);

             var askingConditions = TreeOperations.TreeToEnumerable
                    (tree).Where(p => p.Askable);//TODO:uta niekoniecznie prawidłowo zmieniona logika

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
                                (listOfStartedConditions, condition,model);
                       //     CheckContradictionBetweenModelsAndStartedConditions();
                          // CheckContradictionBetweenArithmeticModels();
                        }
                    }
                }
            }

          
        }

       
        
        private static bool CheckContradictionBetweenRulesAndStartedConditions
            (List<string> listOfStartedConditions, SimpleTree ruleForCheck, Model model)
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
                        MessageBox.Show("Konflikt pomiędzy modelami i regułami Warunek startowy " + startedCondition + "w modelu "+ 
                            model.ModelNumber + " " + model.Conclusion + " a regułą" +ruleForCheck.rule.NumberOfRule+" "+ ruleForCheck.rule.Conclusion );
                        return false;
                    }
                }
                i++;
            }
            return true;
        }

    
    
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
   

        #region ConstrainContradiction
        public static void CheckContradictionWithConstrains
             (List<List<SimpleTree>> allFlatteredRules, GatheredBases bases)
        {
            // todo : tutaj też warto posortowac listy zeby uniknac błędu 

            foreach (var constrain in bases.ConstrainBase.ConstrainList)
            {
                foreach (var ruleFlattered in allFlatteredRules)
                {
                    List<SimpleTree> askable = ruleFlattered.Where(p => p.Askable).ToList();
                    int i = 0;
                    foreach (var simpleTree in askable)
                    {
                        foreach (var condition in constrain.ConstrainConditions)
                        //TODO:tutaj jest rozwiązanie na sprzeczność jeżeli w jednym spłaszczeniu są dwie reguły sprzeczna
                        {
                            if (simpleTree.rule.Conclusion == condition)
                                i++;
                        }
                    }
                    if (i > 1)
                    {
                        IEnumerable<SimpleTree> firstParent = ruleFlattered.Where(p => p.Parent == null);
                        MessageBox.Show("Jest sprzeczność z bazą ograniczeń pomiędzy regułą " +
                                        firstParent.First().rule.Conclusion + " a"
                                        + "ograniczeniem nr" + constrain.NumberOfConstrain);
                    }
                }
            }
        }

        public static void CheckContradictionWithConstarinsMethod(GatheredBases bases)
        {
            var alreadyChecked = new List<string>();
            foreach (Rule ruleForCheck in bases.RuleBase.RulesList)
            {
                if (alreadyChecked.Contains(ruleForCheck.Conclusion) == false)
                {
                    var allFlatteredRules = Redundancy.AllFlatteredRules(bases, ruleForCheck);
                    Contradiction.CheckContradictionWithConstrains(allFlatteredRules, bases);
                    alreadyChecked.Add(ruleForCheck.Conclusion);
                }
            }
        }

        #endregion
    }
}