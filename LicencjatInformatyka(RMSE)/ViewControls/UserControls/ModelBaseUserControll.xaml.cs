using System.Windows.Controls;

namespace LicencjatInformatyka_RMSE_.ViewControls.UserControls
{
	/// <summary>
	/// Interaction logic for ModelBaseUserControll.xaml
	/// </summary>
	public partial class ModelBaseUserControll : UserControl
	{
		public ModelBaseUserControll(ViewModel.ViewModel model)
		{
			this.InitializeComponent();
		    DataContext = model;
		}
	}
}