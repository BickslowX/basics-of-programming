using System;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace znoSystem
{
    /// <summary>
    /// Логика взаимодействия для AddResWin.xaml
    /// </summary>
    public partial class AddResWin : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        public AddResWin()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            AbitIDCB.ItemsSource = GetAbitID(); AbitIDCB.SelectedIndex = 0;
            GetSNP();
            GetEx1();
            GetEx2();
            GetEx3();
            GetAVG();
        }
        private String[] GetAbitID()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string[] Items = { "" };
            if (connection.State == System.Data.ConnectionState.Open)
            {
                adapter = new SqlDataAdapter("select al.AbitID from AbitList Al left join AbitExResults AR on al.AbitID=AR.AbitID where ar.AbitID is null; ", connection);
                DataTable DT = new DataTable();
                adapter.Fill(DT);

                Items = new String[DT.Rows.Count];
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    Items[i] = DT.Rows[i][0].ToString();
                }
            }
            connection.Close();

            return Items;
        }
        private void GetSNP()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                adapter = new SqlDataAdapter("select AbitSurname, AbitName, AbitPatronymic from AbitList where AbitID=" + AbitIDCB.SelectedItem + ";", connection);
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
                adapter = new SqlDataAdapter("select ExamName from ExamList1 el1 full join AbitExams ae on el1.ExamID=ae.AbitExam1 where AbitID=" + AbitIDCB.SelectedItem + ";", connection);
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
                adapter = new SqlDataAdapter("select ExamName from ExamList2 el2 full join AbitExams ae on el2.ExamID=ae.AbitExam2 where AbitID=" + AbitIDCB.SelectedItem + ";", connection);
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
                adapter = new SqlDataAdapter("select ExamName from ExamList3 el3 full join AbitExams ae on el3.ExamID=ae.AbitExam3 where AbitID=" + AbitIDCB.SelectedItem + ";", connection);
                DataTable DT = new DataTable();
                adapter.Fill(DT);
                Ex3LB.Content = DT.Rows[0][0].ToString();
            }
            catch { Ex3LB.Content = "<Назва>"; }
        }
        private void GetAVG()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                adapter = new SqlDataAdapter("select AbitExAVG from AbitExResults where AbitID=" + AbitIDCB.SelectedItem + ";", connection);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                ExAVG.Content = Table.Rows[0][0].ToString();
                connection.Close();
            }
            catch { ExAVG.Content = "-"; }
        }
        private void RWBackBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            ResultsWin rw = new ResultsWin();
            rw.Show();
        }
        private void AddResBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                int tID = Convert.ToInt32(AbitIDCB.SelectedItem);
                int tEx1Rres = Convert.ToInt32(Ex1ResTB.Text);
                int tEx2Rres = Convert.ToInt32(Ex2ResTB.Text);
                int tEx3Rres = Convert.ToInt32(Ex3ResTB.Text);
                if (tEx1Rres > 200)
                { tEx1Rres = 200; }
                if (tEx2Rres > 200)
                { tEx2Rres = 200; }
                if (tEx3Rres > 200)
                { tEx3Rres = 200; }
                double tAVG = Math.Round(((tEx1Rres + tEx2Rres + tEx3Rres) / 3.0), 1);
                string sAVG = Convert.ToString(tAVG);
                sAVG = sAVG.Replace(',', '.');

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    try
                    {
                        string sqlQ = "insert into AbitExResults (AbitID, AbitEx1Res, AbitEx2Res,AbitEx3Res,AbitExAVG) " +
                                      "values(" + tID + "," + tEx1Rres + "," + tEx2Rres + "," + tEx3Rres + "," + sAVG + ");";
                        command = new SqlCommand(sqlQ, connection);
                        MessageBox.Show(command.ExecuteNonQuery().ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Error");
                    }
                }
                connection.Close();
            }
            catch { }
        }

        private void AbitIDCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetSNP();
            GetEx1();
            GetEx2();
            GetEx3();
            GetAVG();
        }
    }
}
