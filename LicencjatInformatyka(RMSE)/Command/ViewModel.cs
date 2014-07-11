using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using LicencjatInformatyka_RMSE_.NewFolder2;
using LicencjatInformatyka_RMSE_.NewFolder5;

namespace LicencjatInformatyka_RMSE_.NewFolder1
{
    class ViewModel
    {
        private ILanguageConfig _languageConfig;

        public ViewModel()
        {
       //     this._languageConfig = languageConfig;


            _openBasesActions = new OpenBasesActions(this);
            OpenRuleCommand = new RelayCommand(pars => _openBasesActions.OpenRuleBase());
            OpenConstrainCommand = new RelayCommand(pars => _openBasesActions.OpenConstrainBase());
            OpenModelCommand = new RelayCommand(pars => _openBasesActions.OpenModelBase());
          
            


        }
        
        
        #region Field
       
      
        GatheredBases _dataFromAllBases = new GatheredBases();
        private Dictionary<string,bool> dynamicBase = new Dictionary<string, bool>();
        public event PropertyChangedEventHandler PropertyChanged = null;
        public ICommand OpenRuleCommand { get; set; }
        public ICommand OpenConstrainCommand { get; set; }
        public ICommand OpenModelCommand { get; set; }
        public ICommand ConcludeCommand { get; set; }
        public ICommand TextCommand { get; set; }
        private string _text ;
        private readonly OpenBasesActions _openBasesActions;

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
