using System;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace znoSystem
{
    /// <summary>
    /// Логика взаимодействия для AbitListWin.xaml
    /// </summary>
    public partial class AbitListWin : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        // Data Source=LEGIONS7;Initial Catalog=znoDB;Integrated Security=True

        public AbitListWin()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //MessageBox.Show(connectionString);
            GetAbitList();
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
            string sqlQ = "select AbitID as [ID], AbitSurname as [Прізвище], AbitName as [Ім'я], AbitPatronymic as [Побатькові], AbitBirth as [Дата Народж] , SD.SchoolName as [Назва школи], AbitGradDate as [Дата випуску], AbitAVG as [Середній бал]" +
                           "from dbo.AbitList AL full join SchoolData SD on AL.AbitSchool=SD.SchoolID" +
                           " order by AbitSurname, AbitName;";
            try
            {
                GetAndDhowData(sqlQ, AbitListDG);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void AbitListDG_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            String ID;
            string sqlQ="";
            DataGridColumn EditedCol = e.Column;
            DataGridRow EditedRow = e.Row;
            //Int32 Row = ((DataGrid)sender).ItemContainerGenerator.IndexFromContainer(EditedRow);
            Int32 Col = EditedCol.DisplayIndex;
            TextBox t = e.EditingElement as TextBox;

            String editedCellValue = t.Text.ToString();

            DataRowView row = (DataRowView)AbitListDG.SelectedItem;
            ID = row["ID"].ToString();
            if (Col == 1)
                sqlQ = "UPDATE AbitList SET AbitSurname = '" + editedCellValue + "' WHERE AbitID = " + ID + ";";
            else if (Col == 2)
                sqlQ = "UPDATE AbitList SET AbitName = '" + editedCellValue + "' WHERE AbitID = " + ID + ";";
            else if (Col == 3)
                sqlQ = "UPDATE AbitList SET AbitPatronymic = '" + editedCellValue + "' WHERE AbitID = " + ID + ";";
            else if (Col == 4)
                sqlQ = "UPDATE AbitList SET AbitBirth = '" + editedCellValue + "' WHERE AbitID = " + ID + ";";
            else if (Col == 6)
                sqlQ = "UPDATE AbitList SET AbitGradDate = '" + editedCellValue + "' WHERE AbitID = " + ID + ";";
            else if (Col == 7)
                sqlQ = "UPDATE AbitList SET AbitAVG = '" + editedCellValue + "' WHERE AbitID = " + ID + ";";
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

        private void Return1Butt_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }

        private void DelAbit_Click(object sender, RoutedEventArgs e)
        {
            DelAbitWin DAW = new DelAbitWin();
            Hide();
            DAW.Show();
        }

        private void AddAbit_Click(object sender, RoutedEventArgs e)
        {
            AddAbitWin AAW = new AddAbitWin();
            Hide();
            AAW.Show();
        }
    }
}
