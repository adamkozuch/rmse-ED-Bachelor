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

        
        private string _ruleBaseButton = "Baza reguł";
        private string _openRuleBaseText = "Otwórz bazę reguł";
        private string _editRuleBaseText ="Edytuj bazę reguł";
        private string _lookAtRuleBaseText="Przeglądaj bazę reguł";
        private string _createRuleBaseText="Stwórz bazę reguł";
        private string _diagnoseContradictionRuleBaseText="Diagnozuj bazę reguł";
        private string _diagnoseNadmiarowoscRuleBaseText="Diagnozuj nadmiarowość";


        private string _lookAtAskingConditions="Przegladaj warunki dopytywalne";
        private string _openConstrainBaseText="Otwórz bazę ograniczeń";
        private string _lookAtConstrainBaseText="Przeglądaj bazę ograniczeń";
        private string _editCOnstrainBaseText="Edytuj bazę ograniczeń";
        private string _createConstrainBaseText="Stwórz bazę ograniczeń";
        private string _diagnoseContradictionBetweenRulesAndConstrains= "DIagnozuj sprzeczność łączną bazy reguł i ograniczeń";
        private string _diagnoseNadmiarowosc = "Diagnozuj nadmiarowośc łączną bazy reguł i ograniczeń";
       
        
        private string _modelBaseButton ="Baza modeli";
        private string _openModelBaseText ="Otwórz bazę modeli";
        private string _editModelBaseText = "Edytuj bazę modeli";
        private string _lookAtModelBaseText = "Przeglądaj bazę modeli";
        private string _createModelBaseText = "Stwórz bazę modeli";
        private string _diagnoseContradictionModelBaseText ="Diagnozuj sprzecznośc w  bazę modeli";
        private string _diagnoseRedundancyModelBaseText = "Diagnozuj nadmiarowość w bazie modeli";


        public string DiagnoseNadmiarowoscRuleBaseText
        {
            get { return _diagnoseNadmiarowoscRuleBaseText; }
            private set { _diagnoseNadmiarowoscRuleBaseText = value; }
        }

        public string LookAtAskingConditions
        {
            get { return _lookAtAskingConditions; }
            private set { _lookAtAskingConditions = value; }
        }

        public string ModelBaseButton
        {
            get { return _modelBaseButton; }
        }

        public string OpenModelBaseText
        {
            get { return _openModelBaseText; }
        }

        public string EditModelBaseText
        {
            get { return _editModelBaseText; }
        }

        public string LookAtModelBaseText
        {
            get { return _lookAtModelBaseText; }
        }

        public string CreateModelBaseText
        {
            get { return _createModelBaseText; }
        }

        public string DiagnoseContradictionModelBaseText
        {
            get { return _diagnoseContradictionModelBaseText; }
        }

        public string DiagnoseRedundancyModelBaseText
        {
            get { return _diagnoseRedundancyModelBaseText; }
        }

        public string OpenConstrainBaseText
        {
            get { return _openConstrainBaseText; }
        }

        public string LookAtConstrainBaseText
        {
            get { return _lookAtConstrainBaseText; }
        }

        public string EditCOnstrainBaseText
        {
            get { return _editCOnstrainBaseText; }
        }

        public string CreateConstrainBaseText
        {
            get { return _createConstrainBaseText; }
        }

        public string DiagnoseContradictionBetweenRulesAndConstrains
        {
            get { return _diagnoseContradictionBetweenRulesAndConstrains; }
        }

        public string DiagnoseNadmiarowosc
        {
            get { return _diagnoseNadmiarowosc; }
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

        public string RuleBaseButton
        {
            get { return _ruleBaseButton; }
            private set { _ruleBaseButton = value; }
        }

        public string OpenRuleBaseText
        {
            get { return _openRuleBaseText; }
            private set { _openRuleBaseText = value; }
        }

        public string EditRuleBaseText
        {
            get { return _editRuleBaseText; }
            private set { _editRuleBaseText = value; }
        }

        public string LookAtRuleBaseText
        {
            get { return _lookAtRuleBaseText; }
            private set { _lookAtRuleBaseText = value; }
        }

        public string CreateRuleBaseText
        {
            get { return _createRuleBaseText; }
            private set { _createRuleBaseText = value; }
        }

        public string DiagnoseContradictionRuleBaseText
        {
            get { return _diagnoseContradictionRuleBaseText; }
            private set { _diagnoseContradictionRuleBaseText = value; }
        }
    }
    }

