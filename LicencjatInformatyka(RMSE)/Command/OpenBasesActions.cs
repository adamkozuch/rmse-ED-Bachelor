using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using LicencjatInformatyka_RMSE_.NewFolder1;
using LicencjatInformatyka_RMSE_.NewFolder2;
using LicencjatInformatyka_RMSE_.NewFolder3;
using LicencjatInformatyka_RMSE_.NewFolder4;
using LicencjatInformatyka_RMSE_.OperationsOnBases;
using Microsoft.Win32;

namespace LicencjatInformatyka_RMSE_.Command
{
    internal class OpenBasesActions
    {
        public readonly List<Fact> bazaFaktow = new List<Fact>();
        private ViewModel _viewModel;
        private readonly OperacjeNaDopytywalnych _operacjeNaDopytywalnych;

        public OpenBasesActions(ViewModel viewModel)
        {
            _viewModel = viewModel;
            _operacjeNaDopytywalnych = new OperacjeNaDopytywalnych(this);
        }

        public void OpenRuleBase()
        {
            var loadedRules = new RuleBase();

            var dlg = new OpenFileDialog();
            dlg.ShowDialog();

            if (dlg.FileName != "")
            {
                loadedRules.ReadAndAddRules(dlg.FileName);

              Sprzecznosc.SprzecznoscZewnetrzna(loadedRules.RulesList);


                var tree = TreeOperations.ReturnComplexTreeAndDifferences(loadedRules.RulesList, loadedRules.RulesList[0]);
                var possibleTrees = TreeOperations.ReturnPossibleTrees(tree.Values.First(), tree.Keys.First());

                _operacjeNaDopytywalnych.ZnajdzDopytywalneWarunki(possibleTrees);
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