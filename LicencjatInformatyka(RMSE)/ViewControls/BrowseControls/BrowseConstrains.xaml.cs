using System.Windows;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.ViewControls.BrowseControls
{
    /// <summary>
    /// Interaction logic for BrowseConstrains.xaml
    /// </summary>
    public partial class BrowseConstrains : Window
    {
        public BrowseConstrains(ViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
