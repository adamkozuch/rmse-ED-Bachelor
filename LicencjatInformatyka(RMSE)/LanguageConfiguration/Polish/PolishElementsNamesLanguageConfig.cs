using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicencjatInformatyka_RMSE_.Additional
{
    class PolishElementsNamesLanguageConfig:IElementsNamesLanguageConfig
    {
        private string _simpleModel;
        private string _extendedModel;
        private string _linearModel;
        private string _polyModel;
        private string _modelFact;
        private string _argument;

        public string SimpleModel
        {
            get { return _simpleModel; }
        }

        public string ExtendedModel
        {
            get { return _extendedModel; }
        }

        public string LinearModel
        {
            get { return _linearModel; }
        }

        public string PolyModel
        {
            get { return _polyModel; }
        }

        public string ModelFact
        {
            get { return _modelFact; }
        }

        public string Argument
        {
            get { return _argument; }
        }
    }
}
