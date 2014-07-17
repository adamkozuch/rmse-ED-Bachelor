using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using LicencjatInformatyka_RMSE_.NewFolder2;
using LicencjatInformatyka_RMSE_.NewFolder3;
using LicencjatInformatyka_RMSE_.NewFolder5;
using LicencjatInformatyka_RMSE_.OperationsOnBases;

namespace LicencjatInformatyka_RMSE_.Command
{
    internal class ConclusionClass
    {
        public enum ModelType
        {
            simple,
            extended,
            linear,
            poly
        }

        private readonly GatheredBases _bases;

        public ConclusionClass(GatheredBases bases)
        {
            _bases = bases;
        }

        public bool Conclude(List<List<SimpleTree>> possibleTrees)
        {
            foreach (var onePossibility in possibleTrees) //flattering all possible configurations of conditions
            {
                List<SimpleTree> askableTable = onePossibility.Where(var => var.Dopytywalny).ToList();

                // sprawdzamy czy jest w bazie faktow
                foreach (SimpleTree rule in askableTable)
                {
                    foreach (Fact fact in _bases.FactBase.FactList)
                    {
                        if (rule.rule.Conclusion == fact.FactName) //set value of asking conditions
                            rule.rule.ConclusionValue = true;
                    }
                }

                bool conclusionValue = CheckConclusionValueOrCountModel(askableTable); // Check if all asking are true

                if (conclusionValue)
                {
                    MessageBox.Show("Hipoteza prawdziwa");
                    return true;
                }
            }
            return false;
        }

        private bool CheckConclusionValueOrCountModel(List<SimpleTree> askingTable)
        {
            int i = 0;
            foreach (SimpleTree simpleTree in askingTable)
            {
                if (simpleTree.rule.Model)
                {
                    ProcessModel(simpleTree.rule.Conclusion);
                }

                if (simpleTree.rule.ConclusionValue)
                    i++;
                else
                {
                    MessageBox.Show("Wprowadz wartoœæ warunku" + " " + simpleTree.rule.Conclusion);
                    simpleTree.rule.ConclusionValue = true;
                }
            }

            if (i == askingTable.Count)
                return true; // hipoteza jest prawdziwa
            return false; //else trzeba sprawdzac dalej
        }


        /// <summary>
        ///     masakra z tymi modelami trzeba to jeszcze raz przeanalizowaæ wprowadziæ
        ///     obliczenia i sprawdziæ logikê oraz uproœciæ
        /// </summary>
        /// <param name="conclusion"></param>
        // t¹ metodê trzeba potraktowaæ jako pocz¹tek w którym jest przetwarzany model relacyjny
        private bool ProcessModel(string conclusion)
        {
            IEnumerable<Model> models = _bases.ModelsBase.ModelList.Where(p => p.Conclusion == conclusion);
            foreach (Model model in models)
            {
                bool start = CheckStartCOndition(model.StartCondition);
                start = true;
                if (start)
                {
                    if (model.ModelType == "simple")
                    {
                        var concreteArgs = new List<string>();
                        string str1 = FillArgsTable(model.FirstArg);
                        string str2 = FillArgsTable(model.SecoundArg);

                        return Arithmetic.RelationalOperation(model.Operation, str1, str2);
                    }
                    if (model.ModelType == "extended")
                    {
                        string str1 = FillArgsTable(model.ArgumentsList[0]);
                        string str2 = FillArgsTable(model.ArgumentsList[1]);
                        string str3 = FillArgsTable(model.ArgumentsList[2]); // trzeba sprawdziæ czy s¹ nulami
                        return Arithmetic.ExtendedRelationalModel(model.Operation, str1, str2, str3);
                    }
                }
            }
            MessageBox.Show("Nieukonkretniono modleu");
            return false; // ni
        }

        private string FillArgsTable(string arg)
        {
            Model model;
            string r = CheckInArguments(arg);
            if (r == null)
            {
                IEnumerable<Model> mod = FindModels(arg);
                foreach (Model VARIABLE in mod)
                {
                    string value = DoArithmetic(VARIABLE);
                    if (value != null)
                    {
                        return value;
                    }
                }
            }
            MessageBox.Show("Dopytaj " +arg);
            return null;
        }

