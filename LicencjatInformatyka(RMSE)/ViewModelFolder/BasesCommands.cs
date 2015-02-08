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
        public ICommand OpenFlatterWindow { get; set; }
        public ICommand FlatterAllRules { get; set; }



        public ICommand OpenGraphicBaseCommand { get; set; }
        public ICommand OpenAdviceBaseCommand { get; set; }
        public ICommand OpenSoundBaseCommand { get; set; }

        public ICommand OpenGraphicFolderCommand { get; set; }
        public ICommand OpenAdviceFolderCommand { get; set; }
        public ICommand OpenSoundFolderCommand { get; set; }

        private void BasesCommandsMethod()
        {
            #region RuleBaseButtons

            OpenRuleCommand = new RelayCommand(pars => _viewModel._openBasesActions.ReadRuleBase());
            DiagnoseOutsideContradictionCommand = new RelayCommand(pars => _viewModel._actionsOnBase.CheckOutsideContradiction());
            DiagnoseRuleRedundanciesCommand = new RelayCommand(p => _viewModel._actionsOnBase.CheckRedundancyInRules());
            LookRuleCommand = new RelayCommand(p => _viewModel.ShowWindow(new BrowseRules(_viewModel)));
            LookAskingConditionsCommand = new RelayCommand(p =>
            {
                _viewModel._actionsOnBase.FillAskingConditionsTable();
                _viewModel.ShowWindow(new AskingConditionsWIndow(_viewModel));
            });
            DiagnoseOutsideContradictionCommand = new RelayCommand(p => _viewModel._actionsOnBase.ReportAboutOutsideContradiction());
            FlatterRuleCommand = new RelayCommand(p => _viewModel._actionsOnBase.FlatterRule(_viewModel.SelectedRule));
            OpenFlatterWindow = new RelayCommand(p => _viewModel.ShowWindow(new ChoseRuleForFlatter(_viewModel)));
            FlatterAllRules =  new RelayCommand(p=> _viewModel._actionsOnBase.FlatterAllRule());

            #endregion

            #region ConstrainBaseButtons

            OpenConstrainCommand = new RelayCommand(pars => _viewModel._openBasesActions.ReadConstrainBase());
            ContradictionWithConstrainsCommand = new RelayCommand(pars => _viewModel._actionsOnBase.CheckContradictionWithConstrains());
            LookAtBaseConstrainsCommand = new RelayCommand(p => _viewModel.ShowWindow(new BrowseConstrains(_viewModel)));
            RedundancyConstrainCommand = new RelayCommand(p=>_viewModel._actionsOnBase.CheckConstrainsRedundancy());

            #endregion

            #region ModelBaseButtons

            OpenModelCommand = new RelayCommand(pars => _viewModel._openBasesActions.ReadModelBase());
            ContradictionWithModelsCommand =
                new RelayCommand(pars => _viewModel._actionsOnBase.CheckContradictionBetweenModelsAndRulebase());
            LookAtBaseModelCommand = new RelayCommand(p => _viewModel.ShowWindow(new BrowseModels(_viewModel)));

            #endregion


            OpenGraphicBaseCommand = new RelayCommand(pars => _viewModel._openBasesActions.ReadGraphicBase());
            OpenAdviceBaseCommand= new RelayCommand(pars => _viewModel._openBasesActions.ReadAdviceBase());
            OpenSoundBaseCommand = new RelayCommand(pars => _viewModel._openBasesActions.ReadSoundBase());

            OpenGraphicFolderCommand = new RelayCommand(pars => _viewModel._openBasesActions.ReadGraphicFolder());
            OpenAdviceFolderCommand = new RelayCommand(pars => _viewModel._openBasesActions.ReadAdviceFolder());
            OpenSoundFolderCommand = new RelayCommand(pars => _viewModel._openBasesActions.ReadSoundFolder());
               
        }
    }
}