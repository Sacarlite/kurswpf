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
using wpfTry.Viev.Interface;
using wpfTry.VievModel.Interface;

namespace wpfTry.Viev
{
    /// <summary>
    /// Логика взаимодействия для ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window, IWindow
    {
        public ProductWindow()
        {
            InitializeComponent();
            Loaded += ProductViev_Loaded;
        }
        private void ProductViev_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICloseWindow viewModel)
            {
                viewModel.close +=
                    () => { this.Close(); };

                Closing += (s, e) => { e.Cancel = !viewModel.CanClose(); };
            }
        }

    }
}