        private string DoArithmetic(Model model)
        {
            if (model.ModelType == "simple")
            {
                string firstModelValue = CheckInArguments(model.FirstArg);
                string secoundModelValue = CheckInArguments(model.SecoundArg);
                if (firstModelValue == null)
                {
                    IEnumerable<Model> models = FindModels(firstModelValue);
                    if (!models.Any())
                    {
                        firstModelValue = AskValue(model.FirstArg);
                    }
                    else
                    {
                        foreach (Model mod in models)
                        {
                            firstModelValue = DoArithmetic(mod);
                            if (firstModelValue != null)
                                break;
                        }
                    }
                }

                if (firstModelValue == null)
                    return null;
                if (secoundModelValue == null)
                    return null;


                return Arithmetic.OperationForBasicModel
                    (model.Operation, firstModelValue, secoundModelValue).ToString();
                // to musi byc rezultat ale nie wiem czy przeparsowac
                // do stringa
            }
            if (model.ModelType == "extended")
            {
                var argumentValueList = new List<string>();
                foreach (string argument in model.ArgumentsList)
                {
                    var argumentValue = ArgumentValue(argument);
                    if (argumentValue != null)
                        argumentValueList.Add(argumentValue);
                    else
                    {
                        MessageBox.Show("Nieukonkretniony");
                        return null;
                    }

                    if (argumentValueList.Count == model.ArgumentsList.Count)
                        return Arithmetic.ExtendedArithmeticModel(argumentValueList, model.Operation);
                }
            }
            else if (model.ModelType == "linear")
            {
                List<string> factors = new List<string>();
                List<string> variablesList = new List<string>();
                foreach (var factor in model.FactorsList)
                {
                    var factorValue = ArgumentValue(factor);
                    if (factorValue != null)
                        factors.Add(factorValue);
                    else 
                    {
                      MessageBox.Show("Nieukonkretniony");
                        return null;
                    }
                }

                foreach (var variable in model.VariablesList)
                {
                    var variableValue = ArgumentValue(variable);
                    if (variableValue != null)
                        factors.Add(variableValue);
                    else
                    {
                        MessageBox.Show("Nieukonkretniony");
                        return null;
                    }
                }
             return   Arithmetic.LinearValue(factors, variablesList);

            }
            else if (model.ModelType == "polynomial")
            {
                var variable = ArgumentValue(model.VariableValue);
                List<string> factorsList = new List<string>();
                foreach (var factor in model.FactorsList)
                {
                    var factorValue = ArgumentValue(factor);
                    if (factorValue != null)
                        factorsList.Add(factorValue);
                    else
                    {
                        MessageBox.Show("Nieukonkretniony");
                        return null;
                    }
                }


            } //posprawdzac nazwy

            MessageBox.Show("Cos nie tak z modelami");
            return null;
        }

        private string ArgumentValue(string argument)
        {
            string argumentValue = CheckInArguments(argument);
            if (null == argumentValue)
            {
                IEnumerable<Model> models = FindModels(argument);
                if (!models.Any())
                    AskValue(argument);
                else
                {
                    foreach (Model model1 in models)
                    {
                        argumentValue = DoArithmetic(model1);
                        if (argumentValue != null)
                            break;
                    }
                }
            }
            return argumentValue;
        }

        private IEnumerable<Model> FindModels(string firstModelValue)
        {
            return _bases.ModelsBase.ModelList.Where(model => model.Conclusion == firstModelValue).ToList();
        }


        private string AskValue( string s)
        {
            MessageBox.Show("Pytam o wartosc  "+s);
            return null;
        }

        private string CheckInArguments(string firstArg)
        {
            // trzeba zrobic zwracanie null w razie braku odpowiedniego argumentu albo zwrocic zero
            foreach (Argument argument in _bases.ArgumentBase.argumentList)
            {
                if (firstArg == argument.ArgumentName)
                    return argument.Value;
            }
            return null;
        }

        private void DoRelations(Model model)
        {
            throw new NotImplementedException();
        }

        private bool CheckStartCOndition(string startCondition)
        {
            bool value = ConclusionOperations.CheckIfStringIsFact(startCondition, _bases.FactBase.FactList);
            if (value)
                return true;
            List<Rule> rules = ConclusionOperations.FindRulesWithParticularConclusion(startCondition,
                _bases.RuleBase.RulesList);
            if (rules.Count == 0)
                Ask();
            foreach (Rule rule in rules)
            {
                Dictionary<List<List<Rule>>, SimpleTree> complexTree =
                    TreeOperations.ReturnComplexTreeAndDifferences(_bases, rule);
                bool val =
                    Conclude(TreeOperations.ReturnPossibleTrees(complexTree.Values.First(), complexTree.Keys.First()));
                if (val)
                    return true;
            }
            return false;
        }

        private bool Ask()
        {
            MessageBox.Show("Pytam o bool");
            return false;
        }
    }
}