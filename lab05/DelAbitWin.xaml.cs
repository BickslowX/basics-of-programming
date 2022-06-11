using System;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace znoSystem
{
    /// <summary>
    /// Логика взаимодействия для DelAbitWin.xaml
    /// </summary>
    public partial class DelAbitWin : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;

        public DelAbitWin()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void DelAbit()
        {
            String ID;
            connection = new SqlConnection(connectionString);
            connection.Open();
            ID = AbitIDTB.Text;
            string sqlQ = "DELETE FROM AbitList WHERE AbitID = '" + ID + "';";

            command = new SqlCommand(sqlQ, connection);

            MessageBox.Show(command.ExecuteNonQuery().ToString());
            connection.Close();
        }

        private void DelAbitBtn_Click(object sender, RoutedEventArgs e)
        {
            DelAbit();
        }

        private void DelBackBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            AbitListWin alw = new AbitListWin();
            alw.Show();
        }
    }
}
