using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicencjatInformatyka_RMSE_.Additional
{
    public interface IElementsNamesLanguageConfig
    {
        string SimpleModel { get; }
        string ExtendedModel { get; }
        string LinearModel { get; }
        string PolyModel { get; }
        string ModelFact { get; }
        string Argument { get; }
        string Rule{ get; }
        string Fact { get; }
        string Constrain { get; }
        string NoConditionInModel { get; }



        string graphic { get; }
        string advice { get; }
        string sound { get; }




    }
}
