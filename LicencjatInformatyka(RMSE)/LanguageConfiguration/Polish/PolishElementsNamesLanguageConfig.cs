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
        private string _rule="^reguła";
        private string _fact="^fakt";
        private string _constrain="^ograniczenie";
        private string _noConditionInModel="bez warunku";
        private string _graphic="^grafika";
        private string _advice="^rada";
        private string _sound="^dźwięk";

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

        public string Rule
        {
            get { return _rule; }
        }

        public string Fact
        {
            get { return _fact; }
        }

        public string Constrain
        {
            get { return _constrain; }
        }

        public string NoConditionInModel
        {
            get { return _noConditionInModel; }
        }

        public string graphic
        {
            get { return _graphic; }
        }

        public string advice
        {
            get { return _advice; }
        }

        public string sound
        {
            get { return _sound; }
        }
    }
}
