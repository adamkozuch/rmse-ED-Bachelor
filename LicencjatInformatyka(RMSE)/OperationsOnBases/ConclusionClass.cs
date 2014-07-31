using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using LicencjatInformatyka_RMSE_.Bases;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;
using LicencjatInformatyka_RMSE_.ViewControls.AskWindows;
using MessageBox = System.Windows.MessageBox;

namespace LicencjatInformatyka_RMSE_.OperationsOnBases
{
    public class ConclusionClass
    {
      
        private readonly GatheredBases _bases;
        private readonly ViewModel.ViewModel _viewModel;

        public ConclusionClass(GatheredBases bases, ViewModel.ViewModel viewModel)
        {
            _bases = bases;
            _viewModel = viewModel;
            
        }

    public   void AskedConditions()
       {
           List<string> askingConditionList= new List<string>();
            foreach (var rule in _bases.RuleBase.RulesList)
            {
                foreach (var condition in rule.Conditions)
                {
                    if (_bases.RuleBase.RulesList.Any(p => p.Conclusion == condition))
                    {
                        //TODO:Coœ zjeba³em
                    }
                    else
                    {
                        if (ConclusionOperations.CheckIfStringIsFact(condition, _bases.FactBase.FactList) == false)
                            //if()
                        {
                            foreach (var element in askingConditionList)
                            {
                                if (condition == element)
                                    goto label;
                            }
                            askingConditionList.Add(condition);
                        label:;
                        }
                    }
                }
                
            }
_viewModel.AskingConditionsList = askingConditionList;
        }

        public bool BackwardConclude( Rule checkedRule)
        {

            var tree = TreeOperations.ReturnComplexTreeAndDifferences(_bases, checkedRule);

            var possibleTrees = TreeOperations.ReturnPossibleTrees(tree.Values.First(), tree.Keys.First());


            foreach (var onePossibility in possibleTrees) //flattering all possible configurations of conditions
            {
                List<SimpleTree> askableTable = onePossibility.Where(var => var.Dopytywalny).ToList();

                // sprawdzamy czy jest w bazie faktow
                foreach (SimpleTree simpleTree in askableTable)
                {
                    if (ConclusionOperations.CheckIfStringIsFact(simpleTree.rule.Conclusion, _bases.FactBase.FactList))
                        simpleTree.rule.ConclusionValue = true;
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
                ConstrainAsk(simpleTree);
                if (simpleTree.rule.Model)
                {
                    ProcessModel(simpleTree.rule.Conclusion);
                }

                if (simpleTree.rule.ConclusionValue)
                    i++;
                else
                {
                    _viewModel.CheckedRuleName = simpleTree.rule.Conclusion;
                   AskRuleValue window = new AskRuleValue(_viewModel);
                   
                    window.ShowDialog();  // TODO:Mo¿e wystapiæ bug zwi¹zany z zamknieciem okna x w lewym górnym rogu
                    
                    simpleTree.rule.ConclusionValue = _viewModel.CheckedRuleVal;

                    if (_viewModel.CheckedRuleVal)
                        i++;          
                }
            }

            if (i == askingTable.Count)
                return true; // hipoteza jest prawdziwa
            return false; //else trzeba sprawdzac dalej
        }

        private void ConstrainAsk(SimpleTree simpleTree)
        {
            foreach (var constrain in _bases.ConstrainBase.ConstrainList)
            {
                foreach (var constrainCondition in constrain.ConstrainConditions)
                {
                    if (constrainCondition == simpleTree.rule.Conclusion)
                    {
                        AskForConstrainValue(constrain);
                    }
                }
            }
        }

        private void AskForConstrainValue(Constrain constrain)
        {
            _viewModel.AskedConstrain = constrain;
           var window = new AskConstrain(_viewModel);
            window.ShowDialog();

            SetConstrainValue(_viewModel.ValueFromConstrain, _viewModel.AskedConstrain);

        }

        private void SetConstrainValue(string valueFromConstrain, Constrain askedConstrain)
        {
            if (valueFromConstrain != "")
            {
                foreach (var constrain in askedConstrain.ConstrainConditions)
                {
                    if (constrain == valueFromConstrain)
                        _bases.FactBase.FactList.Add(new Fact() {FactName = constrain, FactValue = true});
                    else
                    {
                        _bases.FactBase.FactList.Add(new Fact() {FactName = constrain, FactValue = false});
                    }

                }
            }
            _viewModel.ValueFromConstrain = "";
        }

        private bool ProcessModel(string conclusion)
        {
            IEnumerable<Model> models = _bases.ModelsBase.ModelList.Where(p => p.Conclusion == conclusion);
            foreach (Model model in models)
            {
                bool start = CheckStartCOndition(model.StartCondition);
                start = true;  //TODO: pamiêtaæ ¿eby zmieniæ to przypisanie
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
            
            string checkedArgument = CheckInArguments(arg);
            if (checkedArgument == null)
            {
                IEnumerable<Model> models = FindModels(arg);
                foreach (Model model in models)
                {
                    string modelValue = DoArithmetic(model);
                    if (modelValue != null)
                    {
                        return modelValue;
                    }
                }
            }
            AskArgument window = new AskArgument(_viewModel);
            window.ShowDialog();
            return _viewModel.ValueArgument;
        }

        private string DoArithmetic(Model model)
        {
            if (model.ModelType == "simple")
            {
                string firstModelValue = CheckInArguments(model.FirstArg);
                string secoundModelValue = CheckInArguments(model.SecoundArg);
                if (firstModelValue == null)
                {
                    firstModelValue = ArgumentValue(firstModelValue);
                }
                if (secoundModelValue == null)
                {
                    secoundModelValue = ArgumentValue(secoundModelValue);
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
                    if (model.FactorsList.Count == factorsList.Count)
                        return Arithmetic.PolynomialModel(variable, factorsList, model.PowerList); 

                }


            } //posprawdzac nazwy

            MessageBox.Show("Cos nie tak z modelami");
            return null;
        }


        #region Secondary
        private string ArgumentValue(string argument)
        {
            string argumentValue = CheckInArguments(argument);
            if (null == argumentValue)
            {
                IEnumerable<Model> models = FindModels(argument);
                if (!models.Any()) { }
                //    AskValue(argument); todo: tutaj odkomentowac i oprogramowac
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
       
        #endregion
        private bool CheckStartCOndition(string startCondition)
        {
            bool value = ConclusionOperations.CheckIfStringIsFact(startCondition, _bases.FactBase.FactList);
            if (value)
                return true;
            List<Rule> rules = ConclusionOperations.FindRulesWithParticularConclusion(startCondition,
                _bases.RuleBase.RulesList);
            if (rules.Count == 0)
            {
                AskRuleValue  askRule = new AskRuleValue(_viewModel);
                askRule.ShowDialog();

            }
                foreach (Rule rule in rules)
            {
                
                bool val =
                    BackwardConclude(rule);
                if (val)
                    return true;
            }
            return false;
        }

       
    }
}