using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;
using LicencjatInformatyka_RMSE_.OperationsOnBases;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.Bases
{
    public class SoundBase
    {
        private readonly ViewModel _model;
        private List<Sound> _SoundList = new List<Sound>();

        public List<Sound> SoundList
        {
            get { return _SoundList; }
            set { _SoundList = value; }
        }

        public SoundBase(ViewModel model)
        {
            _model = model;
        }

        public void ReadSound(string path)
        {
            foreach (string line in File.ReadLines(path, Encoding.GetEncoding("Windows-1250")))
            {

                Match m = Regex.Match(line, _model._elementsNamesLanguageConfig.sound);
                if (m.Success)
                {

                    var value = CreateSound(line);
                    if (value != null)
                        SoundList.Add(value);

                }

            }

        }

        private Sound CreateSound(string line)
        {
            var fact = OperationsOnString.RemoveBeggining(line);
            var factConverted = OperationsOnString.SplitArguments(fact);

            return new Sound() { soundNumber = int.Parse(factConverted[0]), soundPath = factConverted[1] };


        }
    }
}
