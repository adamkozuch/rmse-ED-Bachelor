using System.Collections.Generic;
using System.Linq;
using LicencjatInformatyka_RMSE_.Additional;
using LicencjatInformatyka_RMSE_.NewFolder2;
using LicencjatInformatyka_RMSE_.NewFolder3;
using LicencjatInformatyka_RMSE_.NewFolder5;

namespace LicencjatInformatyka_RMSE_.OperationsOnBases
{
    public static class TreeOperations
    {
        #region MainTree
        private static List<SimpleTree> ReturnAlternativeBranches(List<Rule> rulesWithSameConclusion,SimpleTree parent)
        {
            return rulesWithSameConclusion.Select(rule => new SimpleTree {rule = rule,Parent = parent}).ToList();
        }

        // Najgorzej wygl¹daj¹ca metoda
        public static Dictionary<List<List<Rule>>, SimpleTree> ReturnComplexTreeAndDifferences
            (GatheredBases bases, Rule ruleForCheck)
        {
            var divideList = new List<List<Rule>>();

            var conditionTree = new SimpleTree {rule = ruleForCheck};
            IEnumerable<SimpleTree> parentWithoutChildren;


            do
            {
                parentWithoutChildren = TreeToEnumerable(conditionTree).Where(p => p.Children.Count == 0).
                    Where(p => p.Dopytywalny == false);

                foreach (SimpleTree parentWithoutChild in parentWithoutChildren)
                {
                    ExpandBrunchOrMakeAskable(bases, parentWithoutChild, divideList);
                }
            } while (parentWithoutChildren.Count() != 0);
            


            var treeAndDifferencesDictionary = new Dictionary<List<List<Rule>>, SimpleTree>
            {
                {divideList, conditionTree}
            };
            return treeAndDifferencesDictionary;
        }
 public static List<List<SimpleTree>> ReturnPossibleTrees(SimpleTree tree, List<List<Rule>> divideList)
        {
            IEnumerable<IEnumerable<Rule>> cartesianProducts = CartesianProduct(divideList);


            var returnResult = new List<List<SimpleTree>>();
            foreach (var particularConfig in cartesianProducts.ToList())
            {
                IEnumerable<Rule> differenceList =
                    ReturnDifferenceBetweenTables(divideList, particularConfig.ToList()).SelectMany(m => m);

                IEnumerable<SimpleTree> oneSolutionTree = ReturnTreeEllementsWithoutDifferences(tree,
                    differenceList.ToList());

                SimpleTree[] treeToList = oneSolutionTree.ToArray();
                bool isDouble = IsDouble(returnResult, treeToList);


                if (isDouble)
                    returnResult.Add(oneSolutionTree.ToList());
            }

            return returnResult;
        }
        private static void ExpandBrunchOrMakeAskable
            (GatheredBases bases, SimpleTree parentWithoutChild, List<List<Rule>> divideList)
        {
            foreach (string condition in parentWithoutChild.rule.Conditions)
            {
                List<Rule> returnedRules = ConclusionOperations.FindRulesWithParticularConclusion(condition,
                    bases.RuleBase.RulesList);

                if (returnedRules.Count == 0)
                {
                    bool model =   CheckModel(condition, bases);
                    var endRule = new Rule {Conclusion = condition, Model = model , NumberOfRule = 100};
                    parentWithoutChild.Children.Add(new SimpleTree {Dopytywalny = true, rule = endRule,Parent = parentWithoutChild});
                }
                else
                {
                    List<SimpleTree> alternativeBranches = ReturnAlternativeBranches(returnedRules,parentWithoutChild);  //
                    parentWithoutChild.Children.AddRange(alternativeBranches);

                    if (returnedRules.Count > 1)
                    {
                        divideList.Add(returnedRules);
                    }
                }
            }
        }
        #endregion

        private static bool CheckModel(string condition, GatheredBases bases)
        {
            return bases.ModelsBase.ModelList.Any(model => model.Conclusion == condition);
        }

        private static List<List<Rule>> ReturnDifferenceBetweenTables(List<List<Rule>> divideList,
            List<Rule> currentTable)
        {
            var resultList = new List<List<Rule>>();

            int i = 0;
            foreach (var lista in divideList)
            {
                List<Rule> g = lista.Where(rule => rule != currentTable[i]).ToList();
                i++;
                resultList.Add(g);
            }
            return resultList; // w tej liœci chcê otrzymaæ divide list pomniejszon¹ o elementy z current table
        }


       
        #region secondary
        private static bool IsDouble(List<List<SimpleTree>> returnResult, SimpleTree[] treeToList)
        {
            foreach (var treeResult in returnResult) // usowanie dubluu¹cych rezultatow
            {
                int numberOfTreeElement = 0;
                int count = 0;
                foreach (SimpleTree treeElement in treeToList)
                {
                    if (treeToList.Count() != treeResult.Count)
                        break;
                    if (treeResult[numberOfTreeElement] == treeElement)
                        count++;
                    numberOfTreeElement++;
                }
                if (count == treeToList.Count())
                {
                    return false;
                }
            }
            return true;
        }

        private static IEnumerable<IEnumerable<T>> CartesianProduct<T>
            (this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct =
                new[] {Enumerable.Empty<T>()};
            return sequences.Aggregate(
                emptyProduct,
                (accumulator, sequence) =>
                    from accseq in accumulator
                    from item in sequence
                    select accseq.Concat(new[] {item}));
        }
        #endregion

        public static IEnumerable<SimpleTree> TreeToEnumerable(SimpleTree f)
        {
            var stack = new Stack<SimpleTree>();
            stack.Push(f);
            while (stack.Count > 0)
            {
                SimpleTree family = stack.Pop();

                yield return family;
                foreach (SimpleTree child in family.Children)

                    stack.Push(child);
            }
        }

        public static IEnumerable<SimpleTree> ReturnTreeEllementsWithoutDifferences(SimpleTree f, List<Rule> sRules)
        {
            var stack = new Stack<SimpleTree>();
            stack.Push(f);
            while (stack.Count > 0)
            {
                SimpleTree family = stack.Pop();
                yield return family;
                foreach (SimpleTree child in family.Children)
                {
                    bool value = sRules.All(sRule => sRule != child.rule);
                    if (value)
                        stack.Push(child);
                }
            }
        }

        #region Contradiction
        public static List<object> MethodForContradiction
            (GatheredBases bases, Rule ruleForCheck, int o)
        {
            var divideList = new List<List<Rule>>();
            
            var conditionTree = new SimpleTree { rule = ruleForCheck };
            IEnumerable<SimpleTree> parentWithoutChildren;
           
            int i = 0;
            do
            {
                parentWithoutChildren = TreeToEnumerable(conditionTree).Where(p => p.Children.Count == 0).
                    Where(p => p.Dopytywalny == false);

                foreach (SimpleTree parentWithoutChild in parentWithoutChildren)
                {
                    ExpandBrunchOrMakeAskable(bases, parentWithoutChild, divideList); 
                    i++;

                if (i==o)
                {


                    var treeAndDifferences = new List<object>();
                    treeAndDifferences.Add(conditionTree);
                    treeAndDifferences.Add(false);
                    return treeAndDifferences;
                }  //TODO: ta pêtla nie jest odporna na sprzecznoœæ
                }

               

            } while (parentWithoutChildren.Count() != 0);



            var treeAndDifferencesDictionary = new List<object>();
            treeAndDifferencesDictionary.Add(conditionTree);
            treeAndDifferencesDictionary.Add(true);
           return  treeAndDifferencesDictionary;
        }
        #endregion
    }
}