using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LicencjatInformatyka_RMSE_.NewFolder5;

namespace LicencjatInformatyka_RMSE_.Additional
{
    class EnglishLanguageConfig:ILanguageConfig
    {
        #region

        private string _polyModel = "model_wielomianowy";
        private string _simpleModel = "model";
        private string _extendedModel = "model_r";
        private string _modelFact = "m_fakt";
        private string _argument = "argument_znany";
        private string _linearModel = "model_liniowy";

        #endregion


        private string _ruleBaseButton = "Rule base";
        private string _openRuleBaseText = "Open rule base";
        private string _editRuleBaseText = "Edit rule base";
        private string _lookAtRuleBaseText = "Przeglądaj bazę reguł";
        private string _createRuleBaseText = "Create rule base";
        private string _diagnoseContradictionRuleBaseText = "Diagnose contradictions in rule base ";
        private string _diagnoseNadmiarowoscRuleBaseText = "DIagnose nadmiarowość";
        private string _lookAtAskingConditions = "Browse asking conditions";
        private string _openConstrainBaseText="Open constrain base";
        private string _lookAtConstrainBaseText="Browse constrain base";
        private string _editCOnstrainBaseText="Edit constrain base";
        private string _createConstrainBaseText="Create constrain base";
        private string _diagnoseContradictionBetweenRulesAndConstrains="Diagnose Contradiction Between Rules And Constrains";
        private string _diagnoseRedundancy="Diagnose redundancy";
        private string _modelBaseButton="";
        private string _openModelBaseText;
        private string _editModelBaseText;
        private string _lookAtModelBaseText;
        private string _createModelBaseText;
        private string _diagnoseContradictionModelBaseText;
        private string _diagnoseRedundancyModelBaseText;

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
            private set { _openConstrainBaseText = value; }
        }

        public string LookAtConstrainBaseText
        {
            get { return _lookAtConstrainBaseText; }
            private set { _lookAtConstrainBaseText = value; }
        }

        public string EditCOnstrainBaseText
        {
            get { return _editCOnstrainBaseText; }
            private set { _editCOnstrainBaseText = value; }
        }

        public string CreateConstrainBaseText
        {
            get { return _createConstrainBaseText; }
            private set { _createConstrainBaseText = value; }
        }

        public string DiagnoseContradictionBetweenRulesAndConstrains
        {
            get { return _diagnoseContradictionBetweenRulesAndConstrains; }
            private set { _diagnoseContradictionBetweenRulesAndConstrains = value; }
        }

        public string DiagnoseNadmiarowosc
        {
            get { return _diagnoseNadmiarowosc; }
            private set { _diagnoseNadmiarowosc = value; }
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
            get { return _modelFact; }
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
