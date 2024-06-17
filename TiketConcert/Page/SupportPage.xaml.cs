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
using TiketConcert.Class;

namespace TiketConcert.Page
{
    /// <summary>
    /// Логика взаимодействия для SupportPage.xaml
    /// </summary>
    public partial class SupportPage
    {
        public SupportPage()
        {
            InitializeComponent();
            BoxEmail.Text=TempData.Email;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ваше мнение очень важно");
        }


    }
}
