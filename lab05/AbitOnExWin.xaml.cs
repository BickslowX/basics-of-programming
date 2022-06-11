using System;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace znoSystem
{
    /// <summary>
    /// Логика взаимодействия для AbitOnExWin.xaml
    /// </summary>
    public partial class AbitOnExWin : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        public AbitOnExWin()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            ExamNameCB.ItemsSource = GetItemsSubjects(); ExamNameCB.SelectedIndex = 0;
            GetAbitOnExList();
        }
        private String[] GetItemsSubjects()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string[] Items = { "" };
            if (connection.State == System.Data.ConnectionState.Open)
            {
                adapter = new SqlDataAdapter("select ExamID, ExamName from ExamList3 union all select ExamID, ExamName from ExamList2 union all select ExamID, ExamName from ExamList1 order by ExamID; ", connection);
                DataTable DT = new DataTable();
                adapter.Fill(DT);

                Items = new String[DT.Rows.Count];
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    Items[i] = DT.Rows[i][1].ToString();
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
        private void GetAbitOnExList()
        {
            adapter = new SqlDataAdapter("select ExamID from ExamList1 where ExamName = '" + ExamNameCB.SelectedItem + "' union all select ExamID from ExamList2 where ExamName = '" + ExamNameCB.SelectedItem + "' union all select ExamID from ExamList3 where ExamName = '" + ExamNameCB.SelectedItem + "';", connection);
            DataTable DT = new DataTable();
            adapter.Fill(DT);
            int ExID = Convert.ToInt32(DT.Rows[0][0].ToString());
            string sqlQ = "select AbitSurname, AbitName, AbitPatronymic from AbitList AL full join AbitExams AE on AL.AbitID=AE.AbitID where AbitExam1 = " + ExID + " or AbitExam2 = " + ExID + " or AbitExam3 = " + ExID + " order by AbitSurname, AbitName, AbitPatronymic;";
            try
            {
                GetAndDhowData(sqlQ, AbitOnExDG);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void ExamNameCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetAbitOnExList();
        }

        private void AOEBackBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        private void AbitOnExEditBtn_Click(object sender, RoutedEventArgs e)
        {
            EditAbitOnSubWin eaosw = new EditAbitOnSubWin();
            Hide();
            eaosw.Show();
        }
    }
}
