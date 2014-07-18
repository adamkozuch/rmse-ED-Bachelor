using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LicencjatInformatyka_RMSE_.NewFolder2;
using LicencjatInformatyka_RMSE_.NewFolder3;
using LicencjatInformatyka_RMSE_.NewFolder5;

namespace LicencjatInformatyka_RMSE_.NewFolder4
{
    public class ModelBase
    {
        private readonly ILanguageConfig _config;
        private List<Model> _modelList = new List<Model>();
        private List<Argument> _argumentList = new List<Argument>();

        public ModelBase()
        {
            
        }


        public List<Model> ModelList
        {
            get { return _modelList; }
            set { _modelList = value; }
        }

        public List<Argument> ArgumentList
        {
            get { return _argumentList; }
            set { _argumentList = value; }
        }

        public void ReadRules()
        {
        }

        public void ReadModels(string models)
        {
            foreach (string line in File.ReadLines(models))
            {
                RuleChecker(line);
            }
        }

        private void RuleChecker(string line)
        {
            int modelNameEnd = line.IndexOf("(");
            string TypeOfModel = line.Substring(0, modelNameEnd);

            //browsking apriopriate model
            // Trzeba się zastanowic nad leszym sposobem na identyfikację mało uniwersalny
            if (TypeOfModel == "model")
            {
                ModelList.Add(SimpleModel(line));
            }
            else if (TypeOfModel == _config.ExtendedModel)
            {
                ModelList.Add(ExtendenModel(line));
            }
            else if (TypeOfModel == _config.LinearModel)
            {
                ModelList.Add(LinearModel(line));
            }
            else if (TypeOfModel == _config.PolyModel)
            {
                ModelList.Add(PolyModel(line));
            }
            else if (TypeOfModel == _config.Argument)
            {
                //ArgumentList.Add(ReturnArgument(line));
            } //else if (TypeOfModel == _config.ModelFact) 

            {
            }
        }

        public Model SimpleModel(string line)
        {
            line = OperationsOnString.RemoveBeggining(line);
            List<string> result = OperationsOnString.SplitArguments(line);

            int semaphorNumber = int.Parse(result.Last());

            bool semaphorValue = semaphorNumber == 1;

            return new Model(int.Parse(result[0]), result[1], result[2], result[3],
                result[4], result[5], semaphorValue);
        }

        private Model ExtendenModel(string line)
        {
            line = OperationsOnString.RemoveBeggining(line);
            string[] tableStrings = OperationsOnString.SplitRuleToTwoPartsConditionsAndAnother(line);
            List<string> result = OperationsOnString.SplitArguments(tableStrings[0]);
            List<string> argumentsList = OperationsOnString.SplitArguments(tableStrings[1]);

            int semaphorNumber = int.Parse(result.Last());
            bool semaphorValue = semaphorNumber == 1;

            return new Model(int.Parse(result[0]), result[1], result[2], result[3], argumentsList, semaphorValue);
        }

        private Model LinearModel(string line)
        {
            line = OperationsOnString.RemoveBeggining(line);
            string[] table1 = OperationsOnString.SplitRuleToTwoPartsConditionsAndAnother(line);
            string[] table2 = OperationsOnString.SplitRuleToTwoPartsConditionsAndAnother(line);


            List<string> factorsList = OperationsOnString.SplitArguments(table1[1]);
            List<string> result = OperationsOnString.SplitArguments(table2[0]);
            List<string> variablesList = OperationsOnString.SplitArguments(table2[1]);

            int semaphorNumber = int.Parse(result.Last());
            bool semaphorValue = semaphorNumber == 1;

            return new Model(int.Parse(result[0]), result[1], result[2], factorsList, variablesList, semaphorValue);
        }

        private Model PolyModel(string line)
        {
            line = OperationsOnString.RemoveBeggining(line);
            string[] table1 = OperationsOnString.SplitRuleToTwoPartsConditionsAndAnother(line);
            string[] table2 = OperationsOnString.SplitRuleToTwoPartsConditionsAndAnother(line);
            List<string> factorsList = OperationsOnString.SplitArguments(table1[1]);
            List<string> result = OperationsOnString.SplitArguments(table2[0]);
            char[] commaSeparator = new char[] { ',' };

            
            List<string> powerList = table2[1].Split(commaSeparator).ToList();
            List<int> powerList1 = new List<int>();
            foreach (var VARIABLE in powerList)
            {
                powerList1.Add(int.Parse(VARIABLE));
            }

            int semaphorNumber = int.Parse(result.Last());
            bool semaphorValue = semaphorNumber == 1;

            return new Model(int.Parse(result[0]), result[1], result[2], result[3], factorsList, powerList1,
                semaphorValue);
        }


        //private Model Fact(string line)
        //{
        //    line = OperationsOnString.RemoveBeggining(line);
        //    List<string> list = OperationsOnString.SplitArguments(line);
        //    return new Fact(lis)

        //}

        //private Argument ReturnArgument(string line)
        //{
        //    line = OperationsOnString.RemoveBeggining(line);
        //    List<string> list = OperationsOnString.SplitArguments(line);
        //    return new Argument(list[0], list[1]);
        //}


        public void EditBase()
        {
        }

        public void BrowskingBase()
        {
        }

        public void CreateBase()
        {
        }

        public void DeleteBase()
        {
        }
    }
}