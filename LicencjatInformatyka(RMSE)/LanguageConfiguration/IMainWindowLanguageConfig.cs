namespace LicencjatInformatyka_RMSE_.Additional
{
   public interface IMainWindowLanguageConfig
   {
       #region FrontMenu
       string Bases { get; }
       string Operations { get; }

       #endregion

       #region RuleBaseButtonsNames
       string RuleBaseButton { get; }
        string OpenRuleBaseText { get; }
        string EditRuleBaseText { get; }
        string LookAtRuleBaseText { get; }
        string CreateRuleBaseText { get; }
        string DiagnoseContradictionRuleBaseText { get; }
        string DiagnoseNadmiarowoscRuleBaseText { get; }
        string LookAtAskingConditions { get; }

       

        #endregion

        #region ModelBaseButtonsNames
        string ModelBaseButton { get; }
        string OpenModelBaseText { get; }
        string EditModelBaseText { get; }
        string LookAtModelBaseText { get; }
        string CreateModelBaseText { get; }
        string DiagnoseContradictionModelBaseText { get; }
        string DiagnoseRedundancyModelBaseText { get; }
        #endregion

        #region   ConstrainBaseButtonsNames
        string ConstrainBaseButton { get; }
        string OpenConstrainBaseText { get; }
        string LookAtConstrainBaseText { get; }
        string EditCOnstrainBaseText { get; }
        string CreateConstrainBaseText { get; }
        string DiagnoseContradictionBetweenRulesAndConstrains  { get; }
        string DiagnoseNadmiarowosc { get; } // TODO:ZMienić nazwę nadmiarowość

        #endregion


    }
}
