using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.ViewControls.AskWindows
{
    /// <summary>
    /// Interaction logic for ChoseRuleForFlatter.xaml
    /// </summary>
    public partial class ChoseRuleForFlatter : Window
    {
        public ChoseRuleForFlatter(ViewModel model)
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
