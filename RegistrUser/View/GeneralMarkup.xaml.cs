﻿using RegistrUserDAL;
using System;
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

namespace RegistrUser.View
{
    /// <summary>
    /// Логика взаимодействия для GeneralMarkup.xaml
    /// </summary>
    public partial class GeneralMarkup : Window
    {
        public GeneralMarkup()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();
        }
    }
}