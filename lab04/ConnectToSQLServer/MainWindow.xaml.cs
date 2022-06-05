using System.Windows;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Controls;

namespace ConnectToSQLServer
{
    public partial class MainWindow : Window
    {
        string connectionString = null;        
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        // Data Source=LEGIONS7;Initial Catalog=znoDB;Integrated Security=True

        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //MessageBox.Show(connectionString);
            GetAbitList();
            GetAbitOnExData();
            GetExam3Schedule();
            GetExRes();
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

        private void GetAbitList()
        {
            string sqlQ =  "select AbitSurname, AbitName, AbitPatronymic, AbitBirth, SD.SchoolName, AbitGradDate, AbitAVG " +
                           "from dbo.AbitList AL full join SchoolData SD on AL.AbitSchool=SD.SchoolID" +
                           " order by AbitSurname, AbitName;";
            try
            {
                GetAndDhowData(sqlQ, AbitList);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void GetAbitOnExData()
        {
            string sqlQ = "select ExamName, AbitSurname, AbitName " +
                "from AbitList AL " +
                "full join AbitExams AE on AL.AbitID=AE.AbitID " +
                "full join ExamList3 EL on AE.AbitExam3=EL.ExamID" +
                " where AbitExam3 = '4'" +
                "order by AbitSurname, AbitName;";
            try
            {
                GetAndDhowData(sqlQ, AbitOnExam);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void GetExam3Schedule()
        {
            string sqlQ = "select  AbitSurname, AbitName, ExamName, Date, StartTime " +
                       "from AbitList AL  " +
                       "full join AbitEx3 AE3 on AL.AbitID=AE3.AbitID " +
                       "full join AbitExams AE on AL.AbitID=AE.AbitID  " +
                       "full join ExamList3 EL on AE.AbitExam3=EL.ExamID" +
                    " where AbitSurname is not null" +
                    " order by AbitSurname, AbitName;";
            try
            {
               GetAndDhowData(sqlQ, AbitSchedule);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void GetExRes()
        {
            string sqlQ = "SELECT AbitSurname,AbitName, EL1.ExamName as [Exam1],AbitEx1Res [Exam1 Results], EL2.ExamName as [Exam2],AbitEx2Res as [Exam2 Results],  EL3.ExamName as [Exam3], AbitEx3Res [Exam3 Results], AbitExAVG as [ExamsAVG]" +
                "from Abitlist AL " +
                "full join AbitExams AE on AL.AbitID=AE.AbitID " +
                "full join ExamList1 EL1 on AE.AbitExam1=EL1.ExamID " +
                "full join ExamList2 EL2 on AE.AbitExam2=EL2.ExamID " +
                "full join ExamList3 EL3 on AE.AbitExam3=EL3.ExamID " +
                "full join AbitExResults AER on AL.AbitID=AER.AbitID " +
                " where AbitSurname is not null" +
                " order by AbitSurname, AbitName;";
            try
            {
               GetAndDhowData(sqlQ, AbitExRes);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}