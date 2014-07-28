using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using LicencjatInformatyka_RMSE_.Additional;
using LicencjatInformatyka_RMSE_.Command;
using LicencjatInformatyka_RMSE_.NewFolder2;
using LicencjatInformatyka_RMSE_.NewFolder5;

namespace LicencjatInformatyka_RMSE_.NewFolder1
{
   public class ViewModel
    {
        private ILanguageConfig _languageConfig;
        private GatheredBases bases;
        public ViewModel()
        {
       //     this._languageConfig = languageConfig;
            bases = new GatheredBases();

            _openBasesActions = new OpenBasesActions(this,bases);
            _actionsOnBase = new ActionsOnBase(bases,this);

            OpenRuleCommand = new RelayCommand(pars => _openBasesActions.ReadRuleBase());
            OpenConstrainCommand = new RelayCommand(pars => _openBasesActions.ReadConstrainBase());
            OpenModelCommand = new RelayCommand(pars => _openBasesActions.ReadModelBase());
            ConcludeCommand = new RelayCommand(pars =>  _actionsOnBase.BackwardConcludeAction(bases.RuleBase.RulesList[0]) );
            OutsideContradictionCommand = new RelayCommand(pars =>_actionsOnBase.CheckOutsideContradiction());
            ContradictionWithConstrainsCommand = new RelayCommand(pars => _actionsOnBase.CheckContradictionWithConstrains());
            OnPropertyChanged("Rules");



        }
        
        
        #region Field
       
      
        GatheredBases _dataFromAllBases = new GatheredBases();
        private Dictionary<string,bool> dynamicBase = new Dictionary<string, bool>();
        public event PropertyChangedEventHandler PropertyChanged = null;
        public ICommand OpenRuleCommand { get; set; }
        public ICommand OpenConstrainCommand { get; set; }
        public ICommand OpenModelCommand { get; set; }
        public ICommand ConcludeCommand { get; set; }
        public ICommand OutsideContradictionCommand { get; set; }
        public ICommand ContradictionWithConstrainsCommand { get; set; }
       
        public ICommand TextCommand { get; set; }
        private string _text ;
        private readonly OpenBasesActions _openBasesActions;
        private readonly ActionsOnBase _actionsOnBase;


        #endregion

        #region Property
        public string Text
        {
            get { return _text; }
            set
            {
               _text = value;
                OnPropertyChanged("Text");
            }
        }

        public List<Rule>Rules
        {
            get { return bases.RuleBase.RulesList; }
            
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
