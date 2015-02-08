using System.Windows.Controls;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.ViewControls.UserControls
{
	/// <summary>
	/// Interaction logic for GraphicBaseUserControll.xaml
	/// </summary>
	public partial class GraphicBaseUserControll : UserControl
	{
		public GraphicBaseUserControll(ViewModel model)
		{
			this.InitializeComponent();
		    DataContext = model;
		}
	}
}