using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using LicencjatInformatyka_RMSE_.Additional;
using LicencjatInformatyka_RMSE_.Command;
using LicencjatInformatyka_RMSE_.NewFolder2;
using LicencjatInformatyka_RMSE_.NewFolder5;

namespace LicencjatInformatyka_RMSE_.NewFolder1
{
   public class ViewModel:INotifyPropertyChanged
    {
       public ObservableCollection<Rule> _rules = new ObservableCollection<Rule>();
        private ILanguageConfig _languageConfig;
       private GatheredBases bases;
        private readonly OpenBasesActions _openBasesActions;
        private readonly ActionsOnBase _actionsOnBase;
        public event PropertyChangedEventHandler PropertyChanged = null;
       Rule selectedRule = new Rule();
       private bool _checkedRuleValue;
      
        public ViewModel()
        { bases = new GatheredBases();
       //     this._languageConfig = languageConfig;
           
            _openBasesActions = new OpenBasesActions(this,bases);
            _actionsOnBase = new ActionsOnBase(bases,this);
            #region RuleBaseButtons
            OpenRuleCommand = new RelayCommand(pars => _openBasesActions.ReadRuleBase()); 
            OutsideContradictionCommand = new RelayCommand(pars =>_actionsOnBase.CheckOutsideContradiction());
            #endregion
            #region ConstrainBaseButtons
            OpenConstrainCommand = new RelayCommand(pars => _openBasesActions.ReadConstrainBase());
            ContradictionWithConstrainsCommand = new RelayCommand(pars => _actionsOnBase.CheckContradictionWithConstrains()); 
            #endregion
            #region ModelBaseButtons
            OpenModelCommand = new RelayCommand(pars => _openBasesActions.ReadModelBase());
        //    ContradictionWithModelsCommand = new RelayCommand(pars => _actionsOnBase.);
            #endregion

            ConcludeCommand = new RelayCommand(pars =>  _actionsOnBase.BackwardConcludeAction(selectedRule));

            ValueTrue = new RelayCommand(p => CheckedRuleVal=true);
            ValueUnknown = new RelayCommand(p => CheckedRuleVal=false);
          
            
     

            LanguageConfig =new PolishLanguageConfig();
        }



       #region Field


        #region RuleBaseCommands
        public ICommand OpenRuleCommand { get; set; }
        public ICommand OutsideContradictionCommand { get; set; }
        public ICommand LookRuleCommand { get; set; }
        public ICommand EditRuleBaseCommand { get; set; }
        public ICommand LookAskingConditionsCommand { get; set; } //TOdo:Niezaimplemoentowane
        public ICommand CreateRuleBaseCommand { get; set; } //TODO: Niezaimplementowane
        public ICommand DiagnoseRedundanciesCommand { get; set; } //TODO:Niezaimplementowane

        #endregion
        #region ConstrainBaseCommands
        public ICommand OpenConstrainCommand { get; set; }
        public ICommand LookAtBaseConstrainsCommand { get; set; }
        public ICommand EditConstrainCommand { get; set; }
        public ICommand CreateConstrainsCommand { get; set; }
        public ICommand RedundancyConstrainCommand { get; set; }
        public ICommand ContradictionWithConstrainsCommand { get; set; }
        #endregion
        #region ModelBaseCOmmands
        public ICommand OpenModelCommand { get; set; }
        public ICommand ContradictionWithModelsCommand { get; set; }
        public ICommand LookAtBaseModelCommand { get; set; }
        public ICommand EditModelCommand { get; set; }
        public ICommand CreateModelCommand { get; set; }
        public ICommand RedundancyModelCommand { get; set; }


        #endregion
        public ICommand ConcludeCommand { get; set; }

        public ICommand ValueTrue { get; set; }
        public ICommand ValueUnknown { get; set; }

   
        

      

        #endregion

        #region Property
        public Rule SelectedRule
        {
            get { return selectedRule; }
            set
            {
                selectedRule = value;
                OnPropertyChanged("SelectedRule");
            }
        }

        public bool CheckedRuleVal
        {
            get { return _checkedRuleValue; }
            set
            {
                _checkedRuleValue = value;
                OnPropertyChanged("SelectedRule");
            }
        }

        public List<Rule> RuleListProp
        {
            get { return bases.RuleBase.RulesList; }
         
        }



       public ILanguageConfig LanguageConfig
       {
           get { return _languageConfig; }
           set { _languageConfig = value; }
       }

       #endregion


        #region Method

     
      virtual protected void OnPropertyChanged(string propName)
      {
          if (PropertyChanged != null)
              PropertyChanged(this, new PropertyChangedEventArgs(propName));
      }
        #endregion
    }
}
