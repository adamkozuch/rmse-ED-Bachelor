using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using LicencjatInformatyka_RMSE_.NewFolder2;

namespace LicencjatInformatyka_RMSE_.NewFolder3
{
    public static class ConclusionOperations
    {
        private static List<SimpleTree> ReturnAlternativeBranches(List<Rule> rulesWithSameConclusion)
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
            var divideList = new List<List<Rule>>();

            var conditionTree = new SimpleTree {rule = ruleForCheck};
            IEnumerable<SimpleTree> parentWithoutChildren;

            do
            {
                parentWithoutChildren = TreeToEnumerable(conditionTree).
                    Where(p => p.Children.Count == 0).
                    Where(p => p.Dopytywalny == false);


                foreach (SimpleTree parentWithoutChild in parentWithoutChildren)
                {
                    foreach (string simpleTree in parentWithoutChild.rule.Conditions)
                    {
                        List<Rule> returnedRules = FindRulesWithParticularConclusion(simpleTree, baseList);

                        if (returnedRules.Count == 0)
                        {
                            var endRule = new Rule();
                            endRule.Conclusion = simpleTree;
                            parentWithoutChild.Children.Add(new SimpleTree {Dopytywalny = true, rule = endRule});
                        }
                        else
                        {
                            List<SimpleTree> alt = ReturnAlternativeBranches(returnedRules);
                            parentWithoutChild.Children.AddRange(alt);

                            if (returnedRules.Count > 1)
                            {
                                divideList.Add(returnedRules);
                            }
                        }
                    }
                }
            } while (parentWithoutChildren.Count() != 0);

            DivideTree(conditionTree,divideList);
            return conditionTree;
        }


        private static List<List<Rule>> difference(List<List<Rule>> divideList, List<Rule> r)
        {
            var list = new List<List<Rule>>();
            
            
            foreach (var lista in divideList)
            {
                
                int i = 0;
                var g = new List<Rule>(); 
                foreach (var rule in lista)
                {
                    if(rule != r[i])
                        g.Add(rule);
                        i++;
                }
                list.Add(g);
                
            }
            return list;
        }

        public static T DeepCopy<T>(T obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                stream.Position = 0;

                return (T)formatter.Deserialize(stream);
            }
        }

        private static void DivideTree(SimpleTree tree, List<List<Rule>> divideList)
        {
            IEnumerable<IEnumerable<Rule>> cartesianProducts = CartesianProduct(divideList);
            List<List<Rule>> list = new List<List<Rule>>();
            string s = "";
          
            foreach (var particularConfig in cartesianProducts.ToList())
            {
                var r = particularConfig;
                list.Add(  r.ToList());
        
                foreach (var oneTable in list)
                {
                    var y = difference(divideList, oneTable).SelectMany(m =>m);
                    y = y.ToArray();
                    var res = divideList.SelectMany(il => il);
                    res = res.ToArray();


                    var t = TreeToEnumerable(tree).Where(p => p.rule != y.First());  // może być tak że kolekcja jest nodyfikowana i jest usowane za duzo elementow
                    //{
                    //    foreach (var VARIABLE in y)
                    //    {
                    //        if (p.rule != VARIABLE)
                    //            return true;
                    //    }
                    //    return false;
                    //});
                    
                       
                        
                     

                    foreach (var VARIABLE in t)
                    {
                        if(VARIABLE.Dopytywalny)
                        s += " "+ VARIABLE.rule.Conclusion;
                    }
                    s += "\n\n";
                }
            }
              int i = 0;

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
    }
}