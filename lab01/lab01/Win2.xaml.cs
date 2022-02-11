using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace lab01
{
    /// <summary>
    /// Логика взаимодействия для Win2.xaml
    /// </summary>
    public partial class Win2 : Window
    {
        public Win2()
        {
            InitializeComponent();
        }
        struct student
        {
            private string id;
            private string pibg;
            public student(string ID, string prizv, string im, string pob,string grupa)
            {
                id = ID;
                pibg = prizv + " " + im + " " + pob+" "+grupa;
            }
            public string GetId() => id;
            public string GetPIBG() => pibg;
        }
        private void AddStud_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("Students.txt");
                List<student> st = new List<student>();
                while (!sr.EndOfStream)
                {
                    string[] stud = new string[5];
                    stud = sr.ReadLine().Split(' ');
                    student stu = new student(stud[0], stud[1], stud[2], stud[3],stud[4]);
                    st.Add(stu);
                }
                sr.Close();
                foreach (student s in st)
                {
                    if (s.GetId() == Zalik.Text)
                    {
                        MessageBox.Show("Веведений номер залікової книжки вже є в списку");
                        return;
                    }
                }
                StreamWriter sw = new StreamWriter("Students.txt", true);
                if (Zalik.Text != "" && Prizvishe.Text != "" && Imia.Text != "" && Pobatkov.Text != ""&& Grupa.Text!="")
                {
                    sw.WriteLine(Zalik.Text + " " + Prizvishe.Text + " " + Imia.Text + " " + Pobatkov.Text+" "+Grupa.Text);
                    MessageBox.Show("Студент успішно доданий");
                }
                else
                {
                    MessageBox.Show("Повинні бути заповнені усі поля");
                    return;
                }
                sw.Close();
            }
            catch
            {
                StreamWriter sw = new StreamWriter("Students.txt", true);
                if (Zalik.Text != "" && Prizvishe.Text != "" && Imia.Text != "" && Pobatkov.Text != "" && Grupa.Text != "")
                {
                    sw.WriteLine(Zalik.Text + " " + Prizvishe.Text + " " + Imia.Text + " " + Pobatkov.Text+" "+Grupa.Text);
                    MessageBox.Show("Студент успішно доданий");
                }
                else
                {
                    MessageBox.Show("Повинні бути заповнені усі поля");
                    return;
                }
                sw.Close();
            }
        }

        private void DelStud_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader("Students.txt");
            List<student> st = new List<student>();
            while (!sr.EndOfStream)
            {
                string[] stud = new string[5];
                stud = sr.ReadLine().Split(' ');
                student stu = new student(stud[0], stud[1], stud[2], stud[3],stud[4]);
                st.Add(stu);
            }
            sr.Close();
            bool flag = false;
            foreach (student s in st)
            {
                if (s.GetId() == Zalik.Text)
                {
                    st.Remove(s);
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                MessageBox.Show("Студент не знайдений");
                return;
            }
            StreamWriter sw = new StreamWriter("Students.txt");
            foreach(student s in st)
            {
                sw.WriteLine(s.GetId() + " " + s.GetPIBG());
            }
            MessageBox.Show("Студент успішно видалений");
            sw.Close();
        }

        private void Back2_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }
    }
}
