using System.Collections.Generic;
using LicencjatInformatyka_RMSE_.NewFolder2;
using LicencjatInformatyka_RMSE_.NewFolder4;

namespace LicencjatInformatyka_RMSE_.NewFolder5
{
    public interface IGatheredBases
    {
       
        RuleBase RuleBase { get; set; }
        ConstrainBase ConstrainBase { get; set; }
        ModelBase ModelsBase { get; set; }
        List<Advice> AdvicesList { get; set; }
        List<Sound> SoundsList { get; set; }
        List<Graphic> GraphicsList { get; set; } 
    }
}