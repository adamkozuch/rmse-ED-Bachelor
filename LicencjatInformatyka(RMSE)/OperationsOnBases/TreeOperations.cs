using System.Collections.Generic;
using System.Linq;
using LicencjatInformatyka_RMSE_.Bases;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;
using LicencjatInformatyka_RMSE_.OperationsOnBases.ConcludeFolder;

namespace LicencjatInformatyka_RMSE_.OperationsOnBases
{
    public static class TreeOperations
    {
        #region MainTree
        public static List<SimpleTree> ReturnAlternativeBranches(List<Rule> rulesWithSameConclusion,SimpleTree parent)
        {
            return rulesWithSameConclusion.Select(rule => new SimpleTree {rule = rule,Parent = parent}).ToList();
        }

        
        public static SimpleTree ReturnComplexTreeAndDifferences
            (GatheredBases bases, Rule ruleForCheck, List<List<Rule>>differencesList  )
        {

             differencesList = new List<List<Rule>>();

            var conditionTree = new SimpleTree {rule = ruleForCheck};
            IEnumerable<SimpleTree> parentWithoutChildren;


            do
            {
                parentWithoutChildren = TreeToEnumerable(conditionTree).Where(p => p.Children.Count == 0).
                    Where(p => p.Dopytywalny == false);

                foreach (SimpleTree parentWithoutChild in parentWithoutChildren)
                {
                    ExpandBrunchOrMakeAskable(bases, parentWithoutChild, differencesList);
                }
            } while (parentWithoutChildren.Count() != 0);
            
            return conditionTree;
        }








      public static List<List<SimpleTree>> ReturnPossibleTrees(SimpleTree tree, List<List<Rule>> divideList)
        {
          
          
            IEnumerable<IEnumerable<Rule>> cartesianProducts = CartesianProduct(divideList);


            var returnResult = new List<List<SimpleTree>>();
            foreach (var particularConfig in cartesianProducts.ToList())
            {
                IEnumerable<Rule> differenceList =
                    ReturnDifferenceBetweenTables(divideList, particularConfig.ToList()).SelectMany(m => m);

                IEnumerable<SimpleTree> oneSolution = ReturnTreeEllementsWithoutDifferences(tree,
                    differenceList.ToList());

                SimpleTree[] treeToList = oneSolution.ToArray();
                bool isDouble = RemoveDoubles(returnResult, treeToList);


                if (isDouble)
                    returnResult.Add(oneSolution.ToList());
            }

            return returnResult;
        }




        public static void ExpandBrunchOrMakeAskable
            (GatheredBases bases, SimpleTree parentWithoutChild, List<List<Rule>> divideList)
        {
            foreach (string condition in parentWithoutChild.rule.Conditions)
            {
                List<Rule> returnedRules = ConclusionClass.FindRulesWithParticularConclusion(condition,
                    bases.RuleBase.RulesList);

                if (returnedRules.Count == 0)
                {
                    bool isModel = CheckIfModel(condition, bases);
                    var endRule = new Rule {Conclusion = condition, Model = isModel , NumberOfRule = bases.RuleBase.RulesList.Count+1000};
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

        public static bool CheckIfModel(string condition, GatheredBases bases)
        {
            return bases.ModelsBase.ModelList.Any(model => model.Conclusion == condition);
        }

        public static List<List<Rule>> ReturnDifferenceBetweenTables(List<List<Rule>> divideList,
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
        private static bool RemoveDoubles(List<List<SimpleTree>> returnResult, SimpleTree[] treeToList)
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

   
    }
}