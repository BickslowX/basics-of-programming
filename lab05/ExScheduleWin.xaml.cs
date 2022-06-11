using System;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace znoSystem
{
    /// <summary>
    /// Логика взаимодействия для ExScheduleWin.xaml
    /// </summary>
    public partial class ExScheduleWin : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        public ExScheduleWin()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
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
            dataGrid.Columns[3].Width = 350;
            connection.Close();
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
                AbitSNP.Content = DT.Rows[0][0].ToString() + DT.Rows[0][1].ToString() + DT.Rows[0][2].ToString();
                connection.Close();
            }
            catch { AbitSNP.Content = ""; }
        }
        private void GetAbitEx1()
        {
            string sqlQ = "select ExamName, Date, StartTime, SchoolName, SchoolStreet,SchoolIndex, Audience, RespPerson " +
                          "from AbitList AL " +
                          "full join AbitExams AE on al.AbitID=AE.AbitID " +
                          "full join ExamList1 EL1 on AE.AbitExam1=EL1.ExamID " +
                          "full join AbitEx1 AE1 on AL.AbitID=AE1.AbitID " +
                          "full join SchoolData SD on AE1.SchoolID=SD.SchoolID " +
                          "where AL.AbitID="+AbitIDTB.Text+";";
            try
            {
                GetAndDhowData(sqlQ, AbitEx1DG);
            }
            catch { AbitEx1DG.ItemsSource = null; }
        }
        private void GetAbitEx2()
        {
            string sqlQ = "select ExamName, Date, StartTime, SchoolName, SchoolStreet,SchoolIndex, Audience, RespPerson " +
                          "from AbitList AL " +
                          "full join AbitExams AE on al.AbitID=AE.AbitID " +
                          "full join ExamList2 EL2 on AE.AbitExam2=EL2.ExamID " +
                          "full join AbitEx2 AE2 on AL.AbitID=AE2.AbitID " +
                          "full join SchoolData SD on AE2.SchoolID=SD.SchoolID " +
                          "where AL.AbitID=" + AbitIDTB.Text + ";";
            try
            {
                GetAndDhowData(sqlQ, AbitEx2DG);
            }
            catch { AbitEx2DG.ItemsSource = null; }
        }
        private void GetAbitEx3()
        {
            string sqlQ = "select ExamName, Date, StartTime, SchoolName, SchoolStreet,SchoolIndex, Audience, RespPerson " +
                          "from AbitList AL " +
                          "full join AbitExams AE on al.AbitID=AE.AbitID " +
                          "full join ExamList3 EL3 on AE.AbitExam3=EL3.ExamID " +
                          "full join AbitEx3 AE3 on AL.AbitID=AE3.AbitID " +
                          "full join SchoolData SD on AE3.SchoolID=SD.SchoolID " +
                          "where AL.AbitID=" + AbitIDTB.Text + ";";
            try
            {
                GetAndDhowData(sqlQ, AbitEx3DG);
            }
            catch { AbitEx3DG.ItemsSource = null; }
        }

        private void AbitIDTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetSNP();
            GetAbitEx1();
            GetAbitEx2();
            GetAbitEx3();
        }

        private void ESWBackBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
