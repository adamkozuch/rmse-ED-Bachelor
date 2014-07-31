using System.Windows;

namespace LicencjatInformatyka_RMSE_.ViewControls.AskWindows
{
    /// <summary>
    /// Interaction logic for AskingConditionsWIndow.xaml
    /// </summary>
    public partial class AskingConditionsWIndow : Window
    {
        public AskingConditionsWIndow(ViewModel.ViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
