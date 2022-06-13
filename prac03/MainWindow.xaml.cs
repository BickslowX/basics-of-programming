using System;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace prac03
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Connection = null;
        SqlConnection sqlConn = null;
        SqlCommand Com;
        public MainWindow()
        {
            InitializeComponent();
            Connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string strQ;
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            try
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    strQ = "SET ANSI_NULLS ON GO SET QUOTED_IDENTIFIER ON GO CREATE TABLE[dbo].[MainTable]([Name][varchar](20) NULL,[Surname][varchar] (20) NULL,[Login][varchar] (20) NOT NULL,[Password] [varchar] (20) NULL,[Status][bit] NOT NULL,[Restriction] [bit] NOT NULL,CONSTRAINT[PK_MainTable] PRIMARY KEY CLUSTERED([Login] ASC) WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF,ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) ON[PRIMARY]GOALTER TABLE[dbo].[MainTable] ADD CONSTRAINT[DF_MainTable_Login] DEFAULT(user_name()) FOR[Login]GOALTER TABLE[dbo].[MainTable] ADD CONSTRAINT[DF_MainTable_Status] DEFAULT((1)) FOR[Status]goINSERT INTO MainTable(Name, Surname, Login, Status, Restriction) values('Leonid', 'Petrov', 'ADMIN', 1, 0) go";
                    Com = new SqlCommand(strQ, sqlConn);
                }
            }
            catch { }
        }
        private void AdminMode_Click(object sender, RoutedEventArgs e)
        {
            Administration administration = new Administration();
            Hide();
            administration.Show();
        }
        private void UserMode_Click(object sender, RoutedEventArgs e)
        {
            UserFormWPF userFormWPF = new UserFormWPF();
            Hide();
            userFormWPF.Show();
        }
        private void UserMode_Copy_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void AboutDev_Click(object sender, RoutedEventArgs e)
        {
            DevWindow devWindow = new DevWindow();
            devWindow.Show();
        }
    }
}
