namespace LicencjatInformatyka_RMSE_.Additional
{
    class PolishMainWindowLanguageConfig:IMainWindowLanguageConfig
    {


        #region OpenBaseInterfaceCommands
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
        private string _diagnoseRedundancy = "Diagnozuj nadmiarowośc łączną bazy reguł i ograniczeń";
       
        
        private string _modelBaseButton ="Baza modeli";
        private string _openModelBaseText ="Otwórz bazę modeli";
        private string _editModelBaseText = "Edytuj bazę modeli";
        private string _lookAtModelBaseText = "Przeglądaj bazę modeli";
        private string _createModelBaseText = "Stwórz bazę modeli";
        private string _diagnoseContradictionModelBaseText ="Diagnozuj sprzecznośc w  bazę modeli";
        private string _diagnoseRedundancyModelBaseText = "Diagnozuj nadmiarowość w bazie modeli";
        private string _bases="Obsługa baz";
        private string _operations="Obsługa operacji na bazach";
        private string _constrainBaseButton="Baza ograniczeń";


        private string _knowledgeBaseAnalysisName="Analiza bazy wiedzy";
        private string _flatteringChoosenRule="Wybierz regułę do spłaszczenia";
        private string _flatteringAllRules="Spłaszcz wszyystkie reguły";
        private string _chainingName="Wnioskowanie";
        private string _forwardChaining="Wnioskowanie w przód";
        private string _backwardChaining="Wnioskowanie wstecz";
        private string _abstractsAndReports="Opisy i raporty";
        private string _graphicsBaseName="Baza grafiki";
        private string _advicesBaseName="Baza rad";
        private string _soundsBaseName="Baza dźwięków";
        private string _openAdviceBase="Otwórz bazę rad";
        private string _loadFolderWithAdvices="Załaduj pliki rad";
        private string _openGraphicsBase="Otwórz bazę grafiki";
        private string _loadFolderWithGraphics="Załaduj folder grafiki";
        private string _openSoundBase="Otwórz bazę dźwięków";
        private string _loadFolderWithSounds="Załaduj folder dźwięków";
        private string _languageVersion = "Wersja językowa";
        private string _versionPolish ="Polska";
        private string _versionEnglish="Angielska";
        private string _mainWindowName="regułowo- modelowy system ekspertowy Elementarnie Dokładny";
        private string _consoleName="Konsola";
        private string _cleanConsole="Wyczyść konsole";

        #endregion

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

        public string ConstrainBaseButton
        {
            get { return _constrainBaseButton; }
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

        public string DiagnoseRedundancy
        {
            get { return _diagnoseRedundancy; }
        }

        public string KnowledgeBaseAnalysisName
        {
            get { return _knowledgeBaseAnalysisName; }
        }

        public string FlatteringChoosenRule
        {
            get { return _flatteringChoosenRule; }
        }

        public string FlatteringAllRules
        {
            get { return _flatteringAllRules; }
        }

        public string ChainingName
        {
            get { return _chainingName; }
        }

        public string ForwardChaining
        {
            get { return _forwardChaining; }
        }

        public string BackwardChaining
        {
            get { return _backwardChaining; }
        }

        public string AbstractsAndReports
        {
            get { return _abstractsAndReports; }
        }

        public string GraphicsBaseName
        {
            get { return _graphicsBaseName; }
        }

        public string AdvicesBaseName
        {
            get { return _advicesBaseName; }
        }

        public string SoundsBaseName
        {
            get { return _soundsBaseName; }
        }

        public string OpenAdviceBase
        {
            get { return _openAdviceBase; }
        }

        public string LoadFolderWithAdvices
        {
            get { return _loadFolderWithAdvices; }
        }

        public string OpenGraphicsBase
        {
            get { return _openGraphicsBase; }
        }

        public string LoadFolderWithGraphics
        {
            get { return _loadFolderWithGraphics; }
        }

        public string OpenSoundBase
        {
            get { return _openSoundBase; }
        }

        public string LoadFolderWithSounds
        {
            get { return _loadFolderWithSounds; }
        }

        public string LanguageVersion
        {
            get { return _languageVersion; }
        }

        public string VersionPolish
        {
            get { return _versionPolish; }
        }

        public string VersionEnglish
        {
            get { return _versionEnglish; }
        }

        public string MainWindowName
        {
            get { return _mainWindowName; }
        }

        public string ConsoleName
        {
            get { return _consoleName; }
        }

        public string CleanConsole
        {
            get { return _cleanConsole; }
        }


        public string Bases
        {
            get { return _bases; }
        }

        public string Operations
        {
            get { return _operations; }
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

