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
                                MessageBox.Show("Haha mamy sprzeczność bo wartosc " + node.rule.Conclusion +
                                                "występuje w warunku reguly " + wartSprawdzana.Parent.rule.Conclusion);
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
                var r = TreeOperations.ReturnComplexTreeAndDifferences(bases, rule).Where(p =>p.Value.Dopytywalny);
                foreach (var condition in r)
                {
                   
                    var models = bases.ModelsBase.ModelList.Where(p => p.Conclusion == condition.Value.rule.Conclusion);
                    if (models.Count() != 0)
                    {
                        // trzeba zebrać wszystkie warunki startowe
                        // jeszcze zrobić mały research 
                        foreach (var model in models)
                        {
                            // skomplikowane

                        }


                    }

                    
                }
            }


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