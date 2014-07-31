using System.Windows;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.ViewControls.AskWindows
{
    /// <summary>
    /// Interaction logic for ChooseRule.xaml
    /// </summary>
    public partial class ChooseRule : Window
    {
        
        public ChooseRule(ViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
