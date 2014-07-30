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
using LicencjatInformatyka_RMSE_.NewFolder1;

namespace LicencjatInformatyka_RMSE_
{
    /// <summary>
    /// Interaction logic for AskRuleValue.xaml
    /// </summary>
    public partial class AskRuleValue : Window
    {
        public AskRuleValue(ViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
