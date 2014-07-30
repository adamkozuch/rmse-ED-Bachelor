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

namespace LicencjatInformatyka_RMSE_
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