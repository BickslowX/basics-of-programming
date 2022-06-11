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

namespace znoSystem
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

        private void AbitListButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            AbitListWin AL = new AbitListWin();
            AL.Show();
        }

        private void AbitOnExamButton_Click(object sender, RoutedEventArgs e)
        {
            AbitOnExWin AOEW = new AbitOnExWin();
            Hide();
            AOEW.Show();
        }

        private void ScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            ExScheduleWin ESW = new ExScheduleWin();
            Hide();
            ESW.Show();
        }

        private void ResultsButton_Click(object sender, RoutedEventArgs e)
        {
            ResultsWin rw = new ResultsWin();
            Hide();
            rw.Show();
        }
    }
}
