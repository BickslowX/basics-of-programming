using System;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace znoSystem
{
    /// <summary>
    /// Логика взаимодействия для AddAbitWin.xaml
    /// </summary>
    public partial class AddAbitWin : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        public AddAbitWin()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            String[] cities = { "Дніпро", "Київ", "Харків", "Львів", "Одеса" };
            String[] privilegies = { "Немаэ", "Член збірної України, який брав участь в олімпіадах", "Призер учнівських олімпіад/переможець конкурсу МАН" };
            CityComboBox.ItemsSource = cities; CityComboBox.SelectedIndex = 0;
            PrivilCB.ItemsSource = privilegies; PrivilCB.SelectedIndex = 0;
            SchoolComboBox.ItemsSource = GetItemsSchools(); SchoolComboBox.SelectedIndex = 0;
        }

        private void AddBackBtn_Click(object sender, RoutedEventArgs e)
        {
            AbitListWin abitListWin = new AbitListWin();
            Hide();
            abitListWin.Show();
        }
        private String[] GetItemsSchools()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string[] Items = { "" };
            if (connection.State == System.Data.ConnectionState.Open)
            {
                adapter = new SqlDataAdapter("select SchoolName from SchoolData where SchoolCity='" + CityComboBox.SelectedItem + "'", connection);
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
        private void AddAbitBtn_Click(object sender, RoutedEventArgs e)
        {
            int AbitID = 0;
            if (IDTextBox.Text.Length == 7)
            {
                try { AbitID = Convert.ToInt32(IDTextBox.Text); }
                catch { return; }
            }
            else
            {
                MessageBox.Show("Wrong ID");
                return;
            }
            string AbitBirth = ""; string AbitGradDate = "";
            if ((BDTextBox.Text.Length >7&& BDTextBox.Text.Length < 11)&&(GradDateTextBox.Text.Length>7&& GradDateTextBox.Text.Length < 11))
            {
                AbitBirth = BDTextBox.Text; AbitGradDate = GradDateTextBox.Text;   
            }
            else
            {
                MessageBox.Show("Wrong Birth or Graduation Date ");
                return;
            }
            string AbitSurname = "", AbitName = "", AbitPatr = "", AbitStreet = "", AbitHouse = "", AbitIndex = "", AbitPhone = "", AbitAVG = "";
            if(SurnameTextBox.Text.Length!=0&&NameTextBox.Text.Length!=0&&PatronimicTextBox.Text.Length!=0&&StreetTextBox.Text.Length!=0&&HouseTextBox.Text.Length!=0&&IndexTextBox.Text.Length!=0&&PhoneTextBox.Text.Length>3&&AVGTextBox.Text.Length!=0)
            {
                AbitSurname = SurnameTextBox.Text;
                AbitName=NameTextBox.Text;
                AbitPatr= PatronimicTextBox.Text;
                AbitStreet=StreetTextBox.Text; 
                AbitHouse=HouseTextBox.Text;
                AbitIndex=IndexTextBox.Text; 
                AbitPhone=PhoneTextBox.Text;
                AbitAVG=AVGTextBox.Text;

            }
            else
            {
                MessageBox.Show("Wrong Data(1)");
                return;
            }
            connection = new SqlConnection(connectionString);
            connection.Open();
            int AbitSchool = 0;
            if (connection.State == System.Data.ConnectionState.Open)
            {
                adapter = new SqlDataAdapter("select SchoolID from SchoolData where SchoolName = '"+SchoolComboBox.SelectedItem+"';", connection);
                DataTable DT = new DataTable();
                adapter.Fill(DT);
                AbitSchool = Convert.ToInt32(DT.Rows[0][0].ToString());
                try
                {
                    string sqlQ = "insert into AbitList (AbitID,AbitSurname,AbitName,AbitPatronymic,AbitBirth,AbitSchool,AbitGradDate,AbitAVG) " +
                                  " values(" + AbitID + ", '" + AbitSurname + "', '" + AbitName + "', '" + AbitPatr + "', '" + AbitBirth + "', " + AbitSchool + ", '" + AbitGradDate + "', '" + AbitAVG + "');";
                    command = new SqlCommand(sqlQ, connection);
                    MessageBox.Show(command.ExecuteNonQuery().ToString());
                    sqlQ = "insert into AbitPersData (AbitID,AbitCity,AbitStreet, AbitHouseNum, AbitIndex, AbitPhone) " +
                           "values(" + AbitID + ", '" + CityComboBox.SelectedItem + "', '" + AbitStreet + "', '" + AbitHouse + "', '" + AbitIndex + "', '" + AbitPhone + "'); ";
                    command = new SqlCommand(sqlQ, connection);
                    MessageBox.Show(command.ExecuteNonQuery().ToString());
                    if (PrivilCB.SelectedIndex == 0)
                    {
                        sqlQ = "insert into AbitExams (AbitID,AbitPrivileges,AbitExam1,AbitExam2,AbitExam3) " +
                               "values(" + AbitID + ", null, 1, 2, 4); ";
                    }
                    else if (PrivilCB.SelectedIndex == 1)
                    {
                        sqlQ = "insert into AbitExams (AbitID,AbitPrivileges,AbitExam1,AbitExam2,AbitExam3) " +
                               "values(" + AbitID + ", 1, 1, 2, 4); ";
                    }
                    else if (PrivilCB.SelectedIndex == 2)
                    {
                        sqlQ = "insert into AbitExams (AbitID,AbitPrivileges,AbitExam1,AbitExam2,AbitExam3) " +
                               "values(" + AbitID + ", 2, 1, 2, 4); ";
                    }
                    command = new SqlCommand(sqlQ, connection);
                    MessageBox.Show(command.ExecuteNonQuery().ToString());

                    int school1, school2, school3;
                    adapter = new SqlDataAdapter("SELECT TOP 1 SchoolID from SchoolData  where SchoolCity = '" + CityComboBox.SelectedItem + "'  ORDER BY NEWID(); ", connection);
                    DataTable DTSc1 = new DataTable();
                    adapter.Fill(DTSc1);
                    school1 = Convert.ToInt32(DTSc1.Rows[0][0].ToString());
                    adapter = new SqlDataAdapter("SELECT TOP 1 SchoolID from SchoolData  where SchoolCity = '" + CityComboBox.SelectedItem + "'  ORDER BY NEWID(); ", connection);
                    DataTable DTSc2 = new DataTable();
                    adapter.Fill(DTSc2);
                    school2 = Convert.ToInt32(DTSc2.Rows[0][0].ToString());
                    adapter = new SqlDataAdapter("SELECT TOP 1 SchoolID from SchoolData  where SchoolCity = '" + CityComboBox.SelectedItem + "'  ORDER BY NEWID(); ", connection);
                    DataTable DTSc3 = new DataTable();
                    adapter.Fill(DTSc3);
                    school3 = Convert.ToInt32(DTSc3.Rows[0][0].ToString());

                    string RespP1, RespP2, RespP3;
                    adapter = new SqlDataAdapter("SELECT TOP 1 RespPerson from Abitex1  ORDER BY NEWID(); ", connection);
                    DataTable DTRP1 = new DataTable();
                    adapter.Fill(DTRP1);
                    RespP1 = DTRP1.Rows[0][0].ToString();
                    adapter = new SqlDataAdapter("SELECT TOP 1 RespPerson from Abitex2  ORDER BY NEWID(); ", connection);
                    DataTable DTRP2 = new DataTable();
                    adapter.Fill(DTRP2);
                    RespP2 = DTRP2.Rows[0][0].ToString();
                    adapter = new SqlDataAdapter("SELECT TOP 1 RespPerson from Abitex3  ORDER BY NEWID(); ", connection);
                    DataTable DTRP3 = new DataTable();
                    adapter.Fill(DTRP3);
                    RespP3 = DTRP3.Rows[0][0].ToString();
                    Random r = new Random();
                    sqlQ = "insert into AbitEx1 (AbitID, SchoolID, Audience, RespPerson) " +
                           "values(" + AbitID + ", " + school1 + ", 'Аудитория № " + r.Next(1, 11) + "', '" + RespP1 + "'); ";
                    command = new SqlCommand(sqlQ, connection);
                    MessageBox.Show(command.ExecuteNonQuery().ToString());

                    sqlQ = "insert into AbitEx2 (AbitID, SchoolID, Audience, RespPerson) " +
                           "values(" + AbitID + ", " + school2 + ", 'Аудитория № " + r.Next(1, 11) + "', '" + RespP2 + "'); ";
                    command = new SqlCommand(sqlQ, connection);
                    MessageBox.Show(command.ExecuteNonQuery().ToString());

                    sqlQ = "insert into AbitEx3 (AbitID, SchoolID, Audience, RespPerson) " +
                           "values(" + AbitID + ", " + school3 + ", 'Аудитория № " + r.Next(1, 11) + "', '" + RespP3 + "'); ";
                    command = new SqlCommand(sqlQ, connection);
                    MessageBox.Show(command.ExecuteNonQuery().ToString());
                }
                catch
                {
                    MessageBox.Show("Wrong Data(2)");
                }
            }
            connection.Close();

        }

        private void CityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SchoolComboBox.ItemsSource = GetItemsSchools(); SchoolComboBox.SelectedIndex = 0;
        }
    }
}
