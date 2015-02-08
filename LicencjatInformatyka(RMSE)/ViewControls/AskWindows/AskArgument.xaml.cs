using System.ComponentModel;
using System.Windows;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.ViewControls.AskWindows
{
    /// <summary>
    /// Interaction logic for AskArgument.xaml
    /// </summary>
    public partial class AskArgument : Window
    {
      
        public AskArgument( ViewModel model)
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
