using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LicencjatInformatyka_RMSE_.OperationsOnBases
{
    public static class OperationsOnString
    {
        public static List<string> SplitArguments(string input)
        {
            Regex csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);
            List<string> list = new List<string>();
            foreach (Match match in csvSplit.Matches(input))
            {
                string s = match.Value.TrimStart(',');
                s = s.Replace("\"", "");
                list.Add(s);
                Console.WriteLine(match.Value.TrimStart(','));
            }
            list[list.Count - 1] = list.Last().Replace(")", "");
            return list;
        }

        public static string[] SplitRuleToTwoPartsConditionsAndAnother(string rule)
        {
            //Extract content of rule
            int conditionsStart = rule.IndexOf("[", System.StringComparison.Ordinal);
            int conditionEnd = rule.IndexOf("]", System.StringComparison.Ordinal);
            string conditions = rule.Substring(conditionsStart + 1, conditionEnd - conditionsStart - 1);
            rule = rule.Remove(conditionsStart, conditionEnd - conditionsStart + 1);

           
            string[] r = {rule, conditions};
            return r;
        }

        public static string RemoveBeggining(string rule)
        {
            int start = rule.IndexOf("(", StringComparison.Ordinal) + 1;
            string result = rule.Substring(start);
            return result;
        }
    }
}