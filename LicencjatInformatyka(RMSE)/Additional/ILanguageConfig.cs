namespace LicencjatInformatyka_RMSE_.NewFolder5
{
   public interface ILanguageConfig
    {

        #region nameOfModels
        string SimpleModel { get; }
        string ExtendedModel { get; }
        string LinearModel { get; }
        string PolyModel { get; }
        string ModelFact{ get; }
        string Argument{ get; }




        #endregion



        string LoadRuleBase { get;}
    }
}
