using System;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace znoSystem
{
    /// <summary>
    /// Логика взаимодействия для ResultsWin.xaml
    /// </summary>
    public partial class ResultsWin : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        //SqlCommand command;
        SqlDataAdapter adapter;
        string priv = null;
        public ResultsWin()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        private void GetSNP()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                adapter = new SqlDataAdapter("select AbitSurname, AbitName, AbitPatronymic from AbitList where AbitID=" + AbitIDTB.Text + ";", connection);
                DataTable DT = new DataTable();
                adapter.Fill(DT);
                string snp = DT.Rows[0][0].ToString() + DT.Rows[0][1].ToString() + DT.Rows[0][2].ToString();
                while (snp.Contains("  ")) 
                {
                    snp = snp.Replace("  ", " "); 
                }
                AbitSNP.Content = snp;
                connection.Close();
            }
            catch { AbitSNP.Content = ""; }
        }
        private void GetEx1()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                adapter = new SqlDataAdapter("select ExamName from ExamList1 el1 full join AbitExams ae on el1.ExamID=ae.AbitExam1 where AbitID=" + AbitIDTB.Text + ";", connection);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                Ex1LB.Content = Table.Rows[0][0].ToString();
                connection.Close();
            }
            catch { Ex1LB.Content = "<Назва>"; }
        }
        private void GetEx2()
        {
            try
            {
                adapter = new SqlDataAdapter("select ExamName from ExamList2 el2 full join AbitExams ae on el2.ExamID=ae.AbitExam2 where AbitID=" + AbitIDTB.Text + ";", connection);
                DataTable DT = new DataTable();
                adapter.Fill(DT);
                Ex2LB.Content = DT.Rows[0][0].ToString();
            }
            catch { Ex2LB.Content = "<Назва>"; }
        }
        private void GetEx3()
        {
            try
            {
                adapter = new SqlDataAdapter("select ExamName from ExamList3 el3 full join AbitExams ae on el3.ExamID=ae.AbitExam3 where AbitID=" + AbitIDTB.Text + ";", connection);
                DataTable DT = new DataTable();
                adapter.Fill(DT);
                Ex3LB.Content = DT.Rows[0][0].ToString();
            }
            catch { Ex3LB.Content = "<Назва>"; }
        }
        private void GetMark1()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                adapter = new SqlDataAdapter("select AbitEx1Res from AbitExResults where AbitID=" + AbitIDTB.Text + ";", connection);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                Ex1Res.Content = Table.Rows[0][0].ToString();
                connection.Close();
            }
            catch { Ex1Res.Content = "-"; }
        }
        private void GetMark2()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                adapter = new SqlDataAdapter("select AbitEx2Res from AbitExResults where AbitID=" + AbitIDTB.Text + ";", connection);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                Ex2Res.Content = Table.Rows[0][0].ToString();
                connection.Close();
            }
            catch { Ex2Res.Content = "-"; }
        }
        private void GetMark3()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                adapter = new SqlDataAdapter("select AbitEx3Res from AbitExResults where AbitID=" + AbitIDTB.Text + ";", connection);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                Ex3Res.Content = Table.Rows[0][0].ToString();
                connection.Close();
            }
            catch { Ex3Res.Content = "-"; }
        }
        private void GetAVG()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                adapter = new SqlDataAdapter("select AbitExAVG from AbitExResults where AbitID=" + AbitIDTB.Text + ";", connection);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                ExAVG.Content = Table.Rows[0][0].ToString();
                connection.Close();
            }
            catch { ExAVG.Content = "-"; }
        }
        private void GetPriv()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                adapter = new SqlDataAdapter("select AbitPrivileges from AbitExams where AbitID=" + AbitIDTB.Text + ";", connection);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                priv = Table.Rows[0][0].ToString();
                connection.Close();
            }
            catch {}
        }
        private void SetPriv()
        {
            try
            {
                int tmark1 = Convert.ToInt32(Ex1Res.Content), tmark2 = Convert.ToInt32(Ex2Res.Content), tmark3 = Convert.ToInt32(Ex3Res.Content); double tavg;
                if (priv == null)
                {
                    return;
                }
                else if (priv == "1")
                {
                    if (tmark1 < tmark2 && tmark2 < tmark3)
                    {
                        tmark1 = 200; tmark2 = 200;
                    }
                    else if (tmark2 < tmark3 && tmark3 < tmark1)
                    {
                        tmark2 = 200; tmark3 = 200;
                    }
                    else if (tmark3 < tmark1 && tmark1 < tmark2)
                    {
                        tmark3 = 200; tmark1 = 200;
                    }
                    tavg = Math.Round(((tmark1 + tmark2 + tmark3) / 3.0),2);
                    Ex1Res.Content = tmark1; Ex2Res.Content = tmark2; Ex3Res.Content = tmark3; ExAVG.Content = tavg;
                }
                else if (priv == "2")
                {
                    if (tmark1 < tmark2 && tmark1 < tmark3)
                    {
                        tmark1 += 10;
                        if (tmark1 > 200)
                        { tmark1 = 200; }
                    }
                    else if (tmark2 < tmark3 && tmark2 < tmark1)
                    {
                        tmark2 += 10;
                        if (tmark2 > 200)
                        { tmark2 = 200; }
                    }
                    else if (tmark3 < tmark1 && tmark3 < tmark2)
                    {
                        tmark3 += 10;
                        if (tmark3 > 200)
                        { tmark3 = 200; }
                    }
                    tavg = Math.Round(((tmark1 + tmark2 + tmark3) / 3.0),2);
                    Ex1Res.Content = tmark1; Ex2Res.Content = tmark2; Ex3Res.Content = tmark3; ExAVG.Content = tavg;
                }
            }
            catch { }
        }
        private void AbitIDTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetSNP();
            GetEx1();
            GetEx2();
            GetEx3();
            GetMark1();
            GetMark2();
            GetMark3();
            GetAVG();
            if(PrivCheck.IsChecked == true)
            {
                GetPriv();
                SetPriv();
            }
        }

        private void PrivCheck_Checked(object sender, RoutedEventArgs e)
        {
            GetSNP();
            GetEx1();
            GetEx2();
            GetEx3();
            GetMark1();
            GetMark2();
            GetMark3();
            GetAVG();
            if (PrivCheck.IsChecked == true)
            {
                GetPriv();
                SetPriv();
            }
        }

        private void PrivCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            GetSNP();
            GetEx1();
            GetEx2();
            GetEx3();
            GetMark1();
            GetMark2();
            GetMark3();
            GetAVG();
            if (PrivCheck.IsChecked == true)
            {
                GetPriv();
                SetPriv();
            }
        }

        private void RWBackBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        private void AddResBtn_Click(object sender, RoutedEventArgs e)
        {
            AddResWin arw = new AddResWin();
            Hide();
            arw.Show();
        }
    }
}
