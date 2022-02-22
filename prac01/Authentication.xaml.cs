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
using System.IO;
using System.Diagnostics;

namespace prac01
{
    /// <summary>
    /// Логика взаимодействия для Authentication.xaml
    /// </summary>
    public partial class Authentication : Window
    {
        Stopwatch stopWatch = new Stopwatch();
        StreamWriter sw;
        double[] span;
        int counter1 = 0;
        int counter2 = 0;
        string pass;
        public Authentication()
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
                    if ((InputField.Text == pass) && (ErrorCheck() == true))
                    {
                        sw = new StreamWriter("SpanVer.txt", true);
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
                        if (fisher()== false)
                        {
                            DispField.Content = "неоднорідні";
                        }
                        else
                        {
                            DispField.Content = "однорідні";
                        }
                        AuthVerTest();
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
                    AdmCheck1.IsEnabled = false;
                }
            }
            catch { }
        }

        private void CloseStudyMode_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }
        private bool ErrorCheck()
        {
            double[] arr = span;
            for (int i = 0; i < arr.Length; i++)
            {
                StreamWriter ssw = new StreamWriter("Ver_Disp.txt", true);
                double sum = 0;
                for (int j = 0; j < arr.Length; j++)
                {
                    if (j != i)
                    {
                        sum += arr[j];
                    }
                }
                double Mi = sum / (arr.Length - 1);
                StreamWriter VerMi = new StreamWriter("Ver_Mi.txt", true);
                VerMi.Write(Mi + " ");
                VerMi.Close();
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
                    ssw.Write(Math.Round(((sum2 / (arr.Length - 2)) - Math.Pow(Mi, 2)),3)+ " ");
                }
                ssw.Close();
            }
            StreamWriter ss = new StreamWriter("Ver_Disp.txt", true);
            ss.WriteLine();
            ss.Close();
            StreamWriter VerM = new StreamWriter("Ver_Mi.txt", true);
            VerM.WriteLine();
            VerM.Close();
            StreamWriter AdmM = new StreamWriter("Admin_Mi.txt", true);
            AdmM.WriteLine();
            AdmM.Close();
            return true;
        }
        private void AuthVerTest()
        {
            StreamReader AdmSpan = new StreamReader("Span.txt");
            StreamReader VerSpan = new StreamReader("SpanVer.txt");
            string[] tem1 = AdmSpan.ReadToEnd().Split(' ');
            string[] tem2 = VerSpan.ReadToEnd().Split(' ');
            AdmSpan.Close();
            VerSpan.Close();
            List<double> AdminSpan = new List<double>();
            List<double> VeriSpan = new List<double>();
            for (int i = 0;i<tem1.Length;i++)
            {
                if (tem1[i] != "" && tem1[i] != "\r\n")
                {
                    AdminSpan.Add(Convert.ToDouble(tem1[i].Replace("\r","").Replace("\n","")));
                }
            }
            for (int i = 0; i < tem2.Length; i++)
            {
                if (tem2[i] != "" && tem2[i] != "\r\n")
                {
                    VeriSpan.Add(Convert.ToDouble(tem2[i].Replace("\r", "").Replace("\n", "")));
                }
            }
            StreamReader SrAdmDisp = new StreamReader("Admin_Disp.txt");
            StreamReader SrVerDisp = new StreamReader("Ver_Disp.txt");
            string[] AdmDisp = SrAdmDisp.ReadToEnd().Split(' ');
            string[] VerDisp = SrVerDisp.ReadToEnd().Split(' ');
            SrAdmDisp.Close();
            SrVerDisp.Close();
            for (int i = 0; i < AdmDisp.Length; i++)
            {
                AdmDisp[i] = AdmDisp[i].Replace("\n", "");
                AdmDisp[i] = AdmDisp[i].Replace("\r", "");
            }
            for (int i = 0; i < VerDisp.Length; i++)
            {
                VerDisp[i] = VerDisp[i].Replace("\n", "");
                VerDisp[i] = VerDisp[i].Replace("\r", "");
            }
            StreamReader SrVerMi = new StreamReader("Ver_Mi.txt");
            StreamReader SrAdmMi = new StreamReader("Admin_mi.txt");
            string[] VerMi = SrVerMi.ReadToEnd().Split(' ');
            string[] AdmMi = SrAdmMi.ReadToEnd().Split(' ');
            SrVerMi.Close();
            SrAdmMi.Close();
            for (int i = 0; i < AdmMi.Length; i++)
            {
                AdmMi[i] = AdmMi[i].Replace("\n", "");
                AdmMi[i] = AdmMi[i].Replace("\r", "");
            }
            for (int i = 0; i < VerMi.Length; i++)
            {
                VerMi[i] = VerMi[i].Replace("\n", "");
                VerMi[i] = VerMi[i].Replace("\r", "");
            }
            int C = 0;
            StreamReader Mis = new StreamReader("Mistake.txt");
            string[] temp = Mis.ReadToEnd().Split(' ');
            Mis.Close();
            double[] mistCount = new double[temp.Length];
            for (int i = 0;i<3;i++)
            {
                mistCount[i] = Convert.ToDouble(temp[i]);
            }
            for (int i = 0; i < AdmDisp.Length-1; i++)
            {
                double s = Math.Sqrt((Convert.ToDouble(AdmDisp[i])+ Convert.ToDouble(VerDisp[i]))*(AdmDisp.Length-1)/(2*AdmDisp.Length-1));
                double Tp = (Math.Abs(Convert.ToDouble(AdmMi[i]) - Convert.ToDouble(VerMi[i])) /(s * Math.Sqrt(2.0 / AdmDisp.Length)));
                if(Tp < 5.05)
                {
                    C++;
                }
            }
            if(Math.Round((double)C / AdmDisp.Length, 2)>0.7)
            {
                if (AdmCheck1.IsChecked == false)
                {
                    mistCount[2]++;
                }
                else
                {
                    mistCount[0]++;
                }
            }
            else
            {
                if (AdmCheck1.IsChecked == true)
                {
                    mistCount[1]++;
                    mistCount[0]++;
                }
                
            }
            StreamWriter Mista = new StreamWriter("Mistake.txt");
            Mista.WriteLine(mistCount[0] + " " + mistCount[1] + " " + mistCount[2]);
            Mista.Close();
            P1Field.Content = Math.Round(mistCount[1] / mistCount[0],2);
            P2Field.Content = Math.Round(mistCount[2] / mistCount[0],2);
            StatisticsBlock.Content = Math.Round((double)C / (double)AdmDisp.Length,2);
        }
        private bool fisher()
        {
            StreamReader SrAdmDisp = new StreamReader("Admin_Disp.txt");
            StreamReader SrVerDisp = new StreamReader("Ver_Disp.txt");
            string[] AdmDisp = SrAdmDisp.ReadToEnd().Split(' ');
            string[] VerDisp = SrVerDisp.ReadToEnd().Split(' ');
            SrAdmDisp.Close();
            SrVerDisp.Close();
            for(int i = 0; i < AdmDisp.Length; i++)
            {
                AdmDisp[i] = AdmDisp[i].Replace("\n", "");
                AdmDisp[i] = AdmDisp[i].Replace("\r", "");
            }
            for (int i = 0; i < VerDisp.Length; i++)
            {
                VerDisp[i] = VerDisp[i].Replace("\n", "");
                VerDisp[i] = VerDisp[i].Replace("\r", "");
            }
            List<double> Smax = new List<double>();
            List<double> Smin = new List<double>();
            for (int i = 0; i < AdmDisp.Length; i++)
            {
                for (int j = 0; j < VerDisp.Length; j++)
                {
                    if (AdmDisp[i] != "" && VerDisp[j] != "")
                    {
                        Smax.Add((double)Math.Max(Convert.ToDouble(AdmDisp[i]), Convert.ToDouble(VerDisp[j])));
                        Smin.Add(Math.Min(Convert.ToDouble(AdmDisp[i]), Convert.ToDouble(VerDisp[j])));
                    }
                }
            }
            //5.05
            int c0 = 0;
            int c1 = 0;
            for (int i = 0; i < Smax.Count; i++)
            {
                for (int j = 0; j < Smin.Count; j++)
                {
                    double temp = Smax[i] / Smin[j];
                    if (temp > 5.05)
                    {
                        c0++;
                    }
                    else
                    {
                        c1++;
                    }
                }
            }
            if (c0 > c1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
