using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LicencjatInformatyka_RMSE_.Additional;
using Xceed.Wpf.DataGrid;

namespace LicencjatInformatyka_RMSE_.LanguageConfiguration
{
    class EnglishMainWindowLanguageConfig:IMainWindowLanguageConfig
    {
        private string _ruleBaseButton="Rule base";
        private string _openRuleBaseText="Open rule base";
        private string _editRuleBaseText="Edit rule base";
        private string _lookAtRuleBaseText="Browse rule base";
        private string _createRuleBaseText="Create rule base";
        private string _diagnoseContradictionRuleBaseText="Diagnose contradiction between rules";
        private string _diagnoseNadmiarowoscRuleBaseText="Diagnose redundancy";
        private string _lookAtAskingConditions="Browse asking conditions";
        private string _modelBaseButton="Model base";
        private string _openModelBaseText="Open model base";
        private string _editModelBaseText="Edit model base";
        private string _lookAtModelBaseText="Browse rule base";
        private string _createModelBaseText="Create rule base";
        private string _diagnoseContradictionModelBaseText="Diagnose contradiction between models and rule base";
        private string _diagnoseRedundancyModelBaseText="Diagnose redumdancy ";
        private string _openConstrainBaseText="Open constrain base";
        private string _lookAtConstrainBaseText="Browse constrain base";
        private string _editCOnstrainBaseText="Edit constrain base";
        private string _createConstrainBaseText="Create constrain base";
        private string _diagnoseContradictionBetweenRulesAndConstrains="Diagnose contradiction between rules and constrains";
        private string _diagnoseRedundancy = "Diagnose redundancy between rules and constrains ";
        private string _bases="Bases";
        private string _operations="Operations on bases";
        private string _constrainBaseButton="Constrains base";
        private string _knowledgeBaseAnalysisName ="Knowledge base analysis";
        private string _flatteringChoosenRule="Flattering a choosen rule";
        private string _flatteringAllRules="Flattering all rules";
        private string _chainingName="Chaining";
        private string _forwardChaining="Forward chaining";
        private string _backwardChaining="Backward chaining";
        private string _abstractsAndReports="Abstracts and report";
        private string _graphicsBaseName="Grapics base";
        private string _advicesBaseName="Advices base";
        private string _soundsBaseName="Sounds base";
        private string _openAdviceBase="Open advice base";
        private string _loadFolderWithAdvices="Folder with advices";
        private string _openGraphicsBase="Open graphics base";
        private string _loadFolderWithGraphics="Open folder with graphics";
        private string _openSoundBase="Open sound base";
        private string _loadFolderWithSounds="Open folder with sounds";
        private string _languageVersion="Language Version";
        private string _versionPolish="Polish";
        private string _versionEnglish="English";
        private string _mainWindowName="Rule- and Model-Based Expert System Elementary Exact";
        private string _consoleName="Console";
        private string _cleanConsole="Remove console text";


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
        }

        public string OpenRuleBaseText
        {
            get { return _openRuleBaseText; }
        }

        public string EditRuleBaseText
        {
            get { return _editRuleBaseText; }
        }

        public string LookAtRuleBaseText
        {
            get { return _lookAtRuleBaseText; }
        }

        public string CreateRuleBaseText
        {
            get { return _createRuleBaseText; }
        }

        public string DiagnoseContradictionRuleBaseText
        {
            get { return _diagnoseContradictionRuleBaseText; }
        }

        public string DiagnoseNadmiarowoscRuleBaseText
        {
            get { return _diagnoseNadmiarowoscRuleBaseText; }
        }

        public string LookAtAskingConditions
        {
            get { return _lookAtAskingConditions; }
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
    }
}
