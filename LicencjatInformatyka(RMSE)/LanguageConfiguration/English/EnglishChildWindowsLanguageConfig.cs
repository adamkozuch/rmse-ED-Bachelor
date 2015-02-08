using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LicencjatInformatyka_RMSE_.Additional;

namespace LicencjatInformatyka_RMSE_.LanguageConfiguration
{
    class EnglishChildWindowsLanguageConfig: IChildWindowsLanguageConfig
    {
        private string _askArgumentWindowName ="Value of argument";
        private string _askArgumentExplainText = "Enter value of argument";
        private string _askArgumentBtnProcess="Enter";
        private string _askArgumentBtnUnknown="Unknown";
        private string _askConstrainWindowName="Constrain value";
        private string _askConstrainProcess = "Enter";
        private string _askConstrainBtnUnknown="Unknown";
        private string _askConstrainExplainText="Choose askable condition with true value";
        private string _askConditionsWindowName="Condition value";
        private string _askConditionsExplainText="Enter value of condition";
        private string _askRuleValueWindowName="";
        private string _askRuleValueExplainText;
        private string _askRuleValueBtnProcess;
        private string _askRuleValueBtnUnknown;
        private string _chooseRuleWindowName="Choose rule";
        private string _chooseRuleExplainText="";
        private string _chooseRuleBtnProcess="Choose";
        private string _chooseRuleBtnAbort="Abort";
        private string _chooseRuleNumberOfRule="Rule number";
        private string _chooseRuleConclusionOfRule="Conclusion";
        private string _browseConstrainsWindowName="Browse constrains";
        private string _browseConstrainsConstrainNumber="Number";
        private string _browseConstrainsConditionsName="Conditions";
        private string _browseConstrainsExplainText;
        private string _browseModelsWindowName="Browse models";
        private string _browseModelsConstrainNumber="Number";
        private string _browseModelsConditionsName="Conditions";
        private string _browseModelsExplainText="";
        private string _browseRulesWindowName="Browse rules";
        private string _browseRulesRuleNumber="Number";
        private string _browseRulesConditionsName="Conditions";
        private string _browseRulesConclusionName="Conclusion";
        private string _browseRulesExplainText;
        private string _flatternmainButton="Flatter";
        private string _flatternWindowName="Flattering window";
        private string _flatternAllRulesText="Flatter all";
        private string _flatternOneRuleText="choose rule for flatter";
        private string _flatternButtonText="Flatter";
        private string _notFlattern="Abort";

        public string AskArgumentWindowName
        {
            get { return _askArgumentWindowName; }
        }

        public string AskArgumentExplainText
        {
            get { return _askArgumentExplainText; }
        }

        public string AskArgumentBtnProcess
        {
            get { return _askArgumentBtnProcess; }
        }

        public string AskArgumentBtnUnknown
        {
            get { return _askArgumentBtnUnknown; }
        }

        public string AskConstrainWindowName
        {
            get { return _askConstrainWindowName; }
        }

        public string AskConstrainProcess
        {
            get { return _askConstrainProcess; }
        }

        public string AskConstrainBtnUnknown
        {
            get { return _askConstrainBtnUnknown; }
        }

        public string AskConstrainExplainText
        {
            get { return _askConstrainExplainText; }
        }

        public string AskConditionsWindowName
        {
            get { return _askConditionsWindowName; }
        }

        public string AskConditionsExplainText
        {
            get { return _askConditionsExplainText; }
        }

        public string AskRuleValueWindowName
        {
            get { return _askRuleValueWindowName; }
        }

        public string AskRuleValueExplainText
        {
            get { return _askRuleValueExplainText; }
        }

        public string AskRuleValueBtnProcess
        {
            get { return _askRuleValueBtnProcess; }
        }

        public string AskRuleValueBtnUnknown
        {
            get { return _askRuleValueBtnUnknown; }
        }

        public string ChooseRuleWindowName
        {
            get { return _chooseRuleWindowName; }
        }

        public string ChooseRuleExplainText
        {
            get { return _chooseRuleExplainText; }
        }

        public string ChooseRuleBtnProcess
        {
            get { return _chooseRuleBtnProcess; }
        }

        public string ChooseRuleBtnAbort
        {
            get { return _chooseRuleBtnAbort; }
        }

        public string ChooseRuleNumberOfRule
        {
            get { return _chooseRuleNumberOfRule; }
        }

        public string ChooseRuleConclusionOfRule
        {
            get { return _chooseRuleConclusionOfRule; }
        }

        public string BrowseConstrainsWindowName
        {
            get { return _browseConstrainsWindowName; }
        }

        public string BrowseConstrainsConstrainNumber
        {
            get { return _browseConstrainsConstrainNumber; }
        }

        public string BrowseConstrainsConditionsName
        {
            get { return _browseConstrainsConditionsName; }
        }

        public string BrowseConstrainsExplainText
        {
            get { return _browseConstrainsExplainText; }
        }

        public string BrowseModelsWindowName
        {
            get { return _browseModelsWindowName; }
        }

        public string BrowseModelsConstrainNumber
        {
            get { return _browseModelsConstrainNumber; }
        }

        public string BrowseModelsConditionsName
        {
            get { return _browseModelsConditionsName; }
        }

        public string BrowseModelsExplainText
        {
            get { return _browseModelsExplainText; }
        }

        public string BrowseRulesWindowName
        {
            get { return _browseRulesWindowName; }
        }

        public string BrowseRulesRuleNumber
        {
            get { return _browseRulesRuleNumber; }
        }

        public string BrowseRulesConditionsName
        {
            get { return _browseRulesConditionsName; }
        }

        public string BrowseRulesConclusionName
        {
            get { return _browseRulesConclusionName; }
        }

        public string BrowseRulesExplainText
        {
            get { return _browseRulesExplainText; }
        }

        public string FlatternmainButton
        {
            get { return _flatternmainButton; }
        }

        public string FlatternWindowName
        {
            get { return _flatternWindowName; }
        }

        public string FlatternAllRulesText
        {
            get { return _flatternAllRulesText; }
        }

        public string FlatternOneRuleText
        {
            get { return _flatternOneRuleText; }
        }

        public string FlatternButtonText
        {
            get { return _flatternButtonText; }
        }

        public string NotFlattern
        {
            get { return _notFlattern; }
        }
    }
}
