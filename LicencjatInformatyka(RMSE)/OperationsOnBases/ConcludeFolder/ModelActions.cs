using System.Collections.Generic;
using System.Linq;
using System.Windows;
using LicencjatInformatyka_RMSE_.Additional;
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
        private readonly IElementsNamesLanguageConfig _config;

        public ModelActions
            (ConclusionClass _conclusionClass, ViewModel _viewModel, GatheredBases _bases, IElementsNamesLanguageConfig config)
        {
            conclusionClass = _conclusionClass;
            viewModel = _viewModel;
            bases = _bases;
            _config = config;

        }
        public bool? ProcessModel(string conclusion)
        {
            IEnumerable<Model> models = bases.ModelsBase.ModelList.Where(p => p.Conclusion == conclusion);
            foreach (Model model in models)
            {
                bool start = CheckStartCondition(model.StartCondition);
              
                if (start)
                {
                    if (model.ModelType == "simple")
                    {
                        MessageBox.Show("Obliczam model " + model.Conclusion);
                        string str1 = ArgumentValue(model.FirstArg);
                        string str2 = ArgumentValue(model.SecoundArg);
                        if (str1 == null)
                        {
                            MessageBox.Show("Brak argumentu 1");
                            return null;
                        }
                        if (str2 == null)
                        {
                            MessageBox.Show("Brak argumentu 2");
                            return null;
                        }
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
            MessageBox.Show("Nieukonkretniono modelu");
            return false; // ni
        }

  
   
        private string ArgumentValue(string argument)
        {
         
            string argumentValue = CheckInArguments(argument);
            float t;
            if (float.TryParse(argument, out t))
            {
                return argument;

            }



            if (null == argumentValue)
            {
                
                IEnumerable<Model> models = FindModels(argument);

                if (!models.Any())
                {
                 
                    return viewModel.AskingArgumentValueMethod(argument);
                }
                else
                {
                    foreach (Model model1 in models)
                    {
                        if (CheckStartCondition(model1.StartCondition))
                        {
                            argumentValue = DoArithmetic(model1);
                            if (argumentValue != null)
                                break;
                        }
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
                    firstModelValue = ArgumentValue(model.FirstArg);
                }
                if (secoundModelValue == null)
                {
                    secoundModelValue = ArgumentValue(model.SecoundArg);
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

                foreach (var variable in model.VariablesList)  // todo :cos nie tak
                {
                    var variableValue = ArgumentValue(variable);
                    if (variableValue != null)
                        variablesList.Add(variableValue);
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
            foreach (Argument argument in bases.ModelsBase.ArgumentList)
            {
                if (firstArg == argument.ArgumentName)
                    return argument.Value;
            }
            return null;
        }

        private bool CheckStartCondition(string startCondition)
        {

            if (startCondition !=_config.NoConditionInModel)
            {
                bool value = ConclusionClass.CheckIfStringIsFact(startCondition, bases.ModelsBase.ModelFactList);
                if (value)
                    return true;
                var rules = ConclusionClass.FindRulesWithParticularConclusion(startCondition,
                    bases.RuleBase.RulesList);
                var models = FindModels(startCondition); 
                //todo:trzeba sprawdzic jeszcze modele relacyjne
                if (rules.Count == 0)
                {
                    if(!models.Any())
                    {
                        return viewModel.AskingStartConditionValue(startCondition);
                    }
                }
                if (!rules.Any())
                {
                    foreach (var rule in rules)
                    {

                        bool startConditionValue = conclusionClass.BackwardConclude(rule);
                        if (startConditionValue)
                            return true;
                    }
                }
                if (!models.Any())
                {

                    bool startConditionValue =(bool) ProcessModel(startCondition);
                        if (startConditionValue)
                            return true;
                    

                }
                return false;
            }
            return true;
        }

       
    }
}