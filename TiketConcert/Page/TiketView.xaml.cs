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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TiketConcert.Class;

namespace TiketConcert.Page
{
    /// <summary>
    /// Логика взаимодействия для TiketView.xaml
    /// </summary>
    public partial class TiketView
    {
        public TiketView()
        {
            InitializeComponent();
        }

        private void TextAccount_Click(object sender, RoutedEventArgs e)
        {
            // Запуск анимации
            //Storyboard storyboard = (Storyboard)this.Resources["ShowAccStoryboard"];
            //storyboard.Begin();
        }
    }
}
