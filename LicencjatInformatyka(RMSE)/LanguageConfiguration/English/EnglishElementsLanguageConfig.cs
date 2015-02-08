using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LicencjatInformatyka_RMSE_.Additional;

namespace LicencjatInformatyka_RMSE_.LanguageConfiguration
{
    class EnglishElementsLanguageConfig:IElementsNamesLanguageConfig
    {
        private string _simpleModel="^model_b";
        private string _extendedModel = "^model_e";
        private string _linearModel = "^model_lin";
        private string _polyModel = "^model_poly";
        private string _modelFact="^m_fact";
        private string _argument = "^argument_known";
        private string _rule="^rule";
        private string _fact="^fact";
        private string _constrain="^constraint";
        private string _noConditionInModel="No condition";
        private string _graphic="^graphics";
        private string _advice="^advice";
        private string _sound="^sounds";

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
