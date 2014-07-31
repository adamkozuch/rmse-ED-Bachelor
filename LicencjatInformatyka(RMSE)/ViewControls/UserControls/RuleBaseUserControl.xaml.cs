using System.Windows.Controls;
using LicencjatInformatyka_RMSE_.Additional;

namespace LicencjatInformatyka_RMSE_.ViewControls.UserControls
{
	/// <summary>
	/// Interaction logic for RuleBaseUserControl.xaml
	/// </summary>
	public partial class RuleBaseUserControl : UserControl
	{
	    private ILanguageConfig _config;
		public RuleBaseUserControl(ViewModel.ViewModel model)
		{
			this.InitializeComponent();
		    DataContext = model;


		}
	}
}