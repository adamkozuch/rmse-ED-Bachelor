using System.Windows;

namespace LicencjatInformatyka_RMSE_.ViewControls.BrowseControls
{
    /// <summary>
    /// Interaction logic for BrowseModels.xaml
    /// </summary>
    public partial class BrowseModels : Window
    {
        public BrowseModels(ViewModel.ViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
