using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LicencjatInformatyka_RMSE_.NewFolder2;
using LicencjatInformatyka_RMSE_.NewFolder3;

namespace LicencjatInformatyka_RMSE_.OperationsOnBases
{
   public static class Sprzecznosc
    {


       public static void SprzecznoscZewnetrzna(List<Rule> bazaRules)
       {
           foreach (var RuleI in bazaRules)
           {
               int i = 100;
              var complexTree = TreeOperations.NowaMetodaSprzecznosc(bazaRules, RuleI,i);

               if ((bool) complexTree[1] == false)  // nie działa z podwojnymi regulami
               {
                   var sprawdzamy =
                       TreeOperations.TreeToEnumerable((SimpleTree) complexTree[0]).Where(p => p.Children.Count == 0);


                   foreach (var simpleTree in sprawdzamy)// dlaczego nie jest sprawdzana z wszystkimi regułami
                   {
                       var node = simpleTree;
                       var wartSprawdzana = simpleTree;

                       while (node.Parent!=null)
                       {
                           

                           node.rule = node.Parent.rule;
                           if (wartSprawdzana == node)
                           {
                               MessageBox.Show("Haha mamy sprzeczność bo wartosc " + node.rule.Conclusion + "występuje w warunku reguly " + wartSprawdzana.Parent.rule.Conclusion   );

                           }

                       }






                   }

               }
              //var possTrees = TreeOperations.NowaMetodaSprzecznosc(complexTree.Values.First(), complexTree.Keys.First(),i);


               // jak zostanie zwrócone dopytywalne sprawdzić czy rodzic dopytywalnego nie jest w którymś miejscu samym dopytywalnym
               // nie muszę chyba nawet spłaszczać 










           }
           


       }


       




    }
}
