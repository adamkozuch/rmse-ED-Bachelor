using System.Linq;
using LicencjatInformatyka_RMSE_.NewFolder1;
using LicencjatInformatyka_RMSE_.NewFolder5;
using LicencjatInformatyka_RMSE_.OperationsOnBases;

namespace LicencjatInformatyka_RMSE_.Command
{
    internal class ActionsOnBase
    {
        private ViewModel _viewModel;
        private GatheredBases _bases;

        public ActionsOnBase(GatheredBases bases, ViewModel model)
        {
            _viewModel = model;
            _bases = bases;
        }

        public void CheckOutsideContradiction()
        {
            Contradiction.CheckOutsideContradiction(_bases);
        }

        public void CheckContradictionWithConstrains()
        {
            Contradiction.CheckContradictionInConstrains(_bases, _bases.ConstrainBase.ConstrainList);
        }

        private void MetodaWnioskujaca()
        {
            //    _openBasesActions(_openBasesActions.bazaOgraniczen); // dopytanie ograniczeñ musi byc na pocz¹tku
            //    // Jeœli w sp³aszczonej reule w warunkac dopytywalnych bêd¹ wiecej jak jeden warunkow z ograniczenia to 
            //    // mamy sprzecznoœæ. Musimy sprawdzaæ wszystkie sp³aszczone opcje po kolei

            //    var tree = TreeOperations.ReturnComplexTreeAndDifferences(_bases.RuleBase.RulesList, _bases.RuleBase.RulesList[0]);
            //    var possibleTrees = TreeOperations.ReturnPossibleTrees(tree.Values.First(), tree.Keys.First());

            //    _openBasesActions._operacjeNaDopytywalnych.Conclude(possibleTrees);
            //}
        }
    }
}