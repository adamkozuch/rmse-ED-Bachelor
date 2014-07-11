using System.Collections.Generic;
using LicencjatInformatyka_RMSE_.NewFolder2;

namespace LicencjatInformatyka_RMSE_.NewFolder5
{
    public interface IGatheredBases
    {
        List<Fact> FactsList { get; set; }
        List<Rule> RuleList { get; set; }
        List<Constrain> ConstrainList { get; set; }
        List<Model> ModelsList { get; set; }
        List<Advice> AdvicesList { get; set; }
        List<Sound> SoundsList { get; set; }
        List<Graphic> GraphicsList { get; set; } 
    }
}