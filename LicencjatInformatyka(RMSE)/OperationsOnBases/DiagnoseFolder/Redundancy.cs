// ***********************************************************************
// Assembly         : LicencjatInformatyka(RMSE)
// Author           : Adamk
// Created          : 07-20-2014
//
// Last Modified By : Adamk
// Last Modified On : 07-20-2014
// ***********************************************************************
// <copyright file="Redundancy.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LicencjatInformatyka_RMSE_.Bases;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;
using LicencjatInformatyka_RMSE_.OperationsOnBases.ConcludeFolder;
using MessageBox = System.Windows.MessageBox;

namespace LicencjatInformatyka_RMSE_.OperationsOnBases.DiagnoseFolder
{
    public delegate void RedundancyMethod(List<List<SimpleTree>> possibleTree, GatheredBases bases);

    internal class Redundancy
    {
        #region redundancyWithRules

        public static void GeneralCheckRedundancyMethod(GatheredBases bases, RedundancyMethod typeOfRedundancy)
        {
            var alreadyChecked = new List<string>();
                // program checks all rule with same conclusion. That table exist to avoid double checking
            foreach (Rule ruleForCheck in bases.RuleBase.RulesList)
            {
                if (alreadyChecked.Contains(ruleForCheck.Conclusion) == false)
                {
                    var allFlatteredRules = AllFlatteredRules(bases, ruleForCheck);
                    typeOfRedundancy(allFlatteredRules, bases);
                    alreadyChecked.Add(ruleForCheck.Conclusion);
                }
            }
        }

        public static void CheckRedundancyWithRules(List<List<SimpleTree>> possibleTrees, GatheredBases bases)
        {
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
                            ReportRedundancyInRules(firstSimpleTree, secoundSimpleTree);
                            goto lab;
                        }
                    }
                }
            }
            lab:
            ;
        }

        public static void CheckRedundancyWithConstrain(List<List<SimpleTree>> possibleTrees,
            GatheredBases bases)
        {
            foreach (var first in possibleTrees)
            {
                foreach (var secound in possibleTrees)
                {
                    //todo : nie wiem jak zrobić żeby były pary tylko raz bez wzgledu na kolejność 
                    //todo : tutaj można szukać rozwiązania http://msdn.microsoft.com/en-us/magazine/cc163957.aspx
                    if (first != secound)
                    {
                        List<SimpleTree> firstList = first.Where(p => p.Askable).ToList();
                        List<SimpleTree> secoundList = secound.Where(p => p.Askable).ToList();


                        var value = CompareRulesForConstrainRedundancy(firstList, secoundList, bases);
                        if (value.ConstrainConditions.Count!=0)
                        {
                            ReportRedundancyInConstrains(first, secound,value);
                            
                            goto lab;
                        }
                    }
                }
            }
            lab:
            ;
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

        private static void ReportRedundancyInConstrains(List<SimpleTree> firstSimpleTree, List<SimpleTree> secoundSimpleTree, Constrain value)
        {
            var firstRuleDescription = ConclusionClass.GetFlatteredRuleDescription(firstSimpleTree);
            var secoundRuleDescription = ConclusionClass.GetFlatteredRuleDescription(secoundSimpleTree);

            MessageBox.Show("Mamy nadmiarowość z ograniczeniem " + firstRuleDescription + secoundRuleDescription + "z ograniczeniem numer"+value.NumberOfConstrain);
        }

        private static Constrain CompareRulesForConstrainRedundancy
            (List<SimpleTree> firstList, List<SimpleTree> secoundList, GatheredBases bases)
        {
            //Function check if firstList is a part of secoundList

            int count = 0;
            var returnedConstrain = new Constrain();

            //TODO: pomysleć z sortowaniem żeby była pewność
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
                            MessageBox.Show("tak mamy nadmiarowosc pomiedzy regułami a ograniczeniami");
                        } //TODO:jeszcze trzeba zwrócić ograniczenie żeby było wiadomo w raporcie co się nie zgadza
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

                if (count == firstList.Count) //wszystkie elementy z listy jeden muszą sie zawierać w liście2
                {
                    return false;
                }
            }
            return true;
        }
    }
}