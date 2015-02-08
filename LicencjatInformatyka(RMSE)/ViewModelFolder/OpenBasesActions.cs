using System.Collections.Generic;
using System.Windows.Forms;
using LicencjatInformatyka_RMSE_.Bases;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;
using LicencjatInformatyka_RMSE_.OperationsOnBases;
using LicencjatInformatyka_RMSE_.OperationsOnBases.DiagnoseFolder;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

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
                    _gatheredBases.RuleBase.RulesList = new List<Rule>();
                    _gatheredBases.FactBase.FactList = new List<Fact>();
                        //When opening new base previous base must be empty.
                    _viewModel.CurrentRuleBasePath = fileDialog.FileName;
                    _gatheredBases.RuleBase.ReadRules(fileDialog.FileName);
                    _viewModel.ButtonsLogic.RuleBaseOpened = true;
                    _viewModel.ButtonsLogic.ConclusionEnabled = true;
                }

                
                foreach (var factr in _gatheredBases.FactBase.FactList)
                {
               _gatheredBases.OrginalFactBase.FactList.Add(factr);
                }

                //foreach (var factr in _gatheredBases.ArgumentBase.argumentList)
                //{
                //    _gatheredBases.OrginalArgumentBase.argumentList.Add(factr);
                //}

            
        }

        public void ReadConstrainBase()
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();

            if (fileDialog.FileName != "")
            {
                _gatheredBases.ConstrainBase.ConstrainList = new List<Constrain>();
                _gatheredBases.ConstrainBase.ReadConstrains(fileDialog.FileName);
                _viewModel._currentConstrainBasePath = fileDialog.FileName;
                _viewModel.ButtonsLogic.ConstrainBaseOpened = true;
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
                _viewModel._currentModelBasePath = fileDialog.FileName;
                _viewModel.ButtonsLogic.ModelBaseOpened = true;
               
            }
            Contradiction.CheckContradictionWIthModelsAndRulebase(_gatheredBases);
            
        }


        public void ReadAdviceBase()
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();

            if (fileDialog.FileName != "")
            {
                _gatheredBases.AdviceBase.AdviceList = new List<Advice>();
                _gatheredBases.AdviceBase.ReadAdvice(fileDialog.FileName);
                _viewModel._currentAdviceBasePath = fileDialog.FileName;
             //   _viewModel.ButtonsLogic.ModelBaseOpened = true;
            }
         

        }
        public void ReadSoundBase()
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();

            if (fileDialog.FileName != "")
            {
                _gatheredBases.SoundBase.SoundList = new List<Sound>();
                _gatheredBases.SoundBase.ReadSound(fileDialog.FileName);
                _viewModel._currentSoundBasePath = fileDialog.FileName;
             //   _viewModel.ButtonsLogic.ModelBaseOpened = true;
            }
           

        }
        public void ReadGraphicBase()
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();

            if (fileDialog.FileName != "")
            {
                _gatheredBases.GraphicBase.GraphicList = new List<Graphic>();
                _gatheredBases.GraphicBase.ReadGraphic(fileDialog.FileName);
                _viewModel._currentGraphicBasePath = fileDialog.FileName;
               // _viewModel.ButtonsLogic.ModelBaseOpened = true;
            }
          

        }

        public void ReadGraphicFolder()
        {
            var fileDialog = new FolderBrowserDialog();
            fileDialog.ShowDialog();

            if (fileDialog.SelectedPath != "")
            {
                _viewModel._currentGraphicFolderPath = fileDialog.SelectedPath;
            }

        }

        public void ReadSoundFolder()
        {
            var fileDialog = new FolderBrowserDialog();
            fileDialog.ShowDialog();

            if (fileDialog.SelectedPath != "")
            {

                _viewModel._currentSoundFolderPath = fileDialog.SelectedPath;
            }

        }

        public void ReadAdviceFolder()
        {
            var fileDialog = new FolderBrowserDialog();
            fileDialog.ShowDialog();

            if (fileDialog.SelectedPath != "")
            {
                _viewModel._currentAdviceFolderPath = fileDialog.SelectedPath;
            }

        }



       

      

       
    }
}