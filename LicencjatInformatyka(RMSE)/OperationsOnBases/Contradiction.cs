using System.Collections.Generic;
using System.Linq;
using System.Windows;
using LicencjatInformatyka_RMSE_.Additional;
using LicencjatInformatyka_RMSE_.NewFolder2;
using LicencjatInformatyka_RMSE_.NewFolder3;

namespace LicencjatInformatyka_RMSE_.OperationsOnBases
{
    /// <summary>
    ///     Class Contradiction.
    /// </summary>
    public static class Contradiction
    {



        #region OutsideContradiction
        /// <summary>
        ///     Checks the outside contradiction.
        ///     Ta metoda będzie slużyła jedynie do stwierdzenia że sprzeczność występuje
        ///     natomiast żeby diagnozowac kolejne reguły trzeba bedzie wymyślić coś innego
        /// </summary>
        /// <param name="bases">The bases.</param>
        public static List<Rule> CheckOutsideContradiction(GatheredBases bases)
        {
            var contradictedRules = new List<Rule>();
            foreach (Rule RuleI in bases.RuleBase.RulesList)
            {
                int i = 100;

                RepeatGoto: //if result too long double i value
                List<object> complexTree = TreeOperations.MethodForContradiction(bases, RuleI, i);

                if ((bool) complexTree[1] == false)
                {
                    IEnumerable<SimpleTree> currentEndOfTree =
                        TreeOperations.TreeToEnumerable((SimpleTree) complexTree[0]).Where(p => p.Children.Count == 0);

                    foreach (SimpleTree currentEnd in currentEndOfTree)
                    {
                        //TODO: metoda nie sprawdza wszystkich regul albo i sprawdza
                        SimpleTree node = currentEnd;
                        SimpleTree checkedValue = currentEnd;
                        string s = "";
                        while (node.Parent != null)
                        {
                            s += " " + node.rule.NumberOfRule;
                            node.rule = node.Parent.rule;
                            if (checkedValue == node)
                            {
                                AddRuleToContradictionTable(contradictedRules, RuleI);
                                break;
                            }
                        }
                    }
                    if (contradictedRules.Count == 0)
                    {
                        i = i*2;
                        goto RepeatGoto;
                        // W razie jakby reguła okazała się barzdo długa powtarzamy operacje ze zwiekszoną wartością
                    }
                }
            }
            return contradictedRules;
        }


        public static void AddRuleToContradictionTable
            (List<Rule> table, Rule rule)
        {
            int i = 0;
            foreach (Rule VARIABLE in table)
            {
                if (VARIABLE != rule)
                    i++;
            }

            if (table.Count == i)
                table.Add(rule);
        }


        public static void ReportAboutContradictionInRules(GatheredBases bases)
        {
            List<Rule> list = CheckOutsideContradiction(bases);

            foreach (Rule rule in list)
            {
                foreach (string VARIABLE in rule.Conditions)
                {
                    if (VARIABLE == rule.Conclusion)
                        MessageBox.Show("Reguła " + rule.NumberOfRule + " jest samosprzeczna");
                    break;
                }

                var listT = new List<Rule>();
                for (int i = 1; i < 100; i++)
                {
                    List<object> tree = TreeOperations.MethodForContradiction(bases, rule, i);

                    IEnumerable<SimpleTree> g =
                        TreeOperations.TreeToEnumerable((SimpleTree) tree.First()).Where(p => p.Children.Count == 0);

                    foreach (SimpleTree VARIABLE in g)
                    {
                        string s = "";
                        SimpleTree r = VARIABLE;
                        if (VARIABLE.rule.NumberOfRule == rule.NumberOfRule) //TODO:COs nie działa to if
                        {
                            bool boolValue = true;
                            while (r.Parent.rule != rule) //TODO: Wykminic to raportowanie
                            {
                                if (boolValue == false)
                                {
                                    r = r.Parent;
                                }
                                boolValue = false;

                                s += r.rule.NumberOfRule + "==>";
                            }
                            MessageBox.Show("Reguła " + rule.NumberOfRule + " jest zewnętrznie sprzeczna" +
                                            "można to wykazać stosując następujące podstawienie" + s);

                            goto Res;
                        }
                    }
                }

                Res:
                ;
            }
        }
        #endregion
        /// <summary>
        ///     Checks the contradiction w ith models and rulebase.
        /// </summary>
        /// <param name="bases">The bases.</param>
        /// 
        ///
        #region ModelContradiction
        public static void CheckContradictionWIthModelsAndRulebase(GatheredBases bases)
        {
            foreach (Rule rule in bases.RuleBase.RulesList)
            {
                Dictionary<List<List<Rule>>, SimpleTree> r = TreeOperations.ReturnComplexTreeAndDifferences(bases, rule);

                IEnumerable<SimpleTree> tree = TreeOperations.TreeToEnumerable
                    (r.Values.First()).Where(p => p.Dopytywalny);

                foreach (SimpleTree condition in tree)
                {
                    IEnumerable<Model> models =
                        bases.ModelsBase.ModelList.Where(p => p.Conclusion == condition.rule.Conclusion);
                    if (models.Count() != 0)
                    {
                        // trzeba zebrać wszystkie warunki startowe
                        // jeszcze zrobić mały research 

                        foreach (Model model in models)
                        {
                            var list = new List<string>();
                            List<string> listOfStartedConditions = GatherStartConditions
                                (model, bases, list);
                            //TODO:Z tego co się orientuję nie ma tu sprawdzenia warunkow startowych
                            // z modelami relacyjnymi oraz modeli arytmetycznych z modelami arytmetycznymi 
                            CheckContradictionBetweenRulesAndStartedConditions
                                (listOfStartedConditions, condition);
                       //     CheckContradictionBetweenModelsAndStartedConditions();
                         //   CheckContradictionBetweenArithmeticModels();
                        }
                    }
                }
            }

            MessageBox.Show("Modele i reguly ok");
        }

