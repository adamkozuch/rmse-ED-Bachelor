using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using LicencjatInformatyka_RMSE_.Additional;
using LicencjatInformatyka_RMSE_.Bases;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;
using LicencjatInformatyka_RMSE_.LanguageConfiguration;
using LicencjatInformatyka_RMSE_.ViewControls.AskWindows;
using LicencjatInformatyka_RMSE_.ViewControls.BrowseControls;

namespace LicencjatInformatyka_RMSE_.ViewModelFolder
{
   public class ViewModel:INotifyPropertyChanged
    {
       private IElementsNamesLanguageConfig _elementsNamesLanguageConfig;
        private readonly GatheredBases bases;
       public readonly OpenBasesActions _openBasesActions;
       public readonly ActionsOnBase _actionsOnBase;
                  
        public event PropertyChangedEventHandler PropertyChanged = null;
        public ViewModel()
        {
            

            bases = new GatheredBases(_elementsNamesLanguageConfig);

            //Instances of classes responsible for opening and actions on RMSE bases
            _openBasesActions = new OpenBasesActions(this,bases);
            _actionsOnBase = new ActionsOnBase(bases,this);

            #region ConclusionButtons
          ConcludeCommand = new RelayCommand(pars =>  _actionsOnBase.BackwardConcludeAction(_selectedRule));
          #endregion
           ValueTrue = new RelayCommand(p => CheckedRuleVal=true);
           ValueUnknown = new RelayCommand(p => CheckedRuleVal=false);
           #region LanguageConfiguration

            MainWindowLanguageConfig =new PolishMainWindowLanguageConfig();
            ChildWindowsLanguageConfig = new PolishChildWindowsLanguageConfig();
            _elementsNamesLanguageConfig = new PolishElementsNamesLanguageConfig();

            PolishConfigurationCommand = new RelayCommand( p=>
            {
                MainWindowLanguageConfig = new PolishMainWindowLanguageConfig();
                ChildWindowsLanguageConfig = new PolishChildWindowsLanguageConfig();
                _elementsNamesLanguageConfig = new PolishElementsNamesLanguageConfig();
            });

            EnglishConfigurationCommand = new RelayCommand(p =>
            {
                MainWindowLanguageConfig = new EnglishMainWindowLanguageConfig();
                ChildWindowsLanguageConfig = new EnglishChildWindowsLanguageConfig();
                _elementsNamesLanguageConfig = new EnglishElementsLanguageConfig();
            });


            _basesCommands = new BasesCommands(this);

            #endregion
        }


       public void ShowWindow(Window wind)
       {
           wind.Show();
       }

       // These fields are used in process of asking unknown values
        private Rule _selectedRule = new Rule();
        private bool _checkedRuleValue;
        private string _checkedRuleName;
        private Constrain _askedConstrain;
        private string _mainWindowText;

        public ICommand PolishConfigurationCommand { get; set; }
        public ICommand EnglishConfigurationCommand { get; set; }

  
        #region AnotherCommands
        public ICommand ConcludeCommand { get; set; }

        public ICommand ValueTrue { get; set; }
        public ICommand ValueUnknown { get; set; }

       #endregion

        #region Property
        public Rule SelectedRule
        {
            get { return _selectedRule; }
            set
            {
                _selectedRule = value;
                OnPropertyChanged("SelectedRule");
            }
        }

        public bool CheckedRuleVal
        {
            get { return _checkedRuleValue; }
            set
            {
                _checkedRuleValue = value;
                OnPropertyChanged("CheckedRuleVal");
            }
        }

        public string MainWindowText
        {
            get { return _mainWindowText ; }
            set
            {
                _mainWindowText = value;
                OnPropertyChanged("MainWindowText");
            }
        }

        public Constrain AskedConstrain
        {
            get { return _askedConstrain; }
            set
            {
                _askedConstrain = value;
                OnPropertyChanged("AskedConstrain");
            }
        }
           string _valueFromConstrain;
       private string _argumentValue;
       private List<string> _askingConditionsList;
       private IMainWindowLanguageConfig _mainWindowLanguageConfig;
       private IChildWindowsLanguageConfig _childWindowsLanguageConfig;
       private readonly BasesCommands _basesCommands;

       public string ValueFromConstrain
        {
            get
            {  
                return _valueFromConstrain;
            }
            set
            {
                _valueFromConstrain = value;
                OnPropertyChanged("ValueFromConstrain");
            }
        }

       public List<string> AskingConditionsList
       {
           get
           {
               return _askingConditionsList;
           }
           set
           {
               _askingConditionsList = value;
               OnPropertyChanged("AskingConditionsList");
           }
       }
        public string ValueArgument
        {
            get
            {
                return _argumentValue;
            }
            set
            {
                _argumentValue = value;
                OnPropertyChanged("ValueArgument");
            }
        }

        public string CheckedRuleName
        {
            get { return _checkedRuleName; }
            set
            {
                _checkedRuleName = value;
                OnPropertyChanged("CheckedRuleName");
            }
        }

        public List<Rule> RuleListProp
        {
            get { return bases.RuleBase.RulesList; }
         
        }
        public List<Constrain> ConstrainListProp
        {
            get { return bases.ConstrainBase.ConstrainList; }

        }
        public List<Model> ModelListProp
        {
            get { return bases.ModelsBase.ModelList; }

        }


       public IMainWindowLanguageConfig MainWindowLanguageConfig
       {
           get { return _mainWindowLanguageConfig; }
           set
           {
               _mainWindowLanguageConfig = value;
               OnPropertyChanged("MainWindowLanguageConfig");
           }
       }

       public IChildWindowsLanguageConfig ChildWindowsLanguageConfig
       {
           get { return _childWindowsLanguageConfig; }
           set { _childWindowsLanguageConfig = value; }
       }

       public BasesCommands BasesCommandsProperty
       {
           get { return _basesCommands; }
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
