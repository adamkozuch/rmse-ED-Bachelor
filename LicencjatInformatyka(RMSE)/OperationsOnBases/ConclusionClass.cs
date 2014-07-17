using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using LicencjatInformatyka_RMSE_.NewFolder2;
using LicencjatInformatyka_RMSE_.NewFolder3;
using LicencjatInformatyka_RMSE_.NewFolder5;
using LicencjatInformatyka_RMSE_.OperationsOnBases;

namespace LicencjatInformatyka_RMSE_.Command
{
    internal class ConclusionClass
    {
        private GatheredBases _bases;

        public ConclusionClass(GatheredBases bases)
        {
            _bases = bases;
        }

        public bool Conclude(List<List<SimpleTree>> possibleTrees)
        {
            foreach (var onePossibility in possibleTrees) //flattering all possible configurations of conditions
            {
                var askableTable = onePossibility.Where(var => var.Dopytywalny).ToList();

                // sprawdzamy czy jest w bazie faktow
                foreach (var rule in askableTable)
                {
                    foreach (var fact in _bases.FactBase.FactList)
                    {

                        if (rule.rule.Conclusion == fact.FactName)  //set value of asking conditions
                            rule.rule.ConclusionValue = true;
                    }
                }
               
                var conclusionValue  = CheckConclusionValue(askableTable); // Check if all asking are true

                if (conclusionValue)
                {
                    MessageBox.Show("Hipoteza prawdziwa");
                    return true;
                }
            }
            return false;
        }

        private  bool CheckConclusionValue(List<SimpleTree> askingTable)
        {
            int i = 0;
            foreach (var simpleTree in askingTable)
            {
                if (simpleTree.rule.Model)
                {
                    ProcessModel(simpleTree.rule.Conclusion);


                }

                if (simpleTree.rule.ConclusionValue)
                    i++;
                else
                {
                    
                    MessageBox.Show("Wprowadz wartoœæ warunku" +" "+ simpleTree.rule.Conclusion);
                    simpleTree.rule.ConclusionValue = true;
                }
            }

            if (i == askingTable.Count)
                return true; // hipoteza jest prawdziwa
            return false;//else trzeba sprawdzac dalej
        }

        private   void ProcessModel(string conclusion)
        {

            var models = _bases.ModelsBase.ModelList.Where(p => p.Conclusion == conclusion);
            foreach (var model in models)
            {
              var start =  CheckStartCOndition(model.StartCondition);
                if (start)
                {
                    if (model.ModelType == "simple")
                    {
                        DoRelations(model);
                        DoArithmetic(model);
                    }
                    else
                    {
                        DoArithmetic(model);
                    }

                }

            }
        }

        private float DoArithmetic(Model model)
        {
            if (model.ModelType == "simple")
            {
                var firstModelValue = CheckInArguments(model.FirstArg);
                if (firstModelValue ==null )
                {
                   return Robocza(model);
                }
                
                    return AskValue();
                
            }
           
        }

        private float Robocza(Model model)
        {
            var models = _bases.ModelsBase.ModelList.Where(p => p.Conclusion == model.FirstArg);
            // brak jest sprawdzenia warunku modelu i dopytania
            if (models.Count() == 0)
            {
                return AskValue();
            }

            foreach (var VARIABLE in models)
            {
              var startCondition =  CheckStartCOndition(model.StartCondition);
                if(startCondition)
                return DoArithmetic(VARIABLE);
            }
          
        }

        private float AskValue()
        {
            throw new NotImplementedException();
        }

        private float? CheckInArguments(string firstArg)
        {
            // trzeba zrobic zwracanie null w razie braku odpowiedniego argumentu albo zwrocic zero
            foreach (var argument in _bases.ArgumentBase.argumentList)
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
            var value = ConclusionOperations.CheckIfStringIsFact(startCondition,_bases.FactBase.FactList);
            if (value)
                return true;
            var rules = ConclusionOperations.FindRulesWithParticularConclusion(startCondition, _bases.RuleBase.RulesList);
            if (rules.Count == 0)
                Ask();
            foreach (var rule in rules)
            {


               var complexTree = TreeOperations.ReturnComplexTreeAndDifferences(_bases,rule);
              var val =  Conclude(TreeOperations.ReturnPossibleTrees(complexTree.Values.First(),complexTree.Keys.First()));
                if(val)
                    return true;
            }
            return false;
            
        }

        private bool Ask()
        {
            throw new NotImplementedException();
        }
    }
}