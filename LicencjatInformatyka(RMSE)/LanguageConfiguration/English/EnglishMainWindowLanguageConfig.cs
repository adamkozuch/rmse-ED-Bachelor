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
    }
}
