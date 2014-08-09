using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicencjatInformatyka_RMSE_.Additional
{
    class PolishElementsNamesLanguageConfig:IElementsNamesLanguageConfig
    {
        private string _simpleModel="model";
        private string _extendedModel="model_r";
        private string _linearModel="model_liniowy";
        private string _polyModel="model_wielomianowy";
        private string _modelFact="m_fakt";
        private string _argument="argument_znany";

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
