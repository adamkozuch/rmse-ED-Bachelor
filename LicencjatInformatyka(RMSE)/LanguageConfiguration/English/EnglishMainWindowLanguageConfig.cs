using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LicencjatInformatyka_RMSE_.Additional;

namespace LicencjatInformatyka_RMSE_.LanguageConfiguration
{
    class EnglishMainWindowLanguageConfig:IMainWindowLanguageConfig
    {
        private string _ruleBaseButton;
        private string _openRuleBaseText;
        private string _editRuleBaseText;
        private string _lookAtRuleBaseText;
        private string _createRuleBaseText;
        private string _diagnoseContradictionRuleBaseText;
        private string _diagnoseNadmiarowoscRuleBaseText;
        private string _lookAtAskingConditions;
        private string _modelBaseButton;
        private string _openModelBaseText;
        private string _editModelBaseText;
        private string _lookAtModelBaseText;
        private string _createModelBaseText;
        private string _diagnoseContradictionModelBaseText;
        private string _diagnoseRedundancyModelBaseText;
        private string _openConstrainBaseText;
        private string _lookAtConstrainBaseText;
        private string _editCOnstrainBaseText;
        private string _createConstrainBaseText;
        private string _diagnoseContradictionBetweenRulesAndConstrains;
        private string _diagnoseNadmiarowosc;

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
    }
}
