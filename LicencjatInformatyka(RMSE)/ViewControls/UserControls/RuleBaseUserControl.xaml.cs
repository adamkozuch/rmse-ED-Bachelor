using System.Diagnostics;
using System.Windows.Controls;
using LicencjatInformatyka_RMSE_.Additional;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.ViewControls.UserControls
{
	/// <summary>
	/// Interaction logic for RuleBaseUserControl.xaml
	/// </summary>
	public partial class RuleBaseUserControl : UserControl
	{
	    private string path;
	    private ViewModel o;
	    private IMainWindowLanguageConfig _config;
		public RuleBaseUserControl(ViewModel model)
		{
			this.InitializeComponent();
		    DataContext = model;
		    o = model;


		}

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            Process.Start( o.CurrentRuleBasePath);

        }
	}
}