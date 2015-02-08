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
        string DiagnoseRedundancy { get; } 

        #endregion

       #region FlatternAndConclusion

        string KnowledgeBaseAnalysisName { get; }
        string FlatteringChoosenRule { get; }
        string FlatteringAllRules { get; }

        string ChainingName { get; }
        string ForwardChaining { get; }
        string BackwardChaining { get; }

        string AbstractsAndReports { get; }
        

       #endregion


       #region 
        string GraphicsBaseName { get; }
        string AdvicesBaseName { get; }
        string SoundsBaseName { get; }

        string OpenAdviceBase { get; }
        string LoadFolderWithAdvices { get; }
        string OpenGraphicsBase { get; }
        string LoadFolderWithGraphics { get; }
        string OpenSoundBase { get; }
        string LoadFolderWithSounds { get; }
       #endregion


        string LanguageVersion { get; }
        string VersionPolish { get; }
        string VersionEnglish { get; }
        string MainWindowName { get; }

        string ConsoleName { get; }
        string CleanConsole { get; }
       


   }
}
