using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicencjatInformatyka_RMSE_.Additional
{
   public class PolishChildWindowsLanguageConfig:IChildWindowsLanguageConfig
    {
        private string _askArgumentWindowName="Okno wprowadzania argumentów";
        private string _askArgumentExplainText="Wprowadź wartość dla następującego argumentu";
        private string _askArgumentBtnProcess="Wprowadź";
        private string _askArgumentBtnUnknown="Argument nieznany";
        private string _askConstrainWindowName="Okno wprowadzania wartości ograniczenia";
        private string _askConstrainProcess = "Wprowadź";
        private string _askConstrainBtnUnknown="Wartość nieznana";
        private string _askConstrainExplainText="Wybierz prawdziwy warunek";
        private string _askConditionsWindowName="Okno wartości warunku";
        private string _askConditionsExplainText="Wprowadź wartośc nastepującego warunku";
        private string _askRuleValueWindowName="Okno wartości warunku dopytywalnego";
        private string _askRuleValueExplainText="Wprowadź wartośc warunku dopytywalnego";
        private string _askRuleValueBtnProcess="Wprowadź";
        private string _askRuleValueBtnUnknown="WWartość nieznana";
        private string _chooseRuleWindowName="Wnioskowanie wstecz";
        private string _chooseRuleExplainText="Wybierz regułę dla której chcesz przeprowadzić wnioskowanie";
        private string _chooseRuleBtnProcess="Wnioskuj";
        private string _chooseRuleBtnAbort="Przerwij";
        private string _chooseRuleNumberOfRule="Numer reguły";
        private string _chooseRuleConclusionOfRule="Wniosek reguły";
        private string _browseConstrainsWindowName="Przegląd reguł";
        private string _browseConstrainsConstrainNumber="Numer ograniczenia";
        private string _browseConstrainsConditionsName="Warunki";
        private string _browseConstrainsExplainText="W bazie są następujące ograniczenia";
        private string _browseModelsWindowName="Przegląd modeli";
        private string _browseModelsConstrainNumber="Numer modelu";
        private string _browseModelsConditionsName="";
        private string _browseModelsExplainText="W bazie znajdują się następujące modele";
        private string _browseRulesWindowName="Przegląd reguł";
        private string _browseRulesRuleNumber="Numer reguły";
        private string _browseRulesConditionsName="Warunki reguły";
        private string _browseRulesConclusionName="Wniosek reguły";
        private string _browseRulesExplainText="W bazie znajdują się następujące reguły";

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
    }
}
