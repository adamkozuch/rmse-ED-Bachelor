using System;
using System.Collections.Generic;
using System.Linq;
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


        // Funkcje Create Read Delete dla warunkow dopytywalnych
        // Oraz algorytm wnioskowania w przód oraz wstecz
        //public static void CheckTypeOfRule(List<Rule> r)
        //{
        //    Stopwatch watch = new Stopwatch();
        //    watch.Start();
        //    foreach (Rule regulaTestowana in r)
        //        foreach (string warunek in regulaTestowana.Conditions)
        //            foreach (Rule regulaInna in r)
        //            {
        //                if (warunek == regulaInna.Conclusion)
        //                {
        //                    regulaTestowana.Dopytywalne = false;
        //                    break;
        //                }
        //            }
        //    watch.Stop();
        //    Console.WriteLine(watch.ElapsedMilliseconds);
        //}

        public static void ForwardChaining()
        {
        }

        public static void BackwardChaining()
        {
        }


        //public static void InputOfConstrains(Dictionary<string, bool> dictionary, GatheredBases d)
        //{
        //    foreach (var constrain in d.ConstrainList)
        //    {
        //        foreach (var fact in dictionary)
        //        {
        //            if (fact.Value == true)
        //            {
        //                foreach (var VARIABLE in constrain.ConstrainsList)
        //                {
        //                    if (VARIABLE == fact.Key)
        //                    {
        //                        ConstrainChange(constrain, fact.Key, dictionary);
        //                        // wprowadzenie ograniczenia do systemu
        //                        // czy baza ograniczeń jest aktualizowana po całym obiegu 
        //                        // czy raczej po każdej zmianie wniosku
        //                        // odpowiedzią jest cykl przynajmniej w przypadku wnioskowania w przód bo jeden cykl równa się jedna reguła
        //                        //czy 
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}


        // Method divide string to part with rule and rest of rule

        // ta metoda ma spłaszczyć tylko jeden konkretny warunek problem w tym gdzie zzapisac ten warunek biorąc pod uwagę że 
        // metoda będzie zwracała samą siebie 
        //public static List<string> Spłaszczenie(Rule regulaRule, List<Rule> listaRules, List<string> listaSplaszczonych)
        //{
        //    foreach (var sprawdzanyWarunek in regulaRule.Conditions)
        //    {
        //        //int i = CountConditions(sprawdzanyWarunek, listaRules);
        //        // to tutaj coś powinno się wykonać tyle razy ile zostało znalezionych wnioskow

        //        //for (int n = 0; n < i; n++)
        //        //{
        //            List<string> tabList = FindConditionsOrReturnCheckedCondition(sprawdzanyWarunek, listaRules);

        //            if (tabList[0] == sprawdzanyWarunek)
        //            {
        //                // to jest zakonczenie pętli
        //                listaSplaszczonych.Add(sprawdzanyWarunek);
        //            }
        //            else
        //            {
        //                Rule r = FindRule(sprawdzanyWarunek, listaRules);
        //                //czy jak dodam rezultat sołaszczenia do listySplaszczonych to dane nie beda sie dublowaly
        //                List<string>list = new List<string>();
        //                ConclusionOperations.Spłaszczenie(r, listaRules, listaSplaszczonych);

        //            }
        //        }
        //    //}
        //    return listaSplaszczonych;
        //}




      static  private List<SimpleTree> ReturnAlternativeTrees(List<Rule> rulesWithSameConclusion)
        {
          var listOfSubtrees = new List<SimpleTree>();

          foreach (var rule in rulesWithSameConclusion)
          {
              var parent = new SimpleTree() {Name = rule.Conclusion};

              foreach (var condition in rule.Conditions)
              {
                  var child = new SimpleTree() {Name = condition};
                  parent.Children.Add(child);
                  child.Parent = parent;
              }

              listOfSubtrees.Add(parent);
          }
          return listOfSubtrees;
        }





        public static void Conclude(List<Rule> baseList, Rule ruleForCheck)
        {
            ////////////////////////////////////////////////////////////////////////
          //  List<Rule> rulesWithSameName = FindRulesWithParticularConclusion(ruleForCheck, baseList);
            
            
            var conditionTree = new SimpleTree {Name = ruleForCheck.Conclusion};
            var listOfConditions = new List<string>();
            IEnumerable<SimpleTree> parentsWithoutAddedChilds = FamilyToEnumerable(conditionTree);
            ////////////////////////////////////////////////////////////////////////////////////////

            var numberOfRules = FindRulesWithParticularConclusion(ruleForCheck, baseList);

            var subtrees = ReturnAlternativeTrees(numberOfRules);

            foreach (var simpleTree in subtrees)
            {

            }








            do
            {
                parentsWithoutAddedChilds = FamilyToEnumerable(conditionTree).
                    Where(p => p.Children.Count == 0).
                    Where(p => p.Dopytywalny == false); // Wyszukuje końcowe osobniki

                var numberOfRules = FindRulesWithParticularConclusion(ruleForCheck, baseList);

                var subtrees = ReturnAlternativeTrees(numberOfRules);

                foreach (var simpleTree in subtrees)
                {
                    
                }

                     


                        foreach (SimpleTree checkedParent in parentsWithoutAddedChilds)
                        {
                            listOfConditions = FindConditionsOrReturnCheckedCondition(checkedParent.Name, baseList);
                            if (listOfConditions == null)
                            {
                                checkedParent.Dopytywalny = true;
                            }
                            else
                            {
                                foreach (string warunekKtoryBedzieDodany in listOfConditions)
                                {
                                    var t = new SimpleTree {Name = warunekKtoryBedzieDodany};
                                    checkedParent.Children.Add(t);
                                }
                            }
                        }
                    

                

            } while (parentsWithoutAddedChilds.Count() != 0);

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


        private static IEnumerable<SimpleTree> FamilyToEnumerable(SimpleTree f)
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