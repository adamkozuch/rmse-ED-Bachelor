using System.Linq;
using System.Runtime.InteropServices;
using LicencjatInformatyka_RMSE_.Additional;
using LicencjatInformatyka_RMSE_.NewFolder1;
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
            Contradiction.CheckOutsideContradiction(_bases);
        }

        public void CheckContradictionWithConstrains()
        {
            Contradiction.CheckContradictionInConstrains(_bases, _bases.ConstrainBase.ConstrainList);
        }

        public void MetodaWnioskujaca()
        {
                // trzeba znalezc metode dopytujaca
            //_openBasesActions(_openBasesActions.bazaOgraniczen); // dopytanie ogranicze� musi byc na pocz�tku
                // Je�li w sp�aszczonej reule w warunkac dopytywalnych b�d� wiecej jak jeden warunkow z ograniczenia to 
                // mamy sprzeczno��. Musimy sprawdza� wszystkie sp�aszczone opcje po kolei

                var tree = TreeOperations.ReturnComplexTreeAndDifferences(_bases, _bases.RuleBase.RulesList[0]);
                var possibleTrees = TreeOperations.ReturnPossibleTrees(tree.Values.First(), tree.Keys.First());

                conclusion.Conclude(possibleTrees);

            }
        
    }
}