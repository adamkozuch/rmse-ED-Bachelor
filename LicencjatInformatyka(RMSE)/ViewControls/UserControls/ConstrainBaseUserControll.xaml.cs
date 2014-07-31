using System.Windows.Controls;

namespace LicencjatInformatyka_RMSE_.ViewControls.UserControls
{
	/// <summary>
	/// Interaction logic for ConstrainBaseUserControll.xaml
	/// </summary>
	public partial class ConstrainBaseUserControll : UserControl
	{
		public ConstrainBaseUserControll(ViewModel.ViewModel model)
		{
			this.InitializeComponent();
		    DataContext = model;
		}
	}
}