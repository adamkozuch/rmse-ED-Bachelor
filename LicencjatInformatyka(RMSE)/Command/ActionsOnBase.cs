using System.Linq;
using System.Runtime.InteropServices;
using LicencjatInformatyka_RMSE_.Additional;
using LicencjatInformatyka_RMSE_.NewFolder1;
using LicencjatInformatyka_RMSE_.NewFolder2;
using LicencjatInformatyka_RMSE_.NewFolder5;
using LicencjatInformatyka_RMSE_.OperationsOnBases;

namespace LicencjatInformatyka_RMSE_.Command
{
    internal class ActionsOnBase
    {
        private ViewModel _viewModel;
        private GatheredBases _bases;
        private ConclusionClass conclusion;

        public ActionsOnBase(GatheredBases bases, ViewModel model)
        {
            _viewModel = model;
            _bases = bases;
          conclusion  = new ConclusionClass(_bases);
        }

        public void CheckOutsideContradiction()
        {
            Contradiction.ReportAboutContradictionInRules(_bases);
        }

        public void CheckContradictionWithConstrains()
        {
            Contradiction.CheckContradictionInConstrains(_bases, _bases.ConstrainBase.ConstrainList);
        }

        public void BackwardConcludeAction(Rule rule)
        {
                // trzeba znalezc metode dopytujaca
            //_openBasesActions(_openBasesActions.bazaOgraniczen); // dopytanie ograniczeñ musi byc na pocz¹tku
               
            if (_bases.ConstrainBase.ConstrainList.Count != null)
            {
                
            }

                

                conclusion.BackwardConclude(rule);

            }
        
    }
}