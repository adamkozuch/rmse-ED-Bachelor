using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using LicencjatInformatyka_RMSE_.Additional;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;
using LicencjatInformatyka_RMSE_.OperationsOnBases;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.Bases
{
  public  class ConstrainBase
    {
      private  List<Constrain> _constrainList = new List<Constrain>();
      private ViewModel _config;
        public List<Constrain> ConstrainList
        {
            get { return _constrainList; }
            set { _constrainList = value; }
        }

      public ConstrainBase(ViewModel config)
      {
          _config = config;
      }
        public void ReadConstrains(string path)
        {
            foreach (string line in File.ReadLines(path, Encoding.GetEncoding("Windows-1250")))
            {  
                Match m = Regex.Match(line, _config._elementsNamesLanguageConfig.Constrain);
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
