using LicencjatInformatyka_RMSE_.NewFolder4;

namespace LicencjatInformatyka_RMSE_.NewFolder1
{
    class OpenBasesActions
    {
        private ViewModel _viewModel;

        public OpenBasesActions(ViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void  OpenRuleBase()
        {
           
            RuleBase LoadedRules = new RuleBase();
            
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();
            
            if (dlg.FileName != "")
            {  
              
                LoadedRules.ReadAndAddRules(dlg.FileName);

                //ConclusionOperations.CheckTypeOfRule(LoadedRules.RulesList);
           
            }

         

            //foreach (var VARIABLE in mk.RuleList)
            //{
            //    ConclusionOperations.Sp³aszczenie(VARIABLE, mk.RuleList,str1);
            //    string s = wypisz(VARIABLE, str1);
            //    nowy += s;
            //   str1.Clear();
            //}
            //Text = nowy;
            //OnPropertyChanged("Text");
       
        
        }

        public void OpenConstrainBase()
        {   
          
            //ConstrainBase LoadedConstrains = new ConstrainBase();
         
            //Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            //dlg.ShowDialog();
            //if (dlg.FileName != "")
            //{
            //    LoadedConstrains.ReadConstrains(dlg.FileName);
            //    _viewModel.mk.ConstrainList = LoadedConstrains.LimitList;
              
            //}
        }

        public void OpenModelBase()
        {
            //ModelBase LoadedModels = new ModelBase();

            //Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            //dlg.ShowDialog();
            //if (dlg.FileName != "")
            //{
            //    LoadedModels.ReadModels(dlg.FileName);
            //    _viewModel.mk.ModeList = LoadedModels.ModelList;
            //}

 
        }
    }
}