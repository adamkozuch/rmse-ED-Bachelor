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

/// <summary>
/// The OperationsOnBases namespace.
/// </summary>

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using LicencjatInformatyka_RMSE_.Bases;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;
using LicencjatInformatyka_RMSE_.OperationsOnBases.ConcludeFolder;

namespace LicencjatInformatyka_RMSE_.OperationsOnBases.DiagnoseFolder
{
    /// <summary>
    /// Class Redundancy.
    /// </summary>
    internal class Redundancy
    {
        /// <summary>
        /// Invokes the specified bases.
        /// </summary>
        /// <param name="bases">The bases.</param>
        public static void Invoke(GatheredBases bases)
        {
            //TODO: Przy redundancji trzeba uwzględnic to że reguła nie jest jedynie redundantna w przypadku spłaszczenia jedne wybranej reguły na wszystkie sposoby ale również w takich samych reguł ale nie powiązanych


            //foreach (Rule ruleForCheck in bases.RuleBase.RulesList)
            //{
            //    List<List<Rule>> differencesList;
            //    var tree = TreeOperations.ReturnComplexTreeAndDifferences(
            //          bases, ruleForCheck, out differencesList);
            //    List<List<SimpleTree>> possibleTrees = TreeOperations.ReturnPossibleTrees(tree,
            //        differencesList);
            //    allFlatteredRules.AddRange(possibleTrees);

            //}
            //CheckRedundancy(allFlatteredRules);

            var alreadyChecked = new List<string>();
            foreach (Rule ruleForCheck in bases.RuleBase.RulesList)
            {
                if (alreadyChecked.Contains(ruleForCheck.Conclusion) == false)
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

                    // nie badam dopytywalnych
                    // trzeba mieć wszystkie reguły z z tą samą nazwą
                    CheckRedundancy(allFlatteredRules); // TODO: błąd bo program nie uwzglądnia tego że czasem część reguł jest podobna i wyznacza nadmiarowośc i tak CBA i DBA
                    Contradiction.CheckContradictionWithConstrains(allFlatteredRules, bases);
                    alreadyChecked.Add(ruleForCheck.Conclusion);
                }
            }
        }

       

        /// <summary>
        /// Checks the redunancy.
        /// </summary>
        /// <param name="possibleTrees">The possible trees.</param>
        /// <param name="rule">The rule.</param>
        private static void CheckRedundancy(List<List<SimpleTree>> possibleTrees)
        {
            foreach (var VARIABLE in possibleTrees)
            {
                foreach (var list in possibleTrees)
                {
                    if (VARIABLE != list)
                    {
                        List<SimpleTree> firstList = VARIABLE.Where(p => p.Askable).ToList();
                        List<SimpleTree> secoundList = list.Where(p => p.Askable).ToList();

                        bool value = CompareRules(firstList,secoundList);
                        if (value == false)
                        {
                            IEnumerable<SimpleTree> firstParent = VARIABLE.Where(p => p.Parent == null);
                            IEnumerable<SimpleTree> secoundParent = list.Where(p => p.Parent == null);

                            IEnumerable<SimpleTree> firstFlattern = VARIABLE.Where(p => p.Askable);
                            IEnumerable<SimpleTree> secoundFlattern = list.Where(p => p.Askable);


                            string firtsRule = "";
                            string secoundRule = "";
                            foreach (var tree in firstFlattern)
                            {
                                firtsRule += " " + tree.rule.Conclusion;
                            }
                            foreach (var tree in secoundFlattern)
                            {
                                secoundRule += " " + tree.rule.Conclusion;
                            }

                            MessageBox.Show("Mamy nadmiarowość " + firstParent.First().rule.NumberOfRule +
                                            "po spłaszczeniu " + firtsRule + "   oraz" +
                                            secoundParent.First().rule.NumberOfRule + "po spłaszczeniu " + secoundRule);
                            goto lab; //TODO: Redundancja jeszcze do zrobienia
                        }
                    }
                }
            }
            lab:
            ;
        }

        private static void CheckRedundancyWithConstrains(List<List<SimpleTree>> allFlatteredRules, GatheredBases bases)
        {
            foreach (var constrain in bases.ConstrainBase.ConstrainList)//TODO:NIe czje
            {
                foreach (var ruleFlattered in allFlatteredRules)
                {
                    List<SimpleTree> askable = ruleFlattered.Where(p => p.Askable).ToList();
                    int i = 0;
                    foreach (var simpleTree in askable)
                    {
                        foreach (var condition in constrain.ConstrainConditions)
                        //
                        {
                            if (simpleTree.rule.Conclusion == condition)
                                i++;
                        }
                    }
               
                        IEnumerable<SimpleTree> firstParent = ruleFlattered.Where(p => p.Parent == null);
                        MessageBox.Show("Jest sprzeczność z bazą ograniczeń pomiędzy regułą " +
                                        firstParent.First().rule.Conclusion + " a"
                                        + "ograniczeniem nr" + constrain.NumberOfConstrain);
                    
                }
            }
        }

        /// <summary>
        /// Compares the secoundList.
        /// </summary>
        /// <param name="firstList">The firstList.</param>
        /// <param name="secoundList">The secoundList.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool CompareRules(List<SimpleTree> firstList, List<SimpleTree> secoundList)
        {
            //Sprawdzamy czy firstList zawiera się w secoundList
         
            int count = 0;
          // teraz jeszcze czy układ elementów jest taki sam

            
             //TODO: pomysleć z sortowaniem żeby była pewność
                if (firstList.Count <= secoundList.Count)
                {
                    //foreach (SimpleTree secoundListElement in secoundList)
                    //{
                    //    if (secoundListElement.rule.Conclusion == firstList[i].rule.Conclusion)
                    //        count++;
                    //    i++;
                    //}
                    var newFirstList = firstList.OrderBy(p => p.rule.Conclusion);
               var  newSecoundList = secoundList.OrderBy(tree => tree.rule.Conclusion);
                    var firstListAdd=new List<SimpleTree>();;
                    var secoundListAdd=new List<SimpleTree>();
                    foreach (var simpleTree in newSecoundList)
                    {
                        secoundListAdd.Add(simpleTree);
                    }

                    foreach (var simpleTree in newFirstList)
                    {
                        firstListAdd.Add(simpleTree);
                    }


                    
                    
                    
                    
                    for (int i = 0; i < firstList.Count; i++)
                    {
                         if (secoundListAdd[i].rule.Conclusion == firstListAdd[i].rule.Conclusion)
                             count++;
                    }
                  

                    if (count == firstList.Count)//wszystkie elementy z listy jeden muszą sie zawierać w liście2
                    {
                        return false;
                    }
                }
            
            return true;
        }
    }
}