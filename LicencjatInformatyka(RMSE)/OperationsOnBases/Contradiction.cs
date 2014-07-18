using System.Collections.Generic;
using System.Linq;
using System.Windows;
using LicencjatInformatyka_RMSE_.NewFolder2;
using LicencjatInformatyka_RMSE_.NewFolder3;
using LicencjatInformatyka_RMSE_.NewFolder5;

namespace LicencjatInformatyka_RMSE_.OperationsOnBases
{
    public static class Contradiction
    {
        public static void CheckOutsideContradiction(GatheredBases bases)
        {
            foreach (Rule RuleI in bases.RuleBase.RulesList)
            {
                int i = 100;
                List<object> complexTree = TreeOperations.MethodForContradiction(bases, RuleI, i);

                if ((bool) complexTree[1] == false) // nie działa z podwojnymi regulami
                {
                    IEnumerable<SimpleTree> sprawdzamy =
                        TreeOperations.TreeToEnumerable((SimpleTree) complexTree[0]).Where(p => p.Children.Count == 0);


                    foreach (SimpleTree simpleTree in sprawdzamy) // dlaczego nie jest sprawdzana z wszystkimi regułami
                    {
                        SimpleTree node = simpleTree;
                        SimpleTree wartSprawdzana = simpleTree;

                        while (node.Parent != null)
                        {
                            node.rule = node.Parent.rule;
                            if (wartSprawdzana == node)
                            {
                                MessageBox.Show("Haha mamy sprzeczność bo wartosc " + node.rule.NumberOfRule +
                                                "występuje w warunku reguly " + wartSprawdzana.Parent.rule.NumberOfRule);
                            }
                        }
                    }
                }
            }
        }

        public static void CheckContradictionWIthModelsAndRulebase(GatheredBases bases)
        {
            foreach (var rule in bases.RuleBase.RulesList)
            {
                var r = TreeOperations.ReturnComplexTreeAndDifferences(bases, rule);
                var t = TreeOperations.TreeToEnumerable(r.Values.First()).Where(p =>p.Dopytywalny);
                foreach (var condition in t)
                {
                   
                    var models = bases.ModelsBase.ModelList.Where(p => p.Conclusion == condition.rule.Conclusion);
                    if (models.Count() != 0)
                    {
                        // trzeba zebrać wszystkie warunki startowe
                        // jeszcze zrobić mały research 

                        foreach (var model in models)
                        {
                            List<string> list= new List<string>();
                           var listOfStartedConditions = GatherStartConditions(model, bases,list);
                            CheckContradictionBetweenRulesAndStartedConditions(listOfStartedConditions, condition);
                        }


                    }

                    
                }
            }

            MessageBox.Show("Modele i reguly ok");
        }
        // metode mozna wykozystac do modeli relacyjnych jako warunki startowe
        private static bool CheckContradictionBetweenRulesAndStartedConditions
            (List<string> listOfStartedConditions, SimpleTree ruleForCheck)
        {
            int i = 0;
            while (ruleForCheck.Parent != null)
            {
                if(i!=0)
                   ruleForCheck = ruleForCheck.Parent;
                foreach (var StartedCondition in listOfStartedConditions)
                {
                    if (StartedCondition == ruleForCheck.rule.Conclusion)
                    {
                        MessageBox.Show("Konflikt pomiędzy modelami i regułami" +StartedCondition );
                        return false;
                    }
                }
                i++;
                
            }
            return true;
        }

        // metoda do przepracowania
        private static List<string> GatherStartConditions(Model model, GatheredBases bases, List<string> r )
        {
            if(model.StartCondition!="bez warunku")
                r.Add(model.StartCondition);

            if (model.ModelType == "simple")
            {
                var models = bases.ModelsBase.ModelList.Where(p => p.Conclusion == model.FirstArg);
                foreach (var model1 in models)
                {
                  r.AddRange( GatherStartConditions(model1, bases, r));  //
                }
                 models = bases.ModelsBase.ModelList.Where(p => p.Conclusion ==model.SecoundArg ); 
                 foreach (var model1 in models)
                {
                    r.AddRange(GatherStartConditions(model1, bases, r));  //
                }
                
            }
            if (model.ModelType == "extended")
            {
                foreach (var argument in model.ArgumentsList)
                {
                   var models = bases.ModelsBase.ModelList.Where(p => p.Conclusion == argument);
                    foreach (var model1 in models)
                    {
                        r.AddRange(GatherStartConditions(model1, bases, r));  //
                    }
                    
                }
                


            }
            return r;
        }

        public static void CheckContradictionInConstrains
           (GatheredBases bases, List<Constrain> constrainsList)
        {
            foreach (Constrain constrain in constrainsList)
            {
                foreach (Rule rule in bases.RuleBase.RulesList)
                {
                    Dictionary<List<List<Rule>>, SimpleTree> tree =
                        TreeOperations.ReturnComplexTreeAndDifferences(bases, rule);
                    List<List<SimpleTree>> flatteredRules = TreeOperations.ReturnPossibleTrees(tree.Values.First(),
                        tree.Keys.First());


                    foreach (var flatteredRule in flatteredRules)
                    {
                        int count = 0;
                        foreach (SimpleTree flatteredConditions in flatteredRule)
                        {
                            foreach (string constrainCondition in constrain.ConstrainsList)
                            {
                                if (flatteredConditions.Dopytywalny)
                                    if (constrainCondition == flatteredConditions.rule.Conclusion)
                                        count++;
                            }
                        }
                        if (count > 1) // If more than one there is a contradiction
                            MessageBox.Show("Contradiction z regula" + rule.Conclusion + "i ograniczeniem" +
                                            constrain.NumberOfLimit);
                    }
                }
            }
        }

    }
}