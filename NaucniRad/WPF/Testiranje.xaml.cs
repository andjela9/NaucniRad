﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NaucniRad.WPF
{
    /// <summary>
    /// Interaction logic for Testiranje.xaml
    /// </summary>
    public partial class Testiranje : Window
    {
        public Testiranje(string s)
        {
            InitializeComponent();
            Test.Text = s;
        }
    }
}
