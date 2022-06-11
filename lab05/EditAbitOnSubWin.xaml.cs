using System;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace znoSystem
{
    /// <summary>
    /// Логика взаимодействия для EditAbitOnSubWin.xaml
    /// </summary>
    public partial class EditAbitOnSubWin : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        public EditAbitOnSubWin()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Ex1CB.ItemsSource = GetSubject1(); Ex1CB.SelectedIndex = 0;
            Ex2CB.ItemsSource = GetSubject2(); Ex2CB.SelectedIndex = 0;
            Ex3CB.ItemsSource = GetSubject3(); Ex3CB.SelectedIndex = 0;
        }
        private String[] GetSubject1()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string[] Items = { "" };
            if (connection.State == System.Data.ConnectionState.Open)
            {
                adapter = new SqlDataAdapter("select ExamName from ExamList1; ", connection);
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
        private String[] GetSubject2()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string[] Items = { "" };
            if (connection.State == System.Data.ConnectionState.Open)
            {
                adapter = new SqlDataAdapter("select ExamName from ExamList2; ", connection);
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
        private String[] GetSubject3()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string[] Items = { "" };
            if (connection.State == System.Data.ConnectionState.Open)
            {
                adapter = new SqlDataAdapter("select ExamName from ExamList3; ", connection);
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
        private void GetAndDhowData(string SQLQuery, DataGrid dataGrid)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(SQLQuery, connection);
            adapter = new SqlDataAdapter(command);
            DataTable Table = new DataTable();
            adapter.Fill(Table);
            dataGrid.ItemsSource = Table.DefaultView;
            connection.Close();
        }
        private void AbitIDTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            string ex1, ex2, ex3;
            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    adapter = new SqlDataAdapter("select ExamName from ExamList1 EL full join AbitExams AE on el.ExamID=ae.AbitExam1 where AbitID =" + AbitIDTB.Text + "; ", connection);
                    DataTable DT1 = new DataTable();
                    adapter.Fill(DT1);
                    ex1 = DT1.Rows[0][0].ToString();

                    adapter = new SqlDataAdapter("select ExamName from ExamList2 EL full join AbitExams AE on el.ExamID=ae.AbitExam2 where AbitID =" + AbitIDTB.Text + "; ", connection);
                    DataTable DT2 = new DataTable();
                    adapter.Fill(DT2);
                    ex2 = DT2.Rows[0][0].ToString();

                    adapter = new SqlDataAdapter("select ExamName from ExamList3 EL full join AbitExams AE on el.ExamID=ae.AbitExam3 where AbitID =" + AbitIDTB.Text + "; ", connection);
                    DataTable DT3 = new DataTable();
                    adapter.Fill(DT3);
                    ex3 = DT3.Rows[0][0].ToString();
                    if (ex1.Length != 0 && ex2.Length != 0 && ex3.Length != 0)
                    {
                        Ex1CB.SelectedItem = ex1;
                        Ex2CB.SelectedItem = ex2;
                        Ex3CB.SelectedItem = ex3;
                    }
                }
                catch
                {
                    Ex1CB.SelectedIndex = 0;
                    Ex2CB.SelectedIndex = 0;
                    Ex3CB.SelectedIndex = 0;
                }
            }
            connection.Close();
        }
        private void ChosenExRefr()
        {

        }
        private void AOEEBackBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            AbitOnExWin aoew = new AbitOnExWin();
            aoew.Show();
        }

        private void AbitOnExBtnRefr_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(AbitIDTB.Text);
                int ExamID2;
                string sqlQ = "";
                adapter = new SqlDataAdapter("select ExamID from ExamList2 where ExamName='" + Ex2CB.SelectedItem + "'", connection);
                DataTable DT2 = new DataTable();
                adapter.Fill(DT2);
                ExamID2 = Convert.ToInt32(DT2.Rows[0][0].ToString());
                int ExamID3;
                adapter = new SqlDataAdapter("select ExamID from ExamList3 where ExamName='" + Ex3CB.SelectedItem + "'", connection);
                DataTable DT3 = new DataTable();
                adapter.Fill(DT3);
                ExamID3 = Convert.ToInt32(DT3.Rows[0][0].ToString());

                sqlQ = "update AbitExams set AbitExam2 = " + ExamID2 + ", AbitExam3=" + ExamID3 + " where AbitID=" + ID + ";";
                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    command = new SqlCommand(sqlQ, connection);
                    MessageBox.Show(command.ExecuteNonQuery().ToString());
                    connection.Close();
                }
                catch { }
            }
            catch { }
        }
    }
}
