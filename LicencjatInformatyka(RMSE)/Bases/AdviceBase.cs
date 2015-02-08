

using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;
using LicencjatInformatyka_RMSE_.OperationsOnBases;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.Bases
{
    public class AdviceBase
    {
        private readonly ViewModel _model;
        private List<Advice> _AdviceList = new List<Advice>();

        public List<Advice> AdviceList
        {
            get { return _AdviceList; }
            set { _AdviceList = value; }
        }

        public AdviceBase(ViewModel model)
        {
            _model = model;
        }


        public void ReadAdvice(string path)
        {
            foreach (string line in File.ReadLines(path, Encoding.GetEncoding("Windows-1250")))
            {

                Match m = Regex.Match(line, _model._elementsNamesLanguageConfig.advice);
                if (m.Success)
                {

                    var value = CreateAdvice(line);
                    if (value != null)
                        AdviceList.Add(value);

                }

            }

        }

        private Advice CreateAdvice(string line)
        {
            var fact = OperationsOnString.RemoveBeggining(line);
            var factConverted = OperationsOnString.SplitArguments(fact);

            return new Advice() { adviceNumber = int.Parse(factConverted[0]), advicePath = factConverted[1] };


        }
    }
}
