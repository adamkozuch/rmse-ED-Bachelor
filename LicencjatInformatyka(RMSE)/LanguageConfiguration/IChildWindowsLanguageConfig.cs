using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LicencjatInformatyka_RMSE_.Additional
{
    public interface IChildWindowsLanguageConfig
    {
        #region AskArgument
        string AskArgumentWindowName { get; }
        string AskArgumentExplainText { get; }
        string AskArgumentBtnProcess { get; }
        string AskArgumentBtnUnknown { get; }
        #endregion
        #region AskConstrain
        string AskConstrainWindowName { get; }
        string AskConstrainProcess { get; }
        string AskConstrainBtnUnknown { get; }
        string AskConstrainExplainText { get; }
         #endregion
        #region AskingConditionsWindow
        string AskConditionsWindowName { get; }
        string AskConditionsExplainText { get; }
        #endregion
        #region AskRuleValue
        string AskRuleValueWindowName { get; }
        string AskRuleValueExplainText { get; }
        string AskRuleValueBtnProcess { get; }
        string AskRuleValueBtnUnknown { get; }


        #endregion
        #region ChooseRule
        string ChooseRuleWindowName { get; }
        string ChooseRuleExplainText { get; }
        string ChooseRuleBtnProcess { get; }
        string ChooseRuleBtnAbort { get; }
        string ChooseRuleNumberOfRule { get; }
        string ChooseRuleConclusionOfRule { get; }

        #endregion
        #region BrowseConstrains
        string BrowseConstrainsWindowName { get; }
        string BrowseConstrainsConstrainNumber { get; }
        string BrowseConstrainsConditionsName { get; }
        string BrowseConstrainsExplainText { get; }
        #endregion 
        #region BrowseModels
        string BrowseModelsWindowName { get; }
        string BrowseModelsConstrainNumber { get; }
        string BrowseModelsConditionsName { get; }
        string BrowseModelsExplainText { get; }
        #endregion
        #region BrowseRules
        string BrowseRulesWindowName { get; }
        string BrowseRulesRuleNumber { get; }
        string BrowseRulesConditionsName { get; }
        string BrowseRulesConclusionName { get; }
        string BrowseRulesExplainText { get; }
        #endregion
        #region Flattern
        string FlatternmainButton { get; }
        string FlatternWindowName { get; }
        string FlatternAllRulesText { get; }
        string FlatternOneRuleText { get; }
        string FlatternButtonText { get; }
        string NotFlattern { get; }
        #endregion






    }
}
