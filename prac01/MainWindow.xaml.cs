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

namespace prac01
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

        private void StudyModeBtn_Click(object sender, RoutedEventArgs e)
        {
            Study study = new Study();
            Hide();
            study.Show();
        }

        private void ProtectionModeBtn_Click(object sender, RoutedEventArgs e)
        {
            Authentication auth = new Authentication();
            Hide();
            auth.Show();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
