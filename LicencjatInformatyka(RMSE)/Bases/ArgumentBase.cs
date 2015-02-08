using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;
using LicencjatInformatyka_RMSE_.OperationsOnBases;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.Bases
{
  public  class ArgumentBase
    {
      private readonly ViewModel _model;
      //
   public   List<Argument>  argumentList = new List<Argument>();

      public ArgumentBase(ViewModel model)
      {
          _model = model;
      }

      public void ReadArguments(string path)
   {
       foreach (string line in File.ReadLines(path, Encoding.GetEncoding("Windows-1250")))
       {

           Match m = Regex.Match(line, _model._elementsNamesLanguageConfig.Argument);
           if (m.Success)
           {

               var value = CreateArgument(line);
               if (value != null)
                   argumentList.Add(value);

           }

       }

   }

   private Argument CreateArgument(string line)
   {
       var argument = OperationsOnString.RemoveBeggining(line);
       var argumentConverted = OperationsOnString.SplitArguments(argument);
       if (CheckIfAskable(argumentConverted) == false)
           return new Argument() { ArgumentName = argumentConverted[0],Value = argumentConverted[1]};
       else
       {
           MessageBox.Show("Fakt " + argumentConverted + "nie jest dopytywalny");
           return null;
       }

   }

   private bool CheckIfAskable(List<string> factConverted)
   {
       throw new NotImplementedException();
   }

    }
}
