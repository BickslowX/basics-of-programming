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
    /// Логика взаимодействия для Win4.xaml
    /// </summary>
    public partial class Win4 : Window
    {
        public Win4()
        {
            InitializeComponent();
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)e.Source;
            if((string)Field.Content=="0")
            {
                Field.Content = "";
            }
            Field.Content += (string)b.Content;
        }

        private void b_dot_Click(object sender, RoutedEventArgs e)
        {
            string temp = (string)Field.Content;
            if (!temp.Contains(","))
            {
                Field.Content += ",";
            }
        }

        private void b_inverse_Click(object sender, RoutedEventArgs e)
        {
            double temp = Convert.ToDouble(Field.Content);
            temp *= -1;
            Field.Content =Convert.ToString(temp);
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)e.Source;
            res.Content += (string)Field.Content+(string)b.Content;
            Field.Content = "0";
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
            double result;
            res.Content += (string)Field.Content;
            string exp = (string)res.Content;
            char[] separator = { '+', '-', '*', '/' };
            string[] temp = exp.Split(separator);
            string act = "";
            for(int i=0;i<exp.Length;i++)
            {
                if(!char.IsDigit(exp[i]))
                {
                    act += exp[i];
                }
            }
            result = Convert.ToDouble(temp[0]);
            for(int i=0;i<act.Length;i++)
            {
                if(act[i]=='+')
                {
                    result += Convert.ToDouble(temp[i + 1]);
                }
                if(act[i]=='-')
                {
                    result -= Convert.ToDouble(temp[i + 1]);
                }
                if(act[i]=='/')
                {
                    result /= Convert.ToDouble(temp[i+1]);
                }
                if(act[i]=='*')
                {
                    result *= Convert.ToDouble(temp[i + 1]);
                }
            }
            res.Content += "=";
            Field.Content = Convert.ToString(result);
        }

        private void Back4_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }
    }
}
