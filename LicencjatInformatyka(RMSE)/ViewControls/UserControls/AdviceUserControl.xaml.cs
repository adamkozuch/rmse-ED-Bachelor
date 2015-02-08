﻿using System;
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
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_
{
	/// <summary>
	/// Interaction logic for AdviceUserControl.xaml
	/// </summary>
	public partial class AdviceUserControl : UserControl
	{
		public AdviceUserControl(ViewModel model)
		{
			this.InitializeComponent();
            DataContext = model;
		}
	}
}