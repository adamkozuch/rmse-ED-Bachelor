using System.Windows.Controls;

namespace LicencjatInformatyka_RMSE_.ViewControls.UserControls
{
	/// <summary>
	/// Interaction logic for GraphicBaseUserControll.xaml
	/// </summary>
	public partial class GraphicBaseUserControll : UserControl
	{
		public GraphicBaseUserControll(ViewModel.ViewModel model)
		{
			this.InitializeComponent();
		    DataContext = model;
		}
	}
}