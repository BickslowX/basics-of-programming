using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media;

namespace lab02
{
    internal class Win3
    {
        Window window3;
        static bool d = false;
        Grid myGrid;
        public Win3()
        {
            init();
        }
        Button f00, f01, f02, f03, f04, f10, f11, f12, f13, f14, f20, f21, f22, f23, f24, f30, f31, f32, f33, f34, f40, f41, f42, f43, f44;
        private void init()
        {
            window3 = new Window();
            window3.Title = "New Test Windows and Controls";
            window3.ResizeMode = ResizeMode.NoResize;
            myGrid = new Grid();
            window3.Height = 750;
            window3.Width = 650;
            window3.Background = new SolidColorBrush(Colors.LightBlue);
            window3.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //myGrid.Width = 400;
            //myGrid.Height = 320;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            //myGrid.ShowGridLines = true;
            RowDefinition[] rows = new RowDefinition[20];
            ColumnDefinition[] cols = new ColumnDefinition[20];
            GridLengthConverter gridLengthConverter = new GridLengthConverter();
            for (int i = 0; i < 20; i++)
            {
                rows[i] = new RowDefinition();
                rows[i].Height = (GridLength)gridLengthConverter.ConvertFrom(69);
                myGrid.RowDefinitions.Add(rows[i]);
            }
            for (int i = 0; i < 20; i++)
            {
                cols[i] = new ColumnDefinition();
                cols[i].Width = (GridLength)gridLengthConverter.ConvertFrom(69);
                myGrid.ColumnDefinitions.Add(cols[i]);
            }
            //
            f00 = new Button();
            f00.Background = new SolidColorBrush(Colors.DarkRed);
            f00.Content = "▢";
            f00.Click += Field_Click;
            Grid.SetRow(f00, 6);
            Grid.SetColumn(f00, 8);
            myGrid.Children.Add(f00);
            //
            //
            f01 = new Button();
            f01.Background = new SolidColorBrush(Colors.DarkRed);
            f01.Content = "▢";
            f01.Click += Field_Click;
            Grid.SetRow(f01, 6);
            Grid.SetColumn(f01, 9);
            myGrid.Children.Add(f01);
            //
            f02 = new Button();
            f02.Background = new SolidColorBrush(Colors.DarkRed);
            f02.Content = "▢";
            f02.Click += Field_Click;
            Grid.SetRow(f02, 6);
            Grid.SetColumn(f02, 10);
            myGrid.Children.Add(f02);
            //
            f03 = new Button();
            f03.Background = new SolidColorBrush(Colors.DarkRed);
            f03.Content = "▢";
            f03.Click += Field_Click;
            Grid.SetRow(f03, 6);
            Grid.SetColumn(f03, 11);
            myGrid.Children.Add(f03);
            //
            f04 = new Button();
            f04.Background = new SolidColorBrush(Colors.DarkRed);
            f04.Content = "▢";
            f04.Click += Field_Click;
            Grid.SetRow(f04, 6);
            Grid.SetColumn(f04, 12);
            myGrid.Children.Add(f04);
            //
            //
            f10 = new Button();
            f10.Background = new SolidColorBrush(Colors.DarkRed);
            f10.Content = "▢";
            f10.Click += Field_Click;
            Grid.SetRow(f10, 7);
            Grid.SetColumn(f10, 8);
            myGrid.Children.Add(f10);
            //
            //
            f11 = new Button();
            f11.Background = new SolidColorBrush(Colors.DarkRed);
            f11.Content = "▢";
            f11.Click += Field_Click;
            Grid.SetRow(f11, 7);
            Grid.SetColumn(f11, 9);
            myGrid.Children.Add(f11);
            //
           f12 = new Button();
            f12.Background = new SolidColorBrush(Colors.DarkRed);
            f12.Content = "▢";
            f12.Click += Field_Click;
            Grid.SetRow(f12, 7);
            Grid.SetColumn(f12, 10);
            myGrid.Children.Add(f12);
            //
            f13 = new Button();
            f13.Background = new SolidColorBrush(Colors.DarkRed);
            f13.Content = "▢";
            f13.Click += Field_Click;
            Grid.SetRow(f13, 7);
            Grid.SetColumn(f13, 11);
            myGrid.Children.Add(f13);
            //
            f14 = new Button();
            f14.Background = new SolidColorBrush(Colors.DarkRed);
            f14.Content = "▢";
            f14.Click += Field_Click;
            Grid.SetRow(f14, 7);
            Grid.SetColumn(f14, 12);
            myGrid.Children.Add(f14);
            //
            //
            f20 = new Button();
            f20.Background = new SolidColorBrush(Colors.DarkRed);
            f20.Content = "▢";
            f20.Click += Field_Click;
            Grid.SetRow(f20, 8);
            Grid.SetColumn(f20, 8);
            myGrid.Children.Add(f20);
            //
            //
            f21 = new Button();
            f21.Background = new SolidColorBrush(Colors.DarkRed);
            f21.Content = "▢";
            f21.Click += Field_Click;
            Grid.SetRow(f21, 8);
            Grid.SetColumn(f21, 9);
            myGrid.Children.Add(f21);
            //
            f22 = new Button();
            f22.Background = new SolidColorBrush(Colors.DarkRed);
            f22.Content = "▢";
            f22.Click += Field_Click;
            Grid.SetRow(f22, 8);
            Grid.SetColumn(f22, 10);
            myGrid.Children.Add(f22);
            //
            f23 = new Button();
            f23.Background = new SolidColorBrush(Colors.DarkRed);
            f23.Content = "▢";
            f23.Click += Field_Click;
            Grid.SetRow(f23, 8);
            Grid.SetColumn(f23, 11);
            myGrid.Children.Add(f23);
            //
            f24 = new Button();
            f24.Background = new SolidColorBrush(Colors.DarkRed);
            f24.Content = "▢";
            f24.Click += Field_Click;
            Grid.SetRow(f24, 8);
            Grid.SetColumn(f24, 12);
            myGrid.Children.Add(f24);
            //
            //
           f30 = new Button();
            f30.Background = new SolidColorBrush(Colors.DarkRed);
            f30.Content = "▢";
            f30.Click += Field_Click;
            Grid.SetRow(f30, 9);
            Grid.SetColumn(f30, 8);
            myGrid.Children.Add(f30);
            //
            //
            f31 = new Button();
            f31.Background = new SolidColorBrush(Colors.DarkRed);
            f31.Content = "▢";
            f31.Click += Field_Click;
            Grid.SetRow(f31, 9);
            Grid.SetColumn(f31, 9);
            myGrid.Children.Add(f31);
            //
            f32 = new Button();
            f32.Background = new SolidColorBrush(Colors.DarkRed);
            f32.Content = "▢";
            f32.Click += Field_Click;
            Grid.SetRow(f32, 9);
            Grid.SetColumn(f32, 10);
            myGrid.Children.Add(f32);
            //
            f33 = new Button();
            f33.Background = new SolidColorBrush(Colors.DarkRed);
            f33.Content = "▢";
            f33.Click += Field_Click;
            Grid.SetRow(f33, 9);
            Grid.SetColumn(f33, 11);
            myGrid.Children.Add(f33);
            //
            f34 = new Button();
            f34.Background = new SolidColorBrush(Colors.DarkRed);
            f34.Content = "▢";
            f34.Click += Field_Click;
            Grid.SetRow(f34, 9);
            Grid.SetColumn(f34, 12);
            myGrid.Children.Add(f34);
            //
            //
            f40 = new Button();
            f40.Background = new SolidColorBrush(Colors.DarkRed);
            f40.Content = "▢";
            f40.Click += Field_Click;
            Grid.SetRow(f40, 10);
            Grid.SetColumn(f40, 8);
            myGrid.Children.Add(f40);
            //
            //
            f41 = new Button();
            f41.Background = new SolidColorBrush(Colors.DarkRed);
            f41.Content = "▢";
            f41.Click += Field_Click;
            Grid.SetRow(f41, 10);
            Grid.SetColumn(f41, 9);
            myGrid.Children.Add(f41);
            //
            f42 = new Button();
            f42.Background = new SolidColorBrush(Colors.DarkRed);
            f42.Content = "▢";
            f42.Click += Field_Click;
            Grid.SetRow(f42, 10);
            Grid.SetColumn(f42, 10);
            myGrid.Children.Add(f42);
            //
            f43 = new Button();
            f43.Background = new SolidColorBrush(Colors.DarkRed);
            f43.Content = "▢";
            f43.Click += Field_Click;
            Grid.SetRow(f43, 10);
            Grid.SetColumn(f43, 11);
            myGrid.Children.Add(f43);
            //
            f44 = new Button();
            f44.Background = new SolidColorBrush(Colors.DarkRed);
            f44.Content = "▢";
            f44.Click += Field_Click;
            Grid.SetRow(f44, 10);
            Grid.SetColumn(f44, 12);
            myGrid.Children.Add(f44);
            //
            Button Back3 = new Button();
            Back3.Background = new SolidColorBrush(Colors.DarkRed);
            Back3.Content = "Back";
            Back3.Click += Back3_Click;
            Grid.SetRow(Back3, 13);
            Grid.SetColumn(Back3, 6);
            myGrid.Children.Add(Back3);
            window3.Content = myGrid;
            window3.Show();
        }
        private void Back3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            window3.Hide();
            mw.Show();
        }
        private void Field_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)e.Source;
            if ((string)b.Content == "▢")
            {
                b.Content = "❎";
            }
            b.IsEnabled = false;
            win_check();
            comp_move();
            if (d == false)
            {
                win_check();
            }
        }
        private void reload()
        {
            
            window3.Hide();
            Win3 ww3 = new Win3();
        }
        private void comp_move()
        {
            bool flag = false;
            Random r = new Random();
            while (flag == false)
            {
                int num = r.Next(0, 25);
                int counter = 0;
                foreach (Button b in myGrid.Children.OfType<Button>())
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
            if (((string)f00.Content == "❎" && (string)f01.Content == "❎" && (string)f02.Content == "❎" && (string)f03.Content == "❎") || ((string)f01.Content == "❎" && (string)f02.Content == "❎" && (string)f03.Content == "❎" && (string)f04.Content == "❎"))
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
            foreach (Button b in myGrid.Children.OfType<Button>())
            {
                if ((string)b.Content == "▢")
                {
                    counter++;
                }
            }
            if (counter == 0)
            {
                MessageBox.Show("Ничья!");
                reload();
            }
        }
    }
}
