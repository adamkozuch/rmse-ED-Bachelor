using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using LicencjatInformatyka_RMSE_.NewFolder2;
using LicencjatInformatyka_RMSE_.NewFolder3;

namespace LicencjatInformatyka_RMSE_.NewFolder4
{
    public class RuleBase
    {
      
        // reguła(Nr_reguły, "Wniosek",[Lista_warunkow odzielona przecinkami w cudzysłowiu ],semafor)
  
        private readonly List<Rule> _baseList = new List<Rule>();

        public List<Rule> RulesList
        {
            get { return _baseList; }
            
        }

     

        public void ReadRules(string rules)
        {
            foreach (string line in File.ReadLines(rules, Encoding.GetEncoding("Windows-1250")))
            {
                Match m = Regex.Match(line, "^reguła");
                if(m.Success)
              _baseList.Add(CreateRule(line));
            }
        }


        public Rule CreateRule(string line)
        {
            List<string> listConditions;
            var listResult = ListResult(line, out listConditions);
 
            var semaphor = listResult.Last();
            int semaphorNumber = int.Parse(semaphor);
            bool semaphorValue;
                switch (semaphorNumber)
                {
                    case 1:
                        semaphorValue = true;
                        break;
                    default:
                        semaphorValue = false;
                        break;
                }
                return new Rule(int.Parse(listResult[0]), listResult[1], listConditions, semaphorValue);
        }

        private List<string> ListResult(string line, out List<string> listConditions)
        {
            string[] rule = OperationsOnString.SplitRuleToTwoPartsConditionsAndAnother(line);
            rule[0] = OperationsOnString.RemoveBeggining(rule[0]);
            List<string> listResult = OperationsOnString.SplitArguments(rule[0]);
            listConditions = OperationsOnString.SplitArguments(rule[1]);
            return listResult;
        }
    }
}