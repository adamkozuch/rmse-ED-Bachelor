using System.Windows.Input;
using LicencjatInformatyka_RMSE_.ViewControls.AskWindows;
using LicencjatInformatyka_RMSE_.ViewControls.BrowseControls;

namespace LicencjatInformatyka_RMSE_.ViewModelFolder
{
    public class BasesCommands
    {
        private ViewModel _viewModel;

        public BasesCommands(ViewModel viewModel)
        {
            BasesCommandsMethod();
            _viewModel = viewModel;
        }

        public ICommand OpenRuleCommand { get; set; }
        public ICommand DiagnoseOutsideContradictionCommand { get; set; }
        public ICommand LookRuleCommand { get; set; }
        public ICommand EditRuleBaseCommand { get; set; }
        public ICommand LookAskingConditionsCommand { get; set; }
        public ICommand CreateRuleBaseCommand { get; set; }
        public ICommand DiagnoseRuleRedundanciesCommand { get; set; }
        public ICommand FlatterRuleCommand { get; set; }
        public ICommand OpenConstrainCommand { get; set; }
        public ICommand LookAtBaseConstrainsCommand { get; set; }
        public ICommand EditConstrainCommand { get; set; }
        public ICommand CreateConstrainsCommand { get; set; }
        public ICommand RedundancyConstrainCommand { get; set; }
        public ICommand ContradictionWithConstrainsCommand { get; set; }
        public ICommand OpenModelCommand { get; set; }
        public ICommand ContradictionWithModelsCommand { get; set; }
        public ICommand LookAtBaseModelCommand { get; set; }
        public ICommand EditModelCommand { get; set; }
        public ICommand CreateModelCommand { get; set; }
        public ICommand RedundancyModelCommand { get; set; }

        private void BasesCommandsMethod()
        {
            #region RuleBaseButtons

            OpenRuleCommand = new RelayCommand(pars => _viewModel._openBasesActions.ReadRuleBase());
            DiagnoseOutsideContradictionCommand = new RelayCommand(pars => _viewModel._actionsOnBase.CheckOutsideContradiction());
            LookRuleCommand = new RelayCommand(p => _viewModel.ShowWindow(new BrowseRules(_viewModel)));
            LookAskingConditionsCommand = new RelayCommand(p =>
            {
                _viewModel._actionsOnBase.FillAskingConditionsTable();
                _viewModel.ShowWindow(new AskingConditionsWIndow(_viewModel));
            });
            DiagnoseOutsideContradictionCommand = new RelayCommand(p => _viewModel._actionsOnBase.ReportAboutOutsideContradiction());
            FlatterRuleCommand = new RelayCommand(p => _viewModel._actionsOnBase.FlatterRule(_viewModel.SelectedRule));

            #endregion

            #region ConstrainBaseButtons

            OpenConstrainCommand = new RelayCommand(pars => _viewModel._openBasesActions.ReadConstrainBase());
            ContradictionWithConstrainsCommand = new RelayCommand(pars => _viewModel._actionsOnBase.CheckContradictionWithConstrains());
            LookAtBaseConstrainsCommand = new RelayCommand(p => _viewModel.ShowWindow(new BrowseConstrains(_viewModel)));

            #endregion

            #region ModelBaseButtons

            OpenModelCommand = new RelayCommand(pars => _viewModel._openBasesActions.ReadModelBase());
            ContradictionWithModelsCommand =
                new RelayCommand(pars => _viewModel._actionsOnBase.CheckContradictionBetweenModelsAndRulebase());
            LookAtBaseModelCommand = new RelayCommand(p => _viewModel.ShowWindow(new BrowseModels(_viewModel)));

            #endregion
        }
    }
}