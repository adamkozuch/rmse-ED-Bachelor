using System.Collections.Generic;
using System.Linq;
using System.Windows;
using LicencjatInformatyka_RMSE_.Bases;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;
using LicencjatInformatyka_RMSE_.ViewControls.AskWindows;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.OperationsOnBases.ConcludeFolder
{
    public class ModelActions
    {
       private ConclusionClass conclusionClass;
        private ViewModel viewModel;
        private GatheredBases bases;
        public ModelActions
            (ConclusionClass _conclusionClass, ViewModel _viewModel, GatheredBases _bases)
        {
            conclusionClass = _conclusionClass;
            viewModel = _viewModel;
            bases = _bases;

        }
        public bool ProcessModel(string conclusion)
        {
            IEnumerable<Model> models = bases.ModelsBase.ModelList.Where(p => p.Conclusion == conclusion);
            foreach (Model model in models)
            {
                bool start = CheckStartCondition(model.StartCondition);
                //TODO: pamiêtaæ ¿eby zmieniæ to przypisanie
                if (start)
                {
                    if (model.ModelType == "simple")
                    {
                        var concreteArgs = new List<string>();
                        string str1 = ArgumentValue(model.FirstArg);
                        string str2 = ArgumentValue(model.SecoundArg);//TODO:argument mo¿e byæ odrazu liczb¹

                        return Arithmetic.RelationalOperation(model.Operation, str1, str2);
                    }
                    if (model.ModelType == "extended")
                    {
                        string str1 = ArgumentValue(model.ArgumentsList[0]);
                        string str2 = ArgumentValue(model.ArgumentsList[1]);
                        string str3 = ArgumentValue(model.ArgumentsList[2]); // trzeba sprawdziæ czy s¹ nulami
                        return Arithmetic.ExtendedRelationalModel(model.Operation, str1, str2, str3);
                    }
                }
            }
            MessageBox.Show("Nieukonkretniono modleu");
            return false; // ni
        }

        //private string FillArgsTable(string arg)
        //{
            
        //    string checkedArgument = CheckInArguments(arg);
        //    if (checkedArgument == null)
        //    {
        //        IEnumerable<Model> models = FindModels(arg);
        //        foreach (Model model in models)
        //        {
        //            string modelValue = DoArithmetic(model);
        //            if (modelValue != null)
        //            {
        //                return modelValue;
        //            }
        //        }
        //    }
        //    AskArgument window = new AskArgument(viewModel);
        //    window.ShowDialog();
        //    return viewModel.ValueArgument;
        //}
   
        private string ArgumentValue(string argument)
        {
            string argumentValue = CheckInArguments(argument);
            float t;
            if (float.TryParse(argument, out t))
            {
                return argument;

            }else

            if (null == argumentValue)
            {
                IEnumerable<Model> models = FindModels(argument);
                if (!models.Any())
                {
                    viewModel.AskingArgumentName = argument;
                    AskArgument window = new AskArgument(viewModel);
                    window.ShowDialog();
                    return viewModel.ValueArgument;
                   
                }
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

    

        private IEnumerable<Model> FindModels(string firstModelValue)
        {
            return bases.ModelsBase.ModelList.Where(model => model.Conclusion == firstModelValue).ToList();
        }

        private string CheckInArguments(string firstArg)
        {
            // trzeba zrobic zwracanie null w razie braku odpowiedniego argumentu albo zwrocic zero
            foreach (Argument argument in bases.ArgumentBase.argumentList)
            {
                if (firstArg == argument.ArgumentName)
                    return argument.Value;
            }
            return null;
        }

        private bool CheckStartCondition(string startCondition)
        {

            if (startCondition != "bez warunku")
            {
                bool value = ConclusionClass.CheckIfStringIsFact(startCondition, bases.FactBase.FactList);
                if (value)
                    return true;
                List<Rule> rules = ConclusionClass.FindRulesWithParticularConclusion(startCondition,
                    bases.RuleBase.RulesList);
                if (rules.Count == 0)
                {
                    AskRuleValue askRule = new AskRuleValue(viewModel);
                    askRule.ShowDialog();

                }
                foreach (Rule rule in rules)
                {

                    bool startConditionValue = conclusionClass.BackwardConclude(rule);
                    if (startConditionValue)
                        return true;
                }
                return false;
            }
            return true;
        }
    }
}