using System.Windows;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.ViewControls.BrowseControls
{
    /// <summary>
    /// Interaction logic for BrowseModels.xaml
    /// </summary>
    public partial class BrowseModels : Window
    {
        public BrowseModels(ViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
