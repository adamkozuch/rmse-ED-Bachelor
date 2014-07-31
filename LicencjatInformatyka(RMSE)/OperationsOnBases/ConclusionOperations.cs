using System.Collections.Generic;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;

namespace LicencjatInformatyka_RMSE_.OperationsOnBases
{
    public static class ConclusionOperations
    {

       


        public static
            List<string> FindConditionsOrReturnNull
            (string checkedCondition, List<Rule> baseList)
        {
            var lista = new List<string>();

            foreach (Rule rule in baseList)
            {
                if (rule.Conclusion == checkedCondition) // Checking if rule in rulebase is condition 
                {
                    lista.AddRange(rule.Conditions); //LINQ
                    // zwraca dowolną liczbę zestawów warunkow( jakby były np. dwie reguly o tej samej nazwie)
                }
            }
            if (lista.Count == 0) // If not find conditions for rule return checked condition 
                return null; //    lista.Add(checkedCondition);

            return lista;
        }


        public static List<Rule> FindRulesWithParticularConclusion
            (string NameOfCondition, List<Rule> baseList)
        {
            var rulesThatMatch = new List<Rule>();

            foreach (Rule rule in baseList)
            {
                if (rule.Conclusion == NameOfCondition)
                {
                    rulesThatMatch.Add(rule);
                }
            }
            //If return empty list condition for ask (dopytywalny)
            return rulesThatMatch;
        }


        public static List<Fact> LoadConstrainAndReturnFactList(Constrain constrain, string trueConstrain)
        {
            var factsList = new List<Fact>();
            foreach (string constrainItem in constrain.ConstrainConditions)
            {
                if (constrainItem == trueConstrain)
                {
                    factsList.Add(new Fact {FactName = constrainItem, FactValue = true});
                }
                else
                {
                    factsList.Add(new Fact {FactName = constrainItem, FactValue = false});
                }
            }
            return factsList;
        }

        public static bool CheckIfStringIsFact(string nameOfConclusion, List<Fact> listOfFacts)
        {
            foreach (Fact factItem in listOfFacts)
            {
                if (factItem.FactName == nameOfConclusion)
                {
                    return true;
                }
            }
            return false;
        }
    }
}