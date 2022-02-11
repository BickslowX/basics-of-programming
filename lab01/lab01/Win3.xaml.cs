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

namespace lab01
{
    /// <summary>
    /// Логика взаимодействия для Win3.xaml
    /// </summary>
    public partial class Win3 : Window
    {
        static  bool d = false;
        public Win3()
        {
            InitializeComponent();
        }
        private void Back3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }
        private void reload()
        {
            Win3 ww3 = new Win3();
            Hide();
            ww3.Show();
        }
        private void comp_move()
        {
            bool flag = false;
            Random r = new Random();
            while(flag == false)
            {
                int num = r.Next(0,25);
                int counter = 0;
                foreach (Button b in TicTac.Children.OfType<Button>())
                {
                    if (counter == num && (string)b.Content == "▢")
                    {
                        b.Content = "⭕";
                        b.IsEnabled = false;
                        flag = true;
                        return;
                    }
                    counter++;
                }
            }
            win_check();
        }
        private void win_check()
        {
            //
            if(((string)f00.Content== "❎"&& (string)f01.Content == "❎" && (string)f02.Content == "❎" && (string)f03.Content == "❎")|| ((string)f01.Content == "❎" && (string)f02.Content == "❎" && (string)f03.Content == "❎" && (string)f04.Content == "❎"))
            {
                MessageBox.Show("Вы победили!");
                d = true;
                reload();
            }
            if (((string)f10.Content == "❎" && (string)f11.Content == "❎" && (string)f12.Content == "❎" && (string)f13.Content == "❎") || ((string)f11.Content == "❎" && (string)f12.Content == "❎" && (string)f13.Content == "❎" && (string)f14.Content == "❎"))
            {
                MessageBox.Show("Вы победили!");
                d = true;
                reload();
            }
            if (((string)f20.Content == "❎" && (string)f21.Content == "❎" && (string)f22.Content == "❎" && (string)f23.Content == "❎") || ((string)f21.Content == "❎" && (string)f22.Content == "❎" && (string)f23.Content == "❎" && (string)f24.Content == "❎"))
            {
                MessageBox.Show("Вы победили!");
                d = true;
                reload();
            }
            if (((string)f30.Content == "❎" && (string)f31.Content == "❎" && (string)f32.Content == "❎" && (string)f33.Content == "❎") || ((string)f31.Content == "❎" && (string)f32.Content == "❎" && (string)f33.Content == "❎" && (string)f34.Content == "❎"))
            {
                MessageBox.Show("Вы победили!");
                d = true;
                reload();
            }
            if (((string)f40.Content == "❎" && (string)f41.Content == "❎" && (string)f42.Content == "❎" && (string)f43.Content == "❎") || ((string)f41.Content == "❎" && (string)f42.Content == "❎" && (string)f43.Content == "❎" && (string)f44.Content == "❎"))
            {
                MessageBox.Show("Вы победили!");
                d = true;
                reload();
            }
            if (((string)f00.Content == "❎" && (string)f10.Content == "❎" && (string)f20.Content == "❎" && (string)f30.Content == "❎") || ((string)f10.Content == "❎" && (string)f20.Content == "❎" && (string)f30.Content == "❎" && (string)f40.Content == "❎"))
            {
                MessageBox.Show("Вы победили!");
                d = true;
                reload();
            }
            if (((string)f01.Content == "❎" && (string)f11.Content == "❎" && (string)f21.Content == "❎" && (string)f31.Content == "❎") || ((string)f11.Content == "❎" && (string)f21.Content == "❎" && (string)f31.Content == "❎" && (string)f41.Content == "❎"))
            {
                MessageBox.Show("Вы победили!");
                d = true;
                reload();
            }
            if (((string)f02.Content == "❎" && (string)f12.Content == "❎" && (string)f22.Content == "❎" && (string)f32.Content == "❎") || ((string)f12.Content == "❎" && (string)f22.Content == "❎" && (string)f32.Content == "❎" && (string)f42.Content == "❎"))
            {
                MessageBox.Show("Вы победили!");
                d = true;
                reload();
            }
            if (((string)f03.Content == "❎" && (string)f13.Content == "❎" && (string)f23.Content == "❎" && (string)f33.Content == "❎") || ((string)f13.Content == "❎" && (string)f23.Content == "❎" && (string)f33.Content == "❎" && (string)f43.Content == "❎"))
            {
                MessageBox.Show("Вы победили!");
                d = true;
                reload();
            }
            if (((string)f04.Content == "❎" && (string)f14.Content == "❎" && (string)f24.Content == "❎" && (string)f34.Content == "❎") || ((string)f14.Content == "❎" && (string)f24.Content == "❎" && (string)f34.Content == "❎" && (string)f44.Content == "❎"))
            {
                MessageBox.Show("Вы победили!");
                d = true;
                reload();
            }
            if (((string)f00.Content == "❎" && (string)f11.Content == "❎" && (string)f22.Content == "❎" && (string)f33.Content == "❎") || ((string)f11.Content == "❎" && (string)f22.Content == "❎" && (string)f33.Content == "❎" && (string)f44.Content == "❎"))
            {
                MessageBox.Show("Вы победили!");
                d = true;
                reload();
            }
            if (((string)f40.Content == "❎" && (string)f31.Content == "❎" && (string)f22.Content == "❎" && (string)f13.Content == "❎") || ((string)f31.Content == "❎" && (string)f22.Content == "❎" && (string)f13.Content == "❎" && (string)f04.Content == "❎"))
            {
                MessageBox.Show("Вы победили!");
                d = true;
                reload();
            }
            if ((string)f01.Content == "❎" && (string)f12.Content == "❎" && (string)f23.Content == "❎" && (string)f34.Content == "❎")
            {
                MessageBox.Show("Вы победили!");
                d = true;
                reload();
            }
            if ((string)f10.Content == "❎" && (string)f21.Content == "❎" && (string)f32.Content == "❎" && (string)f43.Content == "❎")
            {
                MessageBox.Show("Вы победили!");
                d = true;
                reload();
            }
            if ((string)f03.Content == "❎" && (string)f12.Content == "❎" && (string)f21.Content == "❎" && (string)f30.Content == "❎")
            {
                MessageBox.Show("Вы победили!");
                d = true;
                reload();
            }
            if ((string)f14.Content == "❎" && (string)f23.Content == "❎" && (string)f32.Content == "❎" && (string)f41.Content == "❎")
            {
                MessageBox.Show("Вы победили!");
                d = true;
                reload();
            }
            //
            if (((string)f00.Content == "⭕" && (string)f01.Content == "⭕" && (string)f02.Content == "⭕" && (string)f03.Content == "⭕") || ((string)f01.Content == "⭕" && (string)f02.Content == "⭕" && (string)f03.Content == "⭕" && (string)f04.Content == "⭕"))
            {
                MessageBox.Show("Вы проиграли!");
                reload();
            }
            if (((string)f10.Content == "⭕" && (string)f11.Content == "⭕" && (string)f12.Content == "⭕" && (string)f13.Content == "⭕") || ((string)f11.Content == "⭕" && (string)f12.Content == "⭕" && (string)f13.Content == "⭕" && (string)f14.Content == "⭕"))
            {
                MessageBox.Show("Вы проиграли!");
                reload();
            }
            if (((string)f20.Content == "⭕" && (string)f21.Content == "⭕" && (string)f22.Content == "⭕" && (string)f23.Content == "⭕") || ((string)f21.Content == "⭕" && (string)f22.Content == "⭕" && (string)f23.Content == "⭕" && (string)f24.Content == "⭕"))
            {
                MessageBox.Show("Вы проиграли!");
                reload();
            }
            if (((string)f30.Content == "⭕" && (string)f31.Content == "⭕" && (string)f32.Content == "⭕" && (string)f33.Content == "⭕") || ((string)f31.Content == "⭕" && (string)f32.Content == "⭕" && (string)f33.Content == "⭕" && (string)f34.Content == "⭕"))
            {
                MessageBox.Show("Вы проиграли!");
                reload();
            }
            if (((string)f40.Content == "⭕" && (string)f41.Content == "⭕" && (string)f42.Content == "⭕" && (string)f43.Content == "⭕") || ((string)f41.Content == "⭕" && (string)f42.Content == "⭕" && (string)f43.Content == "⭕" && (string)f44.Content == "⭕"))
            {
                MessageBox.Show("Вы проиграли!");
                reload();
            }
            if (((string)f00.Content == "⭕" && (string)f10.Content == "⭕" && (string)f20.Content == "⭕" && (string)f30.Content == "⭕") || ((string)f10.Content == "⭕" && (string)f20.Content == "⭕" && (string)f30.Content == "⭕" && (string)f40.Content == "⭕"))
            {
                MessageBox.Show("Вы проиграли!");
                reload();
            }
            if (((string)f01.Content == "⭕" && (string)f11.Content == "⭕" && (string)f21.Content == "⭕" && (string)f31.Content == "⭕") || ((string)f11.Content == "⭕" && (string)f21.Content == "⭕" && (string)f31.Content == "⭕" && (string)f41.Content == "⭕"))
            {
                MessageBox.Show("Вы проиграли!");
                reload();
            }
            if (((string)f02.Content == "⭕" && (string)f12.Content == "⭕" && (string)f22.Content == "⭕" && (string)f32.Content == "⭕") || ((string)f12.Content == "⭕" && (string)f22.Content == "⭕" && (string)f32.Content == "⭕" && (string)f42.Content == "⭕"))
            {
                MessageBox.Show("Вы проиграли!");
                reload();
            }
            if (((string)f03.Content == "⭕" && (string)f13.Content == "⭕" && (string)f23.Content == "⭕" && (string)f33.Content == "⭕") || ((string)f13.Content == "⭕" && (string)f23.Content == "⭕" && (string)f33.Content == "⭕" && (string)f43.Content == "⭕"))
            {
                MessageBox.Show("Вы проиграли!");
                reload();
            }
            if (((string)f04.Content == "⭕" && (string)f14.Content == "⭕" && (string)f24.Content == "⭕" && (string)f34.Content == "⭕") || ((string)f14.Content == "⭕" && (string)f24.Content == "⭕" && (string)f34.Content == "⭕" && (string)f44.Content == "⭕"))
            {
                MessageBox.Show("Вы проиграли!");
                reload();
            }
            if (((string)f00.Content == "⭕" && (string)f11.Content == "⭕" && (string)f22.Content == "⭕" && (string)f33.Content == "⭕") || ((string)f11.Content == "⭕" && (string)f22.Content == "⭕" && (string)f33.Content == "⭕" && (string)f44.Content == "⭕"))
            {
                MessageBox.Show("Вы проиграли!");
                reload();
            }
            if (((string)f40.Content == "⭕" && (string)f31.Content == "⭕" && (string)f22.Content == "⭕" && (string)f13.Content == "⭕") || ((string)f31.Content == "⭕" && (string)f22.Content == "⭕" && (string)f13.Content == "⭕" && (string)f04.Content == "⭕"))
            {
                MessageBox.Show("Вы проиграли!");
                reload();
            }
            if ((string)f01.Content == "⭕" && (string)f12.Content == "⭕" && (string)f23.Content == "⭕" && (string)f34.Content == "⭕")
            {
                MessageBox.Show("Вы проиграли!");
                reload();
            }
            if ((string)f10.Content == "⭕" && (string)f21.Content == "⭕" && (string)f32.Content == "⭕" && (string)f43.Content == "⭕")
            {
                MessageBox.Show("Вы проиграли!");
                reload();
            }
            if ((string)f03.Content == "⭕" && (string)f12.Content == "⭕" && (string)f21.Content == "⭕" && (string)f30.Content == "⭕")
            {
                MessageBox.Show("Вы проиграли!");
                reload();
            }
            if ((string)f14.Content == "⭕" && (string)f23.Content == "⭕" && (string)f32.Content == "⭕" && (string)f41.Content == "⭕")
            {
                MessageBox.Show("Вы проиграли!");
                reload();
            }
            int counter = 0;
            foreach (Button b in TicTac.Children.OfType<Button>())
            {
                if ((string)b.Content == "▢")
                {
                    counter++;
                }
            }
            if(counter==0)
            {
                MessageBox.Show("Ничья!");
                reload();
            }
        }
        private void Field_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)e.Source;
            if((string)b.Content == "▢")
            {
                b.Content = "❎";
            }
            b.IsEnabled = false;
            win_check();
            comp_move();
            if(d==false)
            {
                win_check();
            }
        }
    }
}
