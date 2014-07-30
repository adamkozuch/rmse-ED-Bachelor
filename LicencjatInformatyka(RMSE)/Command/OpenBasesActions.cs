using System;
using System.Collections.Generic;
using LicencjatInformatyka_RMSE_.Additional;
using LicencjatInformatyka_RMSE_.NewFolder1;
using LicencjatInformatyka_RMSE_.NewFolder2;
using LicencjatInformatyka_RMSE_.NewFolder3;
using LicencjatInformatyka_RMSE_.NewFolder5;
using LicencjatInformatyka_RMSE_.OperationsOnBases;
using Microsoft.Win32;

namespace LicencjatInformatyka_RMSE_.Command
{
    internal class OpenBasesActions
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
                _gatheredBases.RuleBase.ReadRules(fileDialog.FileName);
            }


        }

        public void ReadConstrainBase()
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();

            if (fileDialog.FileName != "")
            {
                _gatheredBases.ConstrainBase.ReadConstrains(fileDialog.FileName);
            }
        }

        public void ReadModelBase()
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();

            if (fileDialog.FileName != "")
            {
                _gatheredBases.ModelsBase.ReadModels(fileDialog.FileName);
            }
            Contradiction.CheckContradictionWIthModelsAndRulebase(_gatheredBases);
        }

       

        private void AskForConstrainValue(List<Constrain> list)
        {
            foreach (Constrain constrain in list)
            {
                string trueConstrain = FillTrueConstrain(constrain);
                _gatheredBases.FactBase.FactList.AddRange(ConclusionOperations.LoadConstrainAndReturnFactList(constrain, trueConstrain));
            }
        }

        private string FillTrueConstrain(Constrain constrain)
        {
            throw new NotImplementedException();  // mechanizm w UI
        }
    }
}