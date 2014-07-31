using System.Windows;

namespace LicencjatInformatyka_RMSE_.ViewControls.AskWindows
{
    /// <summary>
    /// Interaction logic for AskArgument.xaml
    /// </summary>
    public partial class AskArgument : Window
    {
        public AskArgument( ViewModel.ViewModel model)
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
