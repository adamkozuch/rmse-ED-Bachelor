using System.Collections.Generic;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;

namespace LicencjatInformatyka_RMSE_.Bases
{
    public interface IGatheredBases
    {
       
        RuleBase RuleBase { get; set; }
        ConstrainBase ConstrainBase { get; set; }
        ModelBase ModelsBase { get; set; }
        AdviceBase AdviceBase { get; set; }
        SoundBase SoundBase { get; set; }
        GraphicBase GraphicBase { get; set; } 
    }
}