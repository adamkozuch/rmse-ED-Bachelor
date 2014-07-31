using System.Collections.Generic;
using LicencjatInformatyka_RMSE_.OperationsOnBases;

namespace LicencjatInformatyka_RMSE_.Bases.ElementsOfBases
{
  public  class Model
    {

      Arithmetic ar = new Arithmetic();
      public Model()
        { }
      
      public Model(int modelNumber, string startCondition,
            string conclusion, string firstArg
            ,string operation ,string secoundArg, bool semaphor)
        {
            ModelNumber = modelNumber;
            StartCondition = startCondition;
            Conclusion = conclusion;
            FirstArg = firstArg;
            SecoundArg = secoundArg;
            Operation = operation;
            Semaphor = semaphor;
            ModelType = "simple";
            


        }


        public Model(int modelNumber, string startCondition,string operation,
            string conclusion, List<string> argumentsList , bool semaphor)
        {
            ModelNumber = modelNumber;
            StartCondition = startCondition;
            Conclusion = conclusion;
            ArgumentsList = argumentsList;
            Semaphor = semaphor;
            ModelType = "extended";
            //ModelValue = ar.ExtendedArithmeticModel(argumentsList, operation);
        }

        public Model(int modelNumber, string startCondition,
           string conclusion, List<string> factorsList, List<string> variablesList, bool semaphor)
        {
            ModelNumber = modelNumber;
            StartCondition = startCondition;
            Conclusion = conclusion;
            FactorsList = factorsList;
            VariablesList = variablesList;
            Semaphor = semaphor;
            ModelType = "linear";
      
        }

        public Model(int modelNumber, string startCondition,
           string conclusion,string variableValue, List<string> factorsList, List<int> powerList, bool semaphor)
        {
            ModelNumber = modelNumber;
            StartCondition = startCondition;
            Conclusion = conclusion;
            VariableValue = variableValue;
            FactorsList = factorsList;
            PowerList = powerList;
            Semaphor = semaphor;
            ModelType = "polynomial";
        }

      public Model(string arg, int value)
      {
          ModelType = "MArgument";
          ModelValue = value;
      }

      public Model(string s)
      {
          ModelType = "MFact";
      }

      public int ModelNumber { get; set; }

      public string StartCondition { get; set; }

      public string Conclusion { get; set; }

      public string FirstArg { get; set; }

      public string SecoundArg { get; set; }

      public bool Semaphor { get; set; }

      public string VariableValue { get; set; }

      public List<string> ArgumentsList { get; set; }

      public List<string> FactorsList { get; set; }

      public List<string> VariablesList { get; set; }

      public List<int> PowerList { get; set; }

      public string ModelType { get; set; }

      public string Operation { get; set; }

      public int ModelValue { get; set; }
    }
}
