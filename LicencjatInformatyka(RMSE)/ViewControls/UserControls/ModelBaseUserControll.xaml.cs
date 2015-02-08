using System.Diagnostics;
using System.Windows.Controls;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.ViewControls.UserControls
{
	/// <summary>
	/// Interaction logic for ModelBaseUserControll.xaml
	/// </summary>
	public partial class ModelBaseUserControll : UserControl
	{
	    private ViewModel _view;
		public ModelBaseUserControll(ViewModel model)
		{
			this.InitializeComponent();
		    DataContext = model;
		    _view = model;
		}

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Process.Start("notepad.exe", _view._currentModelBasePath);
        }
	}
}