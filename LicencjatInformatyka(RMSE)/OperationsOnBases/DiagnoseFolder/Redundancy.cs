

using System.Collections.Generic;
using System.Linq;
using LicencjatInformatyka_RMSE_.Bases;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;
using LicencjatInformatyka_RMSE_.OperationsOnBases.ConcludeFolder;
using MessageBox = System.Windows.MessageBox;

namespace LicencjatInformatyka_RMSE_.OperationsOnBases.DiagnoseFolder
{
    public delegate int RedundancyMethod(List<List<SimpleTree>> possibleTree, GatheredBases bases);

    internal class Redundancy
    {
        #region redundancyWithRules

        public static void GeneralCheckRedundancyMethod(GatheredBases bases, RedundancyMethod typeOfRedundancy)
        {
            var alreadyChecked = new List<string>();
            bool withRules = false;
            bool withConstrains = false;
            bool typeRules = false;


            // program checks all rule with same conclusion. That table exist to avoid double checking
            foreach (Rule ruleForCheck in bases.RuleBase.RulesList)
            {
                if (alreadyChecked.Contains(ruleForCheck.Conclusion) == false)
                {
                    var allFlatteredRules = AllFlatteredRules(bases, ruleForCheck);
                    var i = typeOfRedundancy(allFlatteredRules, bases);
                        // delegate CheckRedundancyWithRules or another method
                    alreadyChecked.Add(ruleForCheck.Conclusion);

                    if (1 == i || 2 == i)
                        typeRules = true;

                    if (i == 2)
                    {
                        withRules = true;
                    }

                    if (i == 32)
                    {
                        withConstrains = true;
                    }
                }
            }
            if (typeRules)
                if (withRules == false)
                    MessageBox.Show("Nie wykryto nadmiarowości w bazie reguł");
            if (typeRules == false)
                if (withConstrains == false)
                    MessageBox.Show("Nie wykryto nadmiarowości lącznych w bazie reguł i ograniczeń");
        }

        public static int CheckRedundancyWithRules
            (List<List<SimpleTree>> possibleTrees, GatheredBases bases)
        {
            int i = 0;
            foreach (var firstSimpleTree in possibleTrees)
            {
                foreach (var secoundSimpleTree in possibleTrees)
                {
                    if (firstSimpleTree != secoundSimpleTree)
                    {
                        var firstList = firstSimpleTree.Where(p => p.Askable).ToList();
                        var secoundList = secoundSimpleTree.Where(p => p.Askable).ToList();

                        bool value = CompareRules(firstList, secoundList);

                        CompareRulesForConstrainRedundancy(firstList, secoundList, bases);
                        if (value == false)
                        {
                            i++;
                            ReportRedundancyInRules(firstSimpleTree, secoundSimpleTree);
                            goto lab;
                        }
                    }
                }
            }
            lab:
            
            if (i == 0)
                return 1;
            return 2;
        }

        public static int CheckRedundancyWithConstrain(List<List<SimpleTree>> possibleTrees,
            GatheredBases bases)
        {
            int i = 0;
            List<List<SimpleTree>[]> checkedList = new List<List<SimpleTree>[]>();
            foreach (var first in possibleTrees)
            {
                foreach (var secound in possibleTrees)
                {
                    List<SimpleTree>[] list = new List<SimpleTree>[2] {first, secound};
                    var groupedList = list.GroupBy(p => p.First().rule.Conclusion).ToList();
                    foreach (IGrouping<string, List<SimpleTree>> grouping in groupedList)
                    {
                    }


                    list = new List<SimpleTree>[2];

                    {
                        

                        if (first != secound)
                        {
                            List<SimpleTree> firstList = first.Where(p => p.Askable).ToList();
                            List<SimpleTree> secoundList = secound.Where(p => p.Askable).ToList();


                            var value = CompareRulesForConstrainRedundancy(firstList, secoundList, bases);
                            if (value.ConstrainConditions.Count != 0)
                            {
                                ReportRedundancyInConstrains(first, secound, value);
                                i++;
                                goto lab;
                            }
                        }
                    }
                }
            }
            lab:
            ;
            if (i == 0)
                return 21;
            return 32;
        }

        private static void ReportRedundancyInRules(List<SimpleTree> firstSimpleTree, List<SimpleTree> secoundSimpleTree)
        {
            var firstRuleDescription = ConclusionClass.GetFlatteredRuleDescription(firstSimpleTree);
            var secoundRuleDescription = ConclusionClass.GetFlatteredRuleDescription(secoundSimpleTree);

            MessageBox.Show("Mamy nadmiarowość " + firstRuleDescription + secoundRuleDescription);
        }

        #endregion

        public static List<List<SimpleTree>> AllFlatteredRules(GatheredBases bases, Rule ruleForCheck)
        {
            List<List<SimpleTree>> allFlatteredRules = new List<List<SimpleTree>>();
            List<Rule> ruleList = ConclusionClass.FindRulesWithParticularConclusion
                (ruleForCheck.Conclusion, bases.RuleBase.RulesList);

            foreach (var r in ruleList)
            {
                List<List<Rule>> differencesList;
                var tree = TreeOperations.ReturnComplexTreeAndDifferences(
                    bases, r, out differencesList);
                List<List<SimpleTree>> possibleTrees = TreeOperations.ReturnPossibleTrees(tree,
                    differencesList);
                allFlatteredRules.AddRange(possibleTrees);
            }
            return allFlatteredRules;
        }

        #region redundancyWithConstrains

        private static void ReportRedundancyInConstrains
            (List<SimpleTree> firstSimpleTree, List<SimpleTree> secoundSimpleTree, Constrain value)
        {
            var firstRuleDescription = ConclusionClass.GetFlatteredRuleDescription(firstSimpleTree);
            var secoundRuleDescription = ConclusionClass.GetFlatteredRuleDescription(secoundSimpleTree);

            MessageBox.Show("Mamy nadmiarowość z ograniczeniem \n" + firstRuleDescription + secoundRuleDescription +
                            "z ograniczeniem numer" + value.NumberOfConstrain);
        }

        private static Constrain CompareRulesForConstrainRedundancy
            (List<SimpleTree> firstList, List<SimpleTree> secoundList, GatheredBases bases)
        {
            //Function check if firstList is a part of secoundList

            int count = 0;
            var returnedConstrain = new Constrain();


            if (firstList.Count == secoundList.Count)
            {
                var newFirstList = firstList.OrderBy(p => p.rule.Conclusion);
                var newSecoundList = secoundList.OrderBy(tree => tree.rule.Conclusion);

                var secoundListAdd = newSecoundList.ToList();
                var firstListAdd = newFirstList.ToList();

                var firstElement = new SimpleTree();
                var secoundElement = new SimpleTree();

                for (int i = 0; i < firstList.Count; i++)
                {
                    if (secoundListAdd[i].rule.Conclusion != firstListAdd[i].rule.Conclusion)
                    {
                        firstElement = firstListAdd[i];
                        secoundElement = secoundListAdd[i];
                        count++;
                    }
                }


                if (count == 1)
                {
                    foreach (var constrain in bases.ConstrainBase.ConstrainList)
                    {
                        int licz = 0;
                        foreach (var condition in constrain.ConstrainConditions)
                        {
                            if (firstElement.rule.Conclusion == condition)
                                licz++;
                            if (secoundElement.rule.Conclusion == condition)
                                licz++;
                        }
                        if (licz == 2)
                        {
                            returnedConstrain = constrain;
                        }
                    }
                    return returnedConstrain;
                }
            }

            return returnedConstrain;
        }

        #endregion

        private static bool CompareRules(List<SimpleTree> firstList, List<SimpleTree> secoundList)
        {
            //Sprawdzamy czy firstList zawiera się w secoundList
            int count = 0;
            if (firstList.Count <= secoundList.Count)
            {
                var newFirstList = firstList.OrderBy(p => p.rule.Conclusion);
                var newSecoundList = secoundList.OrderBy(tree => tree.rule.Conclusion);

                var secoundListAdd = newSecoundList.ToList();
                var firstListAdd = newFirstList.ToList();

                for (int i = 0; i < firstList.Count; i++)
                {
                    if (secoundListAdd[i].rule.Conclusion == firstListAdd[i].rule.Conclusion)
                        count++;
                }
                if (count > 0)
                    if (count == firstList.Count) //wszystkie elementy z listy jeden muszą sie zawierać w liście2
                    {
                        return false;
                    }
            }
            return true;
        }
    }
}