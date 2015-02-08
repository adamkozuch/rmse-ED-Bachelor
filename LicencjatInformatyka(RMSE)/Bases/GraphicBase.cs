using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;
using LicencjatInformatyka_RMSE_.OperationsOnBases;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.Bases
{
    public class GraphicBase
    {
        private readonly ViewModel _model;

        private List<Graphic> _graphicList = new List<Graphic>();

        public List<Graphic> GraphicList
        {
            get { return _graphicList; }
            set { _graphicList = value; }
        }

        public GraphicBase(ViewModel model)
        {
            _model = model;
        }


        public void ReadGraphic(string path)
        {
            foreach (string line in File.ReadLines(path, Encoding.GetEncoding("Windows-1250")))
            {

                Match m = Regex.Match(line, _model._elementsNamesLanguageConfig.graphic);
                if (m.Success)
                {

                    var value = CreateGraphic(line);
                    if (value != null)
                       GraphicList.Add(value);

                }

            }

        }

        private Graphic CreateGraphic(string line)
        {
            var fact = OperationsOnString.RemoveBeggining(line);
            var factConverted = OperationsOnString.SplitArguments(fact);

            return new Graphic() { graphicNumber = int.Parse(factConverted[0]), graphicPath = factConverted[1] };
          

        }



    }
}
