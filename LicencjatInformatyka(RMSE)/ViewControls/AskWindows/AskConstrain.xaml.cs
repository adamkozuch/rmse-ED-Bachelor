using System.Windows;

namespace LicencjatInformatyka_RMSE_.ViewControls.AskWindows
{
    /// <summary>
    /// Interaction logic for AskConstrain.xaml
    /// </summary>
    public partial class AskConstrain : Window
    {
        public AskConstrain(ViewModel.ViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
