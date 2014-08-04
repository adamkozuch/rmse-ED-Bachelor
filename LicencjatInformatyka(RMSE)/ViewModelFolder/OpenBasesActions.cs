using System.Collections.Generic;
using LicencjatInformatyka_RMSE_.Bases;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;
using LicencjatInformatyka_RMSE_.OperationsOnBases;
using LicencjatInformatyka_RMSE_.OperationsOnBases.DiagnoseFolder;
using Microsoft.Win32;

namespace LicencjatInformatyka_RMSE_.ViewModelFolder
{
    public class OpenBasesActions
    {
        
        
        private readonly GatheredBases _gatheredBases ;
        private ViewModel _viewModel;

        public OpenBasesActions(ViewModel viewModel, GatheredBases bases)
        {
            _viewModel = viewModel;
            _gatheredBases = bases;
         
        }

        public void ReadRuleBase()
        {

            var fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();

            if (fileDialog.FileName != "")
            {
                _gatheredBases.RuleBase.RulesList= new List<Rule>();//When opening new base previous base must be empty.
                _gatheredBases.RuleBase.ReadRules(fileDialog.FileName);
            }


        }

        public void ReadConstrainBase()
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();

            if (fileDialog.FileName != "")
            {
                _gatheredBases.ConstrainBase.ConstrainList = new List<Constrain>();
                _gatheredBases.ConstrainBase.ReadConstrains(fileDialog.FileName);
            }
        }

        public void ReadModelBase()
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();

            if (fileDialog.FileName != "")
            {
                _gatheredBases.ModelsBase.ModelList= new List<Model>();
                _gatheredBases.ModelsBase.ReadModels(fileDialog.FileName);
            }
            Contradiction.CheckContradictionWIthModelsAndRulebase(_gatheredBases);
            
        }

       

      

       
    }
}