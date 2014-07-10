using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using LicencjatInformatyka_RMSE_.NewFolder2;
using LicencjatInformatyka_RMSE_.NewFolder3;

namespace LicencjatInformatyka_RMSE_.NewFolder4
{
    class ConstrainBase
    {
        List<Constrain> limitList = new List<Constrain>();
        
        public List<Constrain> LimitList
        {
            get { return limitList; }
            set { limitList = value; }
        }
        public void ReadConstrains(string limits)
        {
            foreach (string line in File.ReadLines(limits))
            {  
                Match m = Regex.Match(line, "^ograniczenie");
                if(m.Success)
              limitList.Add(  RuleChecker(line));
            }
        }


        private Constrain RuleChecker(string line)
        {

            line =    OperationsOnString.RemoveBeggining(line);
            string[] table = OperationsOnString.SplitRuleToTwoPartsConditionsAndAnother(line);
            List<string> table1 = OperationsOnString.SplitArguments(line);
            int constrainNUmber = int.Parse(table1[0]);
            List<string> conditions = OperationsOnString.SplitArguments(table[1]);

            return new Constrain(conditions,constrainNUmber);




        }
        public void EditBase()
        { }
        public void BrowskingBase()
        { }
        public void CreateBase()
        { }
        public void DeleteBase()
        { }

        
    }
}
