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
	    private IMainWindowLanguageConfig _config;
		public RuleBaseUserControl(ViewModel model)
		{
			this.InitializeComponent();
		    DataContext = model;


		}
	}
}