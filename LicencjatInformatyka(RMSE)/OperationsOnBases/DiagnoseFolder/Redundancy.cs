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
            foreach (Rule ruleForCheck in bases.RuleBase.RulesList)
            {
                List<Rule> ruleList = ConclusionClass.FindRulesWithParticularConclusion
                    (ruleForCheck.Conclusion, bases.RuleBase.RulesList);
                var b = new List<List<SimpleTree>>();
                foreach (Rule VARIABL in ruleList)
                {
                    List<List<Rule>> differencesList;
                    var tree = TreeOperations.ReturnComplexTreeAndDifferences(
                        bases, ruleForCheck,out differencesList);
                    List<List<SimpleTree>> possibleTrees = TreeOperations.ReturnPossibleTrees(tree,
                        differencesList);
                    b.AddRange(possibleTrees);
                }
                // nie badam dopytywalnych
                // trzeba mieć wszystkie reguły z z tą samą nazwą
                CheckRedunancy(b, ruleForCheck);
            }
        }

        /// <summary>
        /// Checks the redunancy.
        /// </summary>
        /// <param name="possibleTrees">The possible trees.</param>
        /// <param name="rule">The rule.</param>
        private static void CheckRedunancy(List<List<SimpleTree>> possibleTrees, Rule rule)
        {
            foreach (var VARIABLE in possibleTrees)
            {
                foreach (var list in possibleTrees)
                {
                    if (VARIABLE != list)
                    {
                        List<SimpleTree> t = VARIABLE.Where(p => p.Askable).ToList();
                        List<SimpleTree> h = list.Where(p => p.Askable).ToList();

                        bool value = CompareRules(h, t);
                        if (value == false)
                        {
                            IEnumerable<SimpleTree> o = VARIABLE.Where(p => p.Parent == null);
                            IEnumerable<SimpleTree> f = list.Where(p => p.Parent == null);
                            MessageBox.Show(rule.Conclusion + " " + rule.NumberOfRule + " " +
                                            o.First().rule.NumberOfRule + " " + f.First().rule.NumberOfRule);
                            goto lab; //TODO: Redundancja jeszcze do zrobienia
                        }
                    }
                }
            }
            lab:
            ;
        }


        /// <summary>
        /// Compares the rules.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="rules">The rules.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool CompareRules(List<SimpleTree> list, List<SimpleTree> rules)
        {
            //Sprawdzamy czy lista zawiera się w rules
            int i = 0;
            int n = 0;
            int c = 0;
            foreach (SimpleTree VARIABLE in rules)
            {
                if (VARIABLE.rule.Conclusion == list[i].rule.Conclusion)
                    n++;
                c++;
                i++;
            }
            if (n == list.Count)
            {
                return false;
            }
            return true;
        }
    }
}