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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TiketConcert.Page
{
    /// <summary>
    /// Логика взаимодействия для registPage.xaml
    /// </summary>
    public partial class registPage
    {
        public registPage()
        {
            InitializeComponent();
        }

        private void PageAuth_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page.authPage());
        }
    }
}
