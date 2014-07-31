using System.Windows.Controls;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.ViewControls.UserControls
{
	/// <summary>
	/// Interaction logic for ModelBaseUserControll.xaml
	/// </summary>
	public partial class ModelBaseUserControll : UserControl
	{
		public ModelBaseUserControll(ViewModel model)
		{
			this.InitializeComponent();
		    DataContext = model;
		}
	}
}