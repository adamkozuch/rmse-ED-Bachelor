using System.Windows;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.ViewControls.AskWindows
{
    /// <summary>
    /// Interaction logic for AskingConditionsWIndow.xaml
    /// </summary>
    public partial class AskingConditionsWIndow : Window
    {
        public AskingConditionsWIndow(ViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
