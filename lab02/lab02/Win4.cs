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
    internal class Win4
    {
        Window window4;
        Grid myGrid;
        Button test, b_Finish, b_Clear, b_del, b1, b2, b3, b4, b5, b6, b7, b8, b9, b_inverse, b0, b_dot, b_plus, b_min, b_mnoz, b_div, Back4;
        Label Field, res;
        public Win4()
        {
            init();
        }
        private void init()
        {
            window4 = new Window();
            window4.Title = "New Test Windows and Controls";
            window4.ResizeMode = ResizeMode.NoResize;
            myGrid = new Grid();
            window4.Height = 750;
            window4.Width = 650;
            window4.Background = new SolidColorBrush(Colors.LightBlue);
            window4.WindowStartupLocation = WindowStartupLocation.CenterScreen;
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
            Field = new Label();
            Field.Content = "0";
            Field.FontSize = 30;
            Grid.SetRow(Field, 6);
            Grid.SetColumn(Field, 8);
            myGrid.Children.Add(Field);
            //
            res = new Label();
            res.Content = "";
            res.FontSize = 15;
            Grid.SetRow(res, 5);
            Grid.SetColumn(res, 8);
            myGrid.Children.Add(res);
            //
            test = new Button();
            test.Content = "";
            Grid.SetRow(test, 7);
            Grid.SetColumn(test, 8);
            myGrid.Children.Add(test);
            //
            b_Finish = new Button();
            b_Finish.Content = "=";
            b_Finish.Click += b_Finish_Click;
            Grid.SetRow(b_Finish, 7);
            Grid.SetColumn(b_Finish, 9);
            myGrid.Children.Add(b_Finish);
            //
            b_Clear = new Button();
            b_Clear.Content = "C";
            b_Clear.Click += b_Clear_Click;
            Grid.SetRow(b_Clear, 7);
            Grid.SetColumn(b_Clear, 10);
            myGrid.Children.Add(b_Clear);
            //
            b_del = new Button();
            b_del.Content = "Del";
            b_del.Click += b_del_Click;
            Grid.SetRow(b_del, 7);
            Grid.SetColumn(b_del, 11);
            myGrid.Children.Add(b_del);
            //
            b7 = new Button();
            b7.Content = "7";
            b7.Click += b1_Click;
            Grid.SetRow(b7, 8);
            Grid.SetColumn(b7, 8);
            myGrid.Children.Add(b7);
            //
            b8 = new Button();
            b8.Content = "8";
            b8.Click += b1_Click;
            Grid.SetRow(b8, 8);
            Grid.SetColumn(b8, 9);
            myGrid.Children.Add(b8);
            //
            b9 = new Button();
            b9.Content = "9";
            b9.Click += b1_Click;
            Grid.SetRow(b9, 8);
            Grid.SetColumn(b9, 10);
            myGrid.Children.Add(b9);
            //
            b4 = new Button();
            b4.Content = "4";
            b4.Click += b1_Click;
            Grid.SetRow(b4, 9);
            Grid.SetColumn(b4, 8);
            myGrid.Children.Add(b4);
            //
            b5 = new Button();
            b5.Content = "5";
            b5.Click += b1_Click;
            Grid.SetRow(b5, 9);
            Grid.SetColumn(b5, 9);
            myGrid.Children.Add(b5);
            //
            b6 = new Button();
            b6.Content = "6";
            b6.Click += b1_Click;
            Grid.SetRow(b6, 9);
            Grid.SetColumn(b6, 10);
            myGrid.Children.Add(b6);
            //
            b1 = new Button();
            b1.Content = "1";
            b1.Click += b1_Click;
            Grid.SetRow(b1, 10);
            Grid.SetColumn(b1, 8);
            myGrid.Children.Add(b1);
            //
            b2 = new Button();
            b2.Content = "2";
            b2.Click += b1_Click;
            Grid.SetRow(b2, 10);
            Grid.SetColumn(b2, 9);
            myGrid.Children.Add(b2);
            //
            b3 = new Button();
            b3.Content = "3";
            b3.Click += b1_Click;
            Grid.SetRow(b3, 10);
            Grid.SetColumn(b3, 10);
            myGrid.Children.Add(b3);
            //
            b_inverse = new Button();
            b_inverse.Content = "+/_";
            b_inverse.Click += b_inverse_Click;
            Grid.SetRow(b_inverse, 11);
            Grid.SetColumn(b_inverse, 8);
            myGrid.Children.Add(b_inverse);
            //
            //
            b0 = new Button();
            b0.Content = "0";
            b0.Click += b1_Click;
            Grid.SetRow(b0, 11);
            Grid.SetColumn(b0, 9);
            myGrid.Children.Add(b0);
            //
            b_dot = new Button();
            b_dot.Content = ",";
            b_dot.Click += b_dot_Click;
            Grid.SetRow(b_dot, 11);
            Grid.SetColumn(b_dot, 10);
            myGrid.Children.Add(b_dot);
            //
            b_plus = new Button();
            b_plus.Content = "+";
            b_plus.Click += b2_Click;
            Grid.SetRow(b_plus, 11);
            Grid.SetColumn(b_plus, 11);
            myGrid.Children.Add(b_plus);
            //
            b_min = new Button();
            b_min.Content = "-";
            b_min.Click += b2_Click;
            Grid.SetRow(b_min, 10);
            Grid.SetColumn(b_min, 11);
            myGrid.Children.Add(b_min);
            //
            b_mnoz = new Button();
            b_mnoz.Content = "*";
            b_mnoz.Click += b2_Click;
            Grid.SetRow(b_mnoz, 9);
            Grid.SetColumn(b_mnoz, 11);
            myGrid.Children.Add(b_mnoz);
            //
            b_div = new Button();
            b_div.Content = "/";
            b_div.Click += b2_Click;
            Grid.SetRow(b_div, 8);
            Grid.SetColumn(b_div, 11);
            myGrid.Children.Add(b_div);
            //
            Back4 = new Button();
            Back4.Content = "Back";
            Back4.Click += Back4_Click;
            Back4.Background = new SolidColorBrush(Colors.DarkRed);
            Grid.SetRow(Back4, 13);
            Grid.SetColumn(Back4, 6);
            myGrid.Children.Add(Back4);
            //
            window4.Content = myGrid;
            window4.Show();
        }
        private void b1_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)e.Source;
            if ((string)Field.Content != "")
            {
                if ((string)Field.Content == "0")
                {
                    Field.Content = "";
                }
                Field.Content += (string)b.Content;
            }
        }

        private void b_dot_Click(object sender, RoutedEventArgs e)
        {
            string temp = (string)Field.Content;
            if (!temp.Contains(","))
            {
                if ((string)Field.Content == "")
                {
                    Field.Content += "0";
                }
                Field.Content += ",";
            }
        }

        private void b_inverse_Click(object sender, RoutedEventArgs e)
        {
            double temp = Convert.ToDouble(Field.Content);
            temp *= -1;
            Field.Content = Convert.ToString(temp);
        }
        private void refresh(Button b)
        {
            if ((string)Field.Content != "")
            {
                string temp = (string)res.Content;
                if (!temp.Contains('+') && !temp.Contains('-') && !temp.Contains('*') && !temp.Contains('/'))
                {
                    res.Content = (string)Field.Content + (string)b.Content;
                }
                else
                {
                    if (temp[temp.Length - 1] == '+')
                    {
                        temp = temp.Remove(temp.Length - 1);
                        double d1 = Convert.ToDouble(temp);
                        double d2 = Convert.ToDouble(Field.Content);
                        double result = d1 + d2;
                        res.Content = Convert.ToString(result) + b.Content;
                        Field.Content = "0";
                    }
                    if (temp[temp.Length - 1] == '-')
                    {
                        temp = temp.Remove(temp.Length - 1);
                        double d1 = Convert.ToDouble(temp);
                        double d2 = Convert.ToDouble(Field.Content);
                        double result = d1 - d2;
                        res.Content = Convert.ToString(result) + b.Content;
                        Field.Content = "0";
                    }
                    if (temp[temp.Length - 1] == '*')
                    {
                        temp = temp.Remove(temp.Length - 1);
                        double d1 = Convert.ToDouble(temp);
                        double d2 = Convert.ToDouble(Field.Content);
                        double result = d1 * d2;
                        res.Content = Convert.ToString(result) + b.Content;
                        Field.Content = "0";
                    }
                    if (temp[temp.Length - 1] == '/')
                    {
                        temp = temp.Remove(temp.Length - 1);
                        double d1 = Convert.ToDouble(temp);
                        double d2 = Convert.ToDouble(Field.Content);
                        double result = d1 / d2;
                        res.Content = Convert.ToString(result) + b.Content;
                        Field.Content = "0";
                    }
                    if (temp[temp.Length - 1] == '=')
                    {
                        res.Content = (string)Field.Content + (string)b.Content;
                        Field.Content = "0";
                    }
                }
            }
        }
        private void b2_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)e.Source;
            string temp = (string)res.Content;
            if ((string)Field.Content != "")
            {
                if (!temp.Contains('+') && !temp.Contains('-') && !temp.Contains('*') && !temp.Contains('/'))
                {
                    refresh(b);
                    Field.Content = "0";
                }
                else
                {
                    refresh(b);
                }
            }
        }
        private void b_del_Click(object sender, RoutedEventArgs e)
        {
            string temp = (string)Field.Content;
            if (temp.Length != 0)
            {
                temp = temp.Remove(temp.Length - 1);
                Field.Content = temp;
            }
        }

        private void b_Clear_Click(object sender, RoutedEventArgs e)
        {
            Field.Content = "0";
            res.Content = "";
        }

        private void b_Finish_Click(object sender, RoutedEventArgs e)
        {
            string temp = (string)res.Content;
            Button b = (Button)e.Source;
            bool f = false;
            if ((string)Field.Content != "" && (string)res.Content != "")
            {
                if (temp[temp.Length - 1] == '+')
                {
                    temp = temp.Remove(temp.Length - 1);
                    double d1 = Convert.ToDouble(temp);
                    double d2 = Convert.ToDouble(Field.Content);
                    double result = d1 + d2;
                    res.Content = Convert.ToString(d1) + "+" + Convert.ToString(d2) + "=";
                    Field.Content = Convert.ToString(result);
                    f = true;
                }
                if (temp[temp.Length - 1] == '-')
                {
                    temp = temp.Remove(temp.Length - 1);
                    double d1 = Convert.ToDouble(temp);
                    double d2 = Convert.ToDouble(Field.Content);
                    double result = d1 - d2;
                    res.Content = Convert.ToString(d1) + "-" + Convert.ToString(d2) + "=";
                    Field.Content = Convert.ToString(result);
                    f = true;
                }
                if (temp[temp.Length - 1] == '*')
                {
                    temp = temp.Remove(temp.Length - 1);
                    double d1 = Convert.ToDouble(temp);
                    double d2 = Convert.ToDouble(Field.Content);
                    double result = d1 * d2;
                    res.Content = Convert.ToString(d1) + "*" + Convert.ToString(d2) + "=";
                    Field.Content = Convert.ToString(result);
                    f = true;
                }
                if (temp[temp.Length - 1] == '/')
                {
                    temp = temp.Remove(temp.Length - 1);
                    double d1 = Convert.ToDouble(temp);
                    double d2 = Convert.ToDouble(Field.Content);
                    double result = d1 / d2;
                    res.Content = Convert.ToString(d1) + "/" + Convert.ToString(d2) + "=";
                    Field.Content = Convert.ToString(result);
                    f = true;
                }
            }
            if (f == false && (string)Field.Content != "")
            {
                res.Content = (string)Field.Content + "=";
            }
        }

        private void Back4_Click(object sender, RoutedEventArgs e)
        {
            window4.Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
