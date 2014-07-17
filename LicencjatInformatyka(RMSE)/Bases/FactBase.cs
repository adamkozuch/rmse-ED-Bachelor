using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using LicencjatInformatyka_RMSE_.NewFolder2;
using LicencjatInformatyka_RMSE_.NewFolder3;

namespace LicencjatInformatyka_RMSE_.Bases
{
   public class FactBase
    {
       private List<Fact> _factList = new List<Fact>();

       public List<Fact> FactList
       {
           get { return _factList; }
           set { _factList = value; }
       }


       public void ReadFacts(string path)
       {
           foreach (string line in File.ReadLines(path, Encoding.GetEncoding("Windows-1250")))
           {
            
               Match m = Regex.Match(line, "^fakt");
               if (m.Success)
               {

                   var value = CreateFact(line);
                   if(value!=null)
                   FactList.Add(value);

               }
                   
           }

       }

       private Fact CreateFact(string line)
       {
          var fact =  OperationsOnString.RemoveBeggining(line);
         var  factConverted = OperationsOnString.SplitArguments(fact);
           if(CheckIfAskable(factConverted)==false)
               return new Fact(){FactName = factConverted[0],FactValue = true};
           else
           {
               MessageBox.Show("Fakt " + factConverted + "nie jest dopytywalny");
               return null;
           }

       }

       private bool CheckIfAskable(List<string> factConverted)
       {
           throw new NotImplementedException();
       }
    }
}
