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
    internal class Win5
    {
        Window window5;
        Button Back5;
        Grid myGrid;
        public Win5()
        {
            init();
        }
        private void init()
        {
            window5= new Window();
            window5.Title = "New Test Windows and Controls";
            window5.ResizeMode = ResizeMode.NoResize;
            myGrid = new Grid();
            window5.Height = 450;
            window5.Width = 800;
            window5.Background = new SolidColorBrush(Colors.LightBlue);
            window5.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //myGrid.Width = 400;
            //myGrid.Height = 320;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            //myGrid.ShowGridLines = true;
            RowDefinition[] rows = new RowDefinition[20];
            ColumnDefinition[] cols = new ColumnDefinition[20];
            GridLengthConverter gridLengthConverter = new GridLengthConverter();
            for (int i = 0; i < 5; i++)
            {
                rows[i] = new RowDefinition();
                rows[i].Height = (GridLength)gridLengthConverter.ConvertFrom(69);
                myGrid.RowDefinitions.Add(rows[i]);
            }
            for (int i = 0; i < 5; i++)
            {
                cols[i] = new ColumnDefinition();
                cols[i].Width = (GridLength)gridLengthConverter.ConvertFrom(400);
                myGrid.ColumnDefinitions.Add(cols[i]);
            }
            Label label1 = new Label();
            label1.Foreground = new SolidColorBrush(Colors.DarkRed);
            label1.Content = "Роботу виконав:";
            label1.FontSize = 28;
            Grid.SetRow(label1, 0);
            Grid.SetColumn(label1, 2);
            myGrid.Children.Add(label1);
            //
            Label label2 = new Label();
            label2.Foreground = new SolidColorBrush(Colors.DarkRed);
            label2.Content = "Петров Леонід Андрійович";
            label2.FontSize = 28;
            Grid.SetRow(label2, 1);
            Grid.SetColumn(label2, 2);
            myGrid.Children.Add(label2);
            //
            Label label3 = new Label();
            label3.Foreground = new SolidColorBrush(Colors.DarkRed);
            label3.Content = "Група КП-12";
            label3.FontSize = 28;
            Grid.SetRow(label3, 2);
            Grid.SetColumn(label3, 2);
            myGrid.Children.Add(label3);
            //
            Label label4 = new Label();
            label4.Foreground = new SolidColorBrush(Colors.DarkRed);
            label4.Content = "@2022";
            label4.FontSize = 28;
            Grid.SetRow(label4, 3);
            Grid.SetColumn(label4, 2);
            myGrid.Children.Add(label4);
            //
            Back5 = new Button();
            Back5.Background = new SolidColorBrush(Colors.DarkRed);
            Back5.Content = "Back";
            Back5.Click += Back5_Click;
            Grid.SetRow(Back5, 9);
            Grid.SetColumn(Back5, 10);
            myGrid.Children.Add(Back5);
            window5.Content = myGrid;
            window5.Show();
        }
        private void Back5_Click(object sender, RoutedEventArgs e)
        {
            window5.Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
