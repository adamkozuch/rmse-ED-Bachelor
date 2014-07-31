using System.Windows;

namespace LicencjatInformatyka_RMSE_.ViewControls.BrowseControls
{
    /// <summary>
    /// Interaction logic for BrowseConstrains.xaml
    /// </summary>
    public partial class BrowseConstrains : Window
    {
        public BrowseConstrains(ViewModel.ViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
