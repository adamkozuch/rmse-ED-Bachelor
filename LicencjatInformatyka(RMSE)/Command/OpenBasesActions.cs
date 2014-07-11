using System.Linq;
using LicencjatInformatyka_RMSE_.NewFolder3;
using LicencjatInformatyka_RMSE_.NewFolder4;

namespace LicencjatInformatyka_RMSE_.NewFolder1
{
    internal class OpenBasesActions
    {
        private ViewModel _viewModel;

        public OpenBasesActions(ViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void OpenRuleBase()
        {

            RuleBase LoadedRules = new RuleBase();

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();

            if (dlg.FileName != "")
            {

                LoadedRules.ReadAndAddRules(dlg.FileName);
              
                var tree = ConclusionOperations.BuildComplexTree(LoadedRules.RulesList, LoadedRules.RulesList[0]);
                var flatteredTree = ConclusionOperations.TreeToEnumerable(tree).Where(p => p.Dopytywalny);
                string result = "";
                foreach (var simpleTree in flatteredTree)
                {
                    
                    result += simpleTree.rule.Conclusion+ " ";
                }
                int i = 0;
            }

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