using System.Windows;
using System.Windows.Controls;
using LicencjatInformatyka_RMSE_.ViewControls.AskWindows;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.ViewControls.UserControls
{
	/// <summary>
	/// Interaction logic for ConcludeUserControl.xaml
	/// </summary>
	public partial class ConcludeUserControl : UserControl
	{
		public ConcludeUserControl(ViewModel model)
		{
			this.InitializeComponent();
		    DataContext = model;
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChooseRule window = new ChooseRule(this.DataContext as ViewModel);
            window.Show();
        }
	}
}