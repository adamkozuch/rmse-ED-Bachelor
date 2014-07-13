using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using LicencjatInformatyka_RMSE_.NewFolder3;

namespace LicencjatInformatyka_RMSE_.Command
{
    internal class OperacjeNaDopytywalnych
    {
        private OpenBasesActions _openBasesActions;

        public OperacjeNaDopytywalnych(OpenBasesActions openBasesActions)
        {
            _openBasesActions = openBasesActions;
        }

        public void ZnajdzDopytywalneWarunki(List<List<SimpleTree>> possibleTrees)
        {
            foreach (var onePossibility in possibleTrees) //type to lista róznic
            {
                var tablicaDopytywalnych = onePossibility.Where(var => var.Dopytywalny).ToList();

                foreach (var rule in tablicaDopytywalnych)
                {
                    foreach (var fact in _openBasesActions.bazaFaktow)
                    {

                        if (rule.rule.Conclusion == fact.FactName)  //ustawiamy wartosci warunkow dopytywalnych
                            rule.rule.ConclusionValue = true;
                    }
                }
               
                var conclusionValue  = SprawdzCzyWniosekPrawda(tablicaDopytywalnych);

                if (conclusionValue)
                {
                    Console.WriteLine("Oh, tak ta hipoteza jest prawdziwa");
                }
            }
        }

        private static bool SprawdzCzyWniosekPrawda(List<SimpleTree> tablicaDopytywalnych)
        {
            int i = 0;
            foreach (var simpleTree in tablicaDopytywalnych)
            {

                if (simpleTree.rule.ConclusionValue)
                    i++;
                else
                {
                    
                    MessageBox.Show("Wprowadz wartoœæ warunku" +" "+ simpleTree.rule.Conclusion);
                    simpleTree.rule.ConclusionValue = true;
                }
            }

            if (i == tablicaDopytywalnych.Count)
                return true; // hipoteza jest prawdziwa
            return false;//else trzeba sprawdzac dalej
        }
    }
}