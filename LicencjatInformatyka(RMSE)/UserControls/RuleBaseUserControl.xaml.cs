using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LicencjatInformatyka_RMSE_.NewFolder1;
using LicencjatInformatyka_RMSE_.NewFolder5;

namespace LicencjatInformatyka_RMSE_
{
	/// <summary>
	/// Interaction logic for RuleBaseUserControl.xaml
	/// </summary>
	public partial class RuleBaseUserControl : UserControl
	{
	    private ILanguageConfig _config;
		public RuleBaseUserControl(ViewModel model)
		{
			this.InitializeComponent();
		    DataContext = model;


		}
	}
}