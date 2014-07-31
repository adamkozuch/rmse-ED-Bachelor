using System.Windows;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.ViewControls.BrowseControls
{
    /// <summary>
    /// Interaction logic for BrowseRules.xaml
    /// </summary>
    public partial class BrowseRules : Window
    {
        public BrowseRules(ViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
