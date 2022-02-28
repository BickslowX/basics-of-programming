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

namespace lab02
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToWin2_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Win2 w2 = new Win2();
        }

        private void ToWin3_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Win3 w3 = new Win3();
        }

        private void ToWin4_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Win4 w4 = new Win4();
        }

        private void ToWin5_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Win5 w5 = new Win5();
        }
    }
}
