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

namespace TiketConcert
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                AppData.updateContext();
                AppData.Context.RunAsync().GetAwaiter().GetResult();
            }
            catch
            {
                MessageBox.Show("Ошибка соединения с сервером!" +
                    "\nПожалуйста, запустите сервер заново запустите приложение!",
                    "Ошибка", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
            MaimFrame.Content=new Page.authPage();
        }
    }
}
