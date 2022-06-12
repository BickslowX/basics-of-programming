using System;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace prac03
{
    /// <summary>
    /// Логика взаимодействия для Administration.xaml
    /// </summary>
    public partial class Administration : Window
    {
        string Connection = null;
        SqlConnection sqlConn = null;
        SqlCommand Com;
        SqlDataAdapter Data;
        DataTable dT;
        int LenTable;
        int index;
        public Administration()
        {
            InitializeComponent();
            RealAdminPasswd.IsEnabled = false;
            NewAdminPasswd.IsEnabled = false;
            NewAdminPasswd2.IsEnabled = false;
            Prev.IsEnabled = false; Next.IsEnabled = false;
            UpdatePasswd.IsEnabled = false;
            AddUser.IsEnabled = false;
            CorrectStatusBtn.IsEnabled = false;
            CorrectRestrictionBtn.IsEnabled = false;
            Connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void UpdatePasswd_Click(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            String strQ;
            String RealPass = RealAdminPasswd.Text.ToString();
            String NewPass = NewAdminPasswd.Text.ToString();
            String NewPass2 = NewAdminPasswd2.Text.ToString();
            if ((RealPass == AdminPasswd.Text.ToString()) && (NewPass != "")
            && (NewPass == NewPass2))
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    strQ = "UPDATE MainTable SET Password ='" + NewPass + "' WHERE Login = 'ADMIN'; ";
                    Com = new SqlCommand(strQ, sqlConn);
                    Com.ExecuteNonQuery();
                }
            }
            sqlConn.Close();
        }
        void UpdateDataTable()
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                Data = new SqlDataAdapter("SELECT Name, Surname, Login, Status, Restriction FROM MainTable", sqlConn);
                dT = new DataTable("Користувачі системи");
                Data.Fill(dT);
                dataGrid.ItemsSource = dT.DefaultView;
                LenTable = dT.Rows.Count;
            }
            sqlConn.Close();
        }
        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            if (index > 0)
            {
                index--;
                UserNameSelected.Content = dT.Rows[index][0].ToString();
                UserSurnameSelected.Content = dT.Rows[index][1].ToString();
                UserLoginSelected.Content = dT.Rows[index][2].ToString();
                UserStatusSelected.Content = dT.Rows[index][3].ToString();
                UserRestrictionSelected.Content = dT.Rows[index][4].ToString();
            }
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (index < LenTable - 1)
            {

                index++;
                UserNameSelected.Content = dT.Rows[index][0].ToString();
                UserSurnameSelected.Content = dT.Rows[index][1].ToString();
                UserLoginSelected.Content = dT.Rows[index][2].ToString();
                UserStatusSelected.Content = dT.Rows[index][3].ToString();
                UserRestrictionSelected.Content = dT.Rows[index][4].ToString();
            }
        }
        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            String strQ;
            String UserLogin = AddingUserLogin.Text;
            try
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    strQ = "INSERT INTO MainTable (Name, Surname, Login, Status, Restriction) values('', '', '" + UserLogin + "', 1, 0); ";
                Com = new SqlCommand(strQ, sqlConn);
                    Com.ExecuteNonQuery();
                }
                UpdateDataTable();
            }
            catch
            {
                MessageBox.Show("Користувача не додано! Можливо такий в базі вже є!");
            }
            sqlConn.Close();
        }
        private void CorrectStatusBtn_Click(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            String strQ;
            bool UserStatus = (bool)ChangeActive.IsChecked;
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                strQ = "UPDATE MainTable SET Status ='" + UserStatus + "' WHERE Login='" +
                UsersLogins.SelectedValue.ToString() + "';";
                Com = new SqlCommand(strQ, sqlConn);
                Com.ExecuteNonQuery();
            }
            sqlConn.Close();
            UpdateDataTable();
        }
        private void CorrectRestrictionBtn_Click(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            String strQ;
            bool UserRestriction = (bool)ChangeRestriction.IsChecked;
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                strQ = "UPDATE MainTable SET Restriction ='" + UserRestriction + "' WHERE Login = '" + UsersLogins.SelectedValue.ToString() + "'; ";
                Com = new SqlCommand(strQ, sqlConn);
                Com.ExecuteNonQuery();
            }
            sqlConn.Close();
            UpdateDataTable();
        }
        private void ExitFromSystem_Click(object sender, RoutedEventArgs e)
        {
            RealAdminPasswd.Text = ""; RealAdminPasswd.IsEnabled = false;
            NewAdminPasswd.Text = ""; NewAdminPasswd.IsEnabled = false;
            NewAdminPasswd2.Text = ""; NewAdminPasswd2.IsEnabled = false;
            Prev.IsEnabled = false; Next.IsEnabled = false;
            UpdatePasswd.IsEnabled = false;
            AddUser.IsEnabled = false;
            CorrectStatusBtn.IsEnabled = false;
            CorrectRestrictionBtn.IsEnabled = false;
            dT.Clear();
            dataGrid.ItemsSource = dT.DefaultView;
            AdminPasswd.Text = "";
            UsersLogins.ItemsSource = "";
        }

        private void AutoriseBtn_Click(object sender, RoutedEventArgs e)
        {
            string AdmPass = "";
                sqlConn = new SqlConnection(Connection);
                sqlConn.Open();
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    Data = new SqlDataAdapter("SELECT Name, Surname, Login, Status, Restriction FROM MainTable", sqlConn);
                    dT = new DataTable("Користувачі системи");
                    Data.Fill(dT);
                    AdmPass = dT.Rows[0][0].ToString();
                }
                sqlConn.Close();
            if(AdmPass==AdminPasswd.Text)
            {
                RealAdminPasswd.IsEnabled = true;
                NewAdminPasswd.IsEnabled = true;
                NewAdminPasswd2.IsEnabled = true;
                Prev.IsEnabled = true; Next.IsEnabled = true;
                UpdatePasswd.IsEnabled = true;
                AddUser.IsEnabled = true;
                CorrectStatusBtn.IsEnabled = true;
                CorrectRestrictionBtn.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Wrong Password");
                RealAdminPasswd.Text = ""; RealAdminPasswd.IsEnabled = false;
                NewAdminPasswd.Text = ""; NewAdminPasswd.IsEnabled = false;
                NewAdminPasswd2.Text = ""; NewAdminPasswd2.IsEnabled = false;
                Prev.IsEnabled = false; Next.IsEnabled = false;
                UpdatePasswd.IsEnabled = false;
                AddUser.IsEnabled = false;
                CorrectStatusBtn.IsEnabled = false;
                CorrectRestrictionBtn.IsEnabled = false;
                dT.Clear();
                dataGrid.ItemsSource = dT.DefaultView;
                AdminPasswd.Text = "";
                UsersLogins.ItemsSource = "";
            }
        }
    }
}
