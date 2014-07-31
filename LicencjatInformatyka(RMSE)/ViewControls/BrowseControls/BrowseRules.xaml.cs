using System.Windows;

namespace LicencjatInformatyka_RMSE_.ViewControls.BrowseControls
{
    /// <summary>
    /// Interaction logic for BrowseRules.xaml
    /// </summary>
    public partial class BrowseRules : Window
    {
        public BrowseRules(ViewModel.ViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
