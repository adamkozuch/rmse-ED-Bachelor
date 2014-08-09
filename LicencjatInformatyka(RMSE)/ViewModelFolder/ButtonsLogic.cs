using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LicencjatInformatyka_RMSE_.Annotations;

namespace LicencjatInformatyka_RMSE_.ViewModelFolder
{
    public class ButtonsLogic:INotifyPropertyChanged
    {
        private ViewModel _viewModel;

        public ButtonsLogic(ViewModel viewModel)
        {
            _viewModel = viewModel;

        }

        private bool _ruleBaseOpened;
        private bool _modelBaseOpened;
        private bool _constrainBaseOpened;
        private bool _conclusionEnabled=true; //todo :pamiętać zeby to zmienic


        public bool RuleBaseOpened
        {
            get { return _ruleBaseOpened; }
            set
            {
                _ruleBaseOpened = value;
                OnPropertyChanged("RuleBaseOpened");
            }
        }

         public bool ModelBaseOpened
        {
            get { return _modelBaseOpened; }
            set
            {
                _modelBaseOpened = value;
                OnPropertyChanged("ModelBaseOpened");
            }
        }
         public bool ConstrainBaseOpened
         {
             get { return _constrainBaseOpened; }
             set
             {
                 _constrainBaseOpened = value;
                 OnPropertyChanged("ConstrainBaseOpened");
             }
         }

        public bool ConclusionEnabled
         {
             get { return _conclusionEnabled; }
             set
             {
                 _conclusionEnabled = value;
                 OnPropertyChanged("ConclusionEnabled");
             }
         }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
