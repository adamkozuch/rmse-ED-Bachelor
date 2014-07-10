namespace LicencjatInformatyka_RMSE_.NewFolder5
{
    class PolishLanguageConfig:ILanguageConfig
    {
        #region

        private string _polyModel = "model_wielomianowy";
        private string _simpleModel = "model";
        private string _extendedModel = "model_r";
        private string _modelFact = "m_fakt";
        private string _argument = "argument_znany";
        private string _linearModel = "model_liniowy";

        #endregion

        string loadRuleBase = "ZaładujBazęReguł";
        
        public string LoadRuleBase
        {
            get { return loadRuleBase; } 

        }

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
            get { return _modelFact ; }
        }

        public string Argument
        {
            get { return _argument; }
        }
    }
    }

