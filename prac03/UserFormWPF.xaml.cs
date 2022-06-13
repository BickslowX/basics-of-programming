using System;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace prac03
{
    /// <summary>
    /// Логика взаимодействия для UserFormWPF.xaml
    /// </summary>
    public partial class UserFormWPF : Window
    {

        string Connection = null;
        SqlConnection sqlConn = null;
        SqlCommand Com;
        SqlDataAdapter Data;
        DataTable dT;
        string login, passwd;
        int count = 0;
        public UserFormWPF()
        {
            InitializeComponent();
            NewNameField.Text = ""; NewNameField.IsEnabled = false;
            NewSurnameField.Text = ""; NewSurnameField.IsEnabled = false;
            NewPasswdField.Text = ""; NewPasswdField.IsEnabled = false;
            NewPasswdField2.Text = ""; NewPasswdField2.IsEnabled = false;
            UpdateDataBtn.IsEnabled = false;
            passwdField.Text = "";
            Connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void AutorBtn_Click(object sender, RoutedEventArgs e)
        {
            login = loginField.Text;
            passwd = passwdField.Text;
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                String strQ = "SELECT * FROM MainTable WHERE Login='" + login + "';";
                Data = new SqlDataAdapter(strQ, sqlConn);
                dT = new DataTable("Користувачі системи");
                Data.Fill(dT);
                if (dT.Rows.Count == 0)
                    MessageBox.Show("Такого користувача на знайдено");
                else
                {
                    bool Status = Convert.ToBoolean(dT.Rows[0][4]);
                    if (!Status)
                        MessageBox.Show("Користувач заблокований Адміністратором системи!");
                    else
                    {
                        if ((dT.Rows[0][2].ToString() == login) &&  (dT.Rows[0][3].ToString() == passwd))
                        {
                            NewNameField.Text = dT.Rows[0][0].ToString();
                            NewSurnameField.Text = dT.Rows[0][1].ToString();
                            NewPasswdField.Text = "";
                            NewPasswdField2.Text = "";
                            NewNameField.IsEnabled = true;
                            NewSurnameField.IsEnabled = true;
                            NewPasswdField.IsEnabled = true;
                            NewPasswdField2.IsEnabled = true;
                            UpdateDataBtn.IsEnabled = true;
                        }
                        else
                        {
                            count++;
                            String s = "Невірно введений пароль! " +
                            "Помилкове введення №" + count.ToString();
                            MessageBox.Show(s);
                            if (count == 3)
                                System.Windows.Application.Current.Shutdown();
                        }
                    }
                }
            }
            sqlConn.Close();
        }
        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            String nameReg = NameField.Text;
            String surnameReg = SurnameField.Text;
            String loginReg = loginRegField.Text;
            String passwdReg = passwdRegField.Text;
            String passwdReg2 = passwdRegField2.Text;
            String strQ;
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    if ((passwdReg == passwdReg2) && (loginReg != "") && (passwdReg != ""))
                    {
                        strQ = "INSERT INTO MainTable ";
                        strQ += "VALUES ('" + nameReg + "', '" + surnameReg + "', '" + loginReg + "', '" + passwdReg + "', 'True', 'False'); ";
                        Com = new SqlCommand(strQ, sqlConn);
                        MessageBox.Show(Com.ExecuteNonQuery().ToString());;
                    }
                    else
                    {
                        MessageBox.Show("Обліковий запис не створено. Спробуйте ще раз!");
                    }
                }
                catch
                {
                    MessageBox.Show("Користувач з таким логіном вже існує у системі!");
                }
            }
            sqlConn.Close();
        }
        private void UpdateDataBtn_Click(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            String newname = NewNameField.Text;
            String newsurname = NewSurnameField.Text;
            String newpasswd = NewPasswdField.Text;
            String newpasswd2 = NewPasswdField2.Text;
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                String strQ;
                if ((newpasswd == newpasswd2) && (newpasswd != ""))
                {
                    Boolean flag = RestrictionFunc(newpasswd);
                    if (Convert.ToBoolean(dT.Rows[0][5]) == true)
                    {
                        if (flag == true)
                        {
                            strQ = "UPDATE MainTable SET Name='" + newname + "', ";
                            strQ += "Surname='" + newsurname + "', ";
                            strQ += "Password='" + newpasswd + "' ";
                            strQ += "WHERE Login='" + login + "';";
                            //MessageBox.Show(strQ);
                            Com = new SqlCommand(strQ, sqlConn);
                            MessageBox.Show(Com.ExecuteNonQuery().ToString());;
                        }
                        else
                            MessageBox.Show("У паролі немає літер верхнього та нижнього регістрів, а також арифметичних операцій! Спробуйте знову!");
}
                    else
                    {
                        strQ = "UPDATE MainTable SET Name='" + newname + "', ";
                        strQ += "Surname='" + newsurname + "', ";
                        strQ += "Password='" + newpasswd + "' ";
                        strQ += "WHERE Login='" + login + "';";
                        Com = new SqlCommand(strQ, sqlConn);
                        MessageBox.Show(Com.ExecuteNonQuery().ToString());;
                    }
                }
                else
                {
                    MessageBox.Show("Введено пустий пароль або новий пароль повторно введено некоректно!");
                }
            }
            sqlConn.Close();
        }
        private void CloseBtnSystem_Click(object sender, RoutedEventArgs e)
        {
            NewNameField.Text = ""; NewNameField.IsEnabled = false;
            NewSurnameField.Text = ""; NewSurnameField.IsEnabled = false;
            NewPasswdField.Text = ""; NewPasswdField.IsEnabled = false;
            NewPasswdField2.Text = ""; NewPasswdField2.IsEnabled = false;
            UpdateDataBtn.IsEnabled = false;
            loginField.Text = "";
            passwdField.Text = "";
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        Boolean RestrictionFunc(String Pass)
        {
            Byte Count1, Count2, Count3;
            Byte LenPass = (Byte)Pass.Length;
            Count1 = Count2 = Count3 = 0;
            for (Byte i = 0; i < LenPass; i++)
            {
                if ((Convert.ToInt32(Pass[i]) >= 65) &&
                (Convert.ToInt32(Pass[i]) <= 65 + 25))
                    Count1++;
                if ((Convert.ToInt32(Pass[i]) >= 97) &&
                (Convert.ToInt32(Pass[i]) <= 97 + 25))
                    Count2++;
                if ((Pass[i] == '+') || (Pass[i] == '-') || (Pass[i] == '*') ||
                (Pass[i] == '/'))
                    Count3++;
            }
            return (Count1 * Count2 * Count3 != 0);
        }

    }
}