        // metode mozna wykozystac do modeli relacyjnych jako warunki startowe
        /// <summary>
        ///     Checks the contradiction between rules and started conditions.
        /// </summary>
        /// <param name="listOfStartedConditions">The list of started conditions.</param>
        /// <param name="ruleForCheck">The rule for check.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool CheckContradictionBetweenRulesAndStartedConditions
            (List<string> listOfStartedConditions, SimpleTree ruleForCheck)
        {
            int i = 0;
            while (ruleForCheck.Parent != null)
            {
                if (i != 0)
                    ruleForCheck = ruleForCheck.Parent;
                foreach (string startedCondition in listOfStartedConditions)
                {
                    if (startedCondition == ruleForCheck.rule.Conclusion)
                    {
                        MessageBox.Show("Konflikt pomiędzy modelami i regułami" + startedCondition);
                        return false;
                    }
                }
                i++;
            }
            return true;
        }

        // metoda do przepracowania
        /// <summary>
        ///     Gathers the start conditions.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="bases">The bases.</param>
        /// <param name="r">The r.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        private static List<string> GatherStartConditions(Model model, GatheredBases bases, List<string> r)
        {
            if (model.StartCondition != "bez warunku")
                r.Add(model.StartCondition);

            if (model.ModelType == "simple")
            {
                IEnumerable<Model> models = bases.ModelsBase.ModelList.Where(p => p.Conclusion == model.FirstArg);
                foreach (Model model1 in models)
                {
                    r.AddRange(GatherStartConditions(model1, bases, r)); //
                }
                models = bases.ModelsBase.ModelList.Where(p => p.Conclusion == model.SecoundArg);
                foreach (Model model1 in models)
                {
                    r.AddRange(GatherStartConditions(model1, bases, r)); //
                }
            }
            if (model.ModelType == "extended")
            {
                foreach (string argument in model.ArgumentsList)
                {
                    string argument1 = argument;

                    IEnumerable<Model> models = bases.ModelsBase.ModelList.Where(p => p.Conclusion == argument1);

                    foreach (Model model1 in models)
                    {
                        r.AddRange(GatherStartConditions(model1, bases, r)); //
                    }
                }
            }
            return r;
        }
        #endregion
        /// <summary>
        ///     Checks the contradiction in constrains.
        /// </summary>
        /// <param name="bases">The bases.</param>
        /// <param name="constrainsList">The constrains list.</param>

        #region ConstrainContradiction
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
                        int count = (from flatteredConditions in flatteredRule
                            from constrainCondition in constrain.ConstrainsList
                            where flatteredConditions.Dopytywalny
                            where constrainCondition == flatteredConditions.rule.Conclusion
                            select flatteredConditions).Count();

                        if (count > 1) // If more than one there is a contradiction
                            MessageBox.Show("Sprzeczność pomiędzy regułą " + rule.NumberOfRule + " i ograniczeniem" +
                                            constrain.NumberOfLimit);
                    }
                }
            }
        }
        #endregion
    }
}