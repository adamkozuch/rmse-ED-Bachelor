using System.Windows.Controls;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.ViewControls.UserControls
{
	/// <summary>
	/// Interaction logic for ConstrainBaseUserControll.xaml
	/// </summary>
	public partial class ConstrainBaseUserControll : UserControl
	{
		public ConstrainBaseUserControll(ViewModel model)
		{
			this.InitializeComponent();
		    DataContext = model;
		}
	}
}