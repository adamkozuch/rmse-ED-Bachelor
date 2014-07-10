using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using LicencjatInformatyka_RMSE_.NewFolder2;

namespace LicencjatInformatyka_RMSE_.NewFolder3
{
    public static class ConclusionOperations
    {
        public static Fact CheckIfStringIsFact(string nameOfConclusion, List<Fact> listOfFacts)
        {
            foreach (Fact factItem in listOfFacts)
            {
                if (factItem.FactName == nameOfConclusion)
                {
                    return factItem;
                }
            }
            return null;
        }



        public static void ForwardChaining()
        {
        }

        public static void BackwardChaining()
        {
        }


       


        private static List<SimpleTree> ReturnAlternativeTrees(List<Rule> rulesWithSameConclusion)
        {
            var listOfSubtrees = new List<SimpleTree>();

            foreach (Rule _rule in rulesWithSameConclusion)
            {
                var parent = new SimpleTree {rule = _rule};

                listOfSubtrees.Add(parent);
            }
            return listOfSubtrees;
        }


        public static SimpleTree BuildComplexTree(List<Rule> baseList, Rule ruleForCheck)
        {
           
            List<List<Rule>> divideList = new List<List<Rule>>();

            var conditionTree = new SimpleTree {rule = ruleForCheck};
            IEnumerable<SimpleTree> AddedChilds;

            do
            {
                AddedChilds = TreeToEnumerable(conditionTree).
                    Where(p => p.Children.Count == 0).
                    Where(p => p.Dopytywalny == false);


                int inut = AddedChilds.Count();

                foreach (SimpleTree addedChild in AddedChilds)
                {
                    foreach (string simpleTree in addedChild.rule.Conditions)
                    {
                        List<Rule> rule = FindRulesWithParticularConclusion(simpleTree, baseList);

                        if (rule.Count == 0)
                        {
                            var r = new Rule();
                            r.Conclusion = simpleTree;
                            addedChild.Children.Add(new SimpleTree {Dopytywalny = true,rule =r });
                            // narazie tylko żeby nie przeszkadzało
                        }
                        else
                        {
                            List<SimpleTree> alt = ReturnAlternativeTrees(rule);
                            addedChild.Children.AddRange(alt);
                            if (rule.Count > 1)
                            {
                                divideList.Add(rule);

                            }

                        }
                    }
                }
                int inu = AddedChilds.Count();
            } while (AddedChilds.Count() != 0);

            return conditionTree;
        }


        private static void DivideTree(SimpleTree tree, List<List<Rule>> divideList)
        {

         var h =   CartesianProduct(divideList);
          //  var i = TreeToEnumerable(tree).Where(p => p.rule == divideList[0]);
            string s="";
        var i =   TreeToEnumerable(tree).Where(p => p != tree.Children[0].Children[0]);

            foreach (var list in h)
            {
          //   var u =   TreeToEnumerable(tree).Where(l => l.rule != list);

               foreach (var simpleTree in list)
               {
                    s += simpleTree.Conclusion.ToString() + " ";
                }

                int b = 0;
            }

           
        }


        static IEnumerable<IEnumerable<T>> CartesianProduct<T>
    (this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct =
              new[] { Enumerable.Empty<T>() };
            return sequences.Aggregate(
              emptyProduct,
              (accumulator, sequence) =>
                from accseq in accumulator
                from item in sequence
                select accseq.Concat(new[] { item }));
        }

        public static
            List<string> FindConditionsOrReturnCheckedCondition
            (string checkedCondition, List<Rule> baseList)
        {
            var lista = new List<string>();

            foreach (Rule rule in baseList)
            {
                if (rule.Conclusion == checkedCondition) // Checking if rule in rulebase is condition 
                {
                    lista.AddRange(rule.Conditions); //LINQ
                    // zwraca dowolną liczbę zestawów warunkow( jakby były np. dwie reguly o tej samej nazwie)
                }
            }
            if (lista.Count == 0) // If not find conditions for rule return checked condition 
                return null; //    lista.Add(checkedCondition);

            return lista;
        }


        public static List<Rule> FindRulesWithParticularConclusion
            (string NameOfCondition, List<Rule> baseList)
        {
            var rulesThatMatch = new List<Rule>();

            foreach (Rule rule in baseList)
            {
                if (rule.Conclusion == NameOfCondition)
                {
                    rulesThatMatch.Add(rule);
                }
            }
            //If return empty list condition for ask (dopytywalny)
            return rulesThatMatch;
        }


        public static List<Fact> LoadConstrain(Constrain constrain, string trueConstrain)
        {
            var factsList = new List<Fact>();
            foreach (string constrainItem in constrain.ConstrainsList)
            {
                if (constrainItem == trueConstrain)
                {
                    factsList.Add(new Fact {FactName = constrainItem, FactValue = true});
                }
                else
                {
                    factsList.Add(new Fact {FactName = constrainItem, FactValue = false});
                }
            }
            return factsList;
        }


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


        public static object Flatter(List<Rule> ruleList)
        {
            throw new NotImplementedException();
        }
    }
}