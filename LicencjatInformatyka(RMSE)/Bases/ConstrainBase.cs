using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using LicencjatInformatyka_RMSE_.NewFolder2;
using LicencjatInformatyka_RMSE_.NewFolder3;

namespace LicencjatInformatyka_RMSE_.NewFolder4
{
  public  class ConstrainBase
    {
      private  List<Constrain> _constrainList = new List<Constrain>();
        
        public List<Constrain> ConstrainList
        {
            get { return _constrainList; }
            set { _constrainList = value; }
        }
        public void ReadConstrains(string path)
        {
            foreach (string line in File.ReadLines(path))
            {  
                Match m = Regex.Match(line, "^ograniczenie");
                if(m.Success)
              _constrainList.Add(  RuleChecker(line));
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
