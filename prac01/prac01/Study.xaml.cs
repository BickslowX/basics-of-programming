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
using System.Diagnostics;
using System.IO;

namespace prac01
{
    /// <summary>
    /// Логика взаимодействия для Study.xaml
    /// </summary>
    public partial class Study : Window
    {
        Stopwatch stopWatch = new Stopwatch();
        StreamWriter sw;
        double[] span;
        int counter1 = 0;
        int counter2 = 0;
        string pass;
        public Study()
        {
            InitializeComponent();
            pass = VerifField.Text;
            span = new double[VerifField.Text.Length - 1];
        }

        private void InputField_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                TryCount.Content = counter2 + 1;
                if (counter1 == span.Length)
                {
                    if ((InputField.Text == pass)&& (ErrorCheck() == true))
                    {
                            sw = new StreamWriter("Span.txt", true);
                            for (int i = 0; i < span.Length; i++)
                            {
                                sw.Write(span[i] + " ");
                            }
                            sw.WriteLine();
                            sw.Close();
                            counter2++;
                    }
                    else 
                    {
                        MessageBox.Show("Спроба не зарахована");
                    }
                    counter1 = 0;
                    InputField.Text = "";
                    stopWatch.Stop();
                    stopWatch.Reset();
                    if (counter2 == Convert.ToInt32(CountProtection.SelectionBoxItem))
                    {
                        InputField.IsEnabled = false;
                    }
                }
                if (stopWatch.IsRunning)
                {
                    stopWatch.Stop();
                    span[counter1] = (double)stopWatch.ElapsedMilliseconds;
                    counter1++;
                    stopWatch.Reset();
                    stopWatch.Start();
                }
                if (!stopWatch.IsRunning)
                {
                    stopWatch.Start();
                    CountProtection.IsEnabled = false;
                }
            }
            catch { }
        }
        private bool ErrorCheck()
        {   
            double[] arr = span;
            for (int i = 0; i < arr.Length; i++)
            {
                StreamWriter ssw = new StreamWriter("Admin_Disp.txt", true);
                double sum = 0;
                for (int j = 0; j < arr.Length; j++)
                {
                    if (j != i)
                    {
                        sum += arr[j];
                    }
                }
                double Mi = sum / (arr.Length - 1);
                StreamWriter AdmMi = new StreamWriter("Admin_Mi.txt", true);
                AdmMi.Write(Mi + " ");
                AdmMi.Close();
                double sum2 = 0;
                for (int j = 0; j < arr.Length; j++)
                {
                    if (j != i)
                    {
                        sum2 += Math.Pow(arr[j], 2);
                    }
                }
                double Si = Math.Sqrt((sum2 / (arr.Length - 2)) - Math.Pow(Mi, 2));
                double Tp = Math.Abs((arr[i] - Mi) / (Si / Math.Sqrt(arr.Length - 1)));
                if (Tp > 2.45)
                {
                    ssw.Close();
                    return false;
                }
                else
                {
                    ssw.Write(Math.Round(((sum2 / (arr.Length - 2)) - Math.Pow(Mi, 2)), 3) + " ");
                }
                ssw.Close();
            }
            StreamWriter ss = new StreamWriter("Admin_Disp.txt", true);
            ss.WriteLine();
            ss.Close();
            StreamWriter AdmM = new StreamWriter("Admin_Mi.txt", true);
            AdmM.WriteLine();
            AdmM.Close();
            return true;
        }
            private void CloseStudyMode_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }
    }
}
