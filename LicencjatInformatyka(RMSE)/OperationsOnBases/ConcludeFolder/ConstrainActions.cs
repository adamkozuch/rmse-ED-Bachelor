using LicencjatInformatyka_RMSE_.Bases;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;
using LicencjatInformatyka_RMSE_.ViewControls.AskWindows;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.OperationsOnBases.ConcludeFolder
{
    public class ConstrainActions
    {
        private ConclusionClass conclusionClass;
        private ViewModel viewModel;
        private GatheredBases bases;
        public ConstrainActions
            (ConclusionClass _conclusionClass, ViewModel _viewModel, GatheredBases _bases)
        {
            _conclusionClass = conclusionClass;
            viewModel = _viewModel;
            bases = _bases;

        }

        public void ConstrainAsk(SimpleTree simpleTree)
        {
            foreach (var constrain in bases.ConstrainBase.ConstrainList)
            {
                foreach (var constrainCondition in constrain.ConstrainConditions)
                {
                    if (constrainCondition == simpleTree.rule.Conclusion)
                    {
                        AskForConstrainValue(constrain);
                    }
                }
            }
        }

        public void AskForConstrainValue(Constrain constrain)
        {
            viewModel.AskedConstrain = constrain;
            var window = new AskConstrain(viewModel);
            window.ShowDialog();

            SetConstrainValue(viewModel.ValueFromConstrain, viewModel.AskedConstrain);

        }

        private void SetConstrainValue(string valueFromConstrain, Constrain askedConstrain)
        {
            if (valueFromConstrain != "")
            {
                foreach (var constrain in askedConstrain.ConstrainConditions)
                {
                    if (constrain == valueFromConstrain)
                        bases.FactBase.FactList.Add(new Fact() {FactName = constrain, FactValue = true});
                    else
                    {
                        bases.FactBase.FactList.Add(new Fact() {FactName = constrain, FactValue = false});
                    }

                }
            }
            viewModel.ValueFromConstrain = "";
        }
    }
}
