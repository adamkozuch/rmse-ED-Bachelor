using System.Collections.Generic;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;

namespace LicencjatInformatyka_RMSE_.Bases
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