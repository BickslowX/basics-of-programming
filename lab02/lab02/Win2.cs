using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media;

namespace lab02
{
    internal class Win2
    {
        TextBox Zalik;
        TextBox Prizvishe;
        TextBox Imia;
        TextBox Pobatkov;
        TextBox Grupa;
        Window window2;
        public Win2()
        {
            init(); 
        }
        private void init()
        {
            window2 = new Window();
            window2.ResizeMode = ResizeMode.NoResize;
            Grid myGrid = new Grid();
            window2.Height = 450;
            window2.Width = 1100;
            window2.Background = new SolidColorBrush(Colors.LightBlue);
            window2.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //myGrid.Width = 400;
            //myGrid.Height = 320;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            //myGrid.ShowGridLines = true;
            RowDefinition[] rows = new RowDefinition[20];
            ColumnDefinition[] cols = new ColumnDefinition[20];
            GridLengthConverter gridLengthConverter = new GridLengthConverter();
            for (int i = 0; i < 20; i++)
            {
                rows[i] = new RowDefinition();
                rows[i].Height = (GridLength)gridLengthConverter.ConvertFrom(30);
                myGrid.RowDefinitions.Add(rows[i]);
            }
            for (int i = 0; i < 20; i++)
            {
                cols[i] = new ColumnDefinition();
                cols[i].Width = (GridLength)gridLengthConverter.ConvertFrom(100);
                myGrid.ColumnDefinitions.Add(cols[i]);
            }
            Zalik = new TextBox();
            Zalik.Text = "12345";
            Prizvishe = new TextBox();
            Prizvishe.Text = "Петров";
            Imia = new TextBox();
            Imia.Text = "Леонід";
            Pobatkov = new TextBox();
            Pobatkov.Text = "Андрійович";
            Grupa = new TextBox();
            Grupa.Text = "КП-12";
            Grid.SetRow(Zalik, 7);
            Grid.SetColumn(Zalik, 5);
            Grid.SetRow(Prizvishe, 7);
            Grid.SetColumn(Prizvishe, 7);
            Grid.SetRow(Imia, 7);
            Grid.SetColumn(Imia, 9);
            Grid.SetRow(Pobatkov, 7);
            Grid.SetColumn(Pobatkov, 11);
            Grid.SetRow(Grupa, 7);
            Grid.SetColumn(Grupa, 13);
            myGrid.Children.Add(Zalik);
            myGrid.Children.Add(Prizvishe);
            myGrid.Children.Add(Imia);
            myGrid.Children.Add(Pobatkov);
            myGrid.Children.Add(Grupa);
            Button AddStud = new Button();
            Button DelStud = new Button();
            Grid.SetRow(AddStud, 10);
            Grid.SetColumn(AddStud, 10);
            Grid.SetRow(DelStud, 10);
            Grid.SetColumn(DelStud, 12);
            AddStud.Content = "Додати Студента";
            AddStud.Background = new SolidColorBrush(Colors.DarkRed);
            DelStud.Content = "Видалити Cтудента";
            DelStud.Background = new SolidColorBrush(Colors.DarkRed);
            AddStud.Click += AddStud_Click;
            DelStud.Click += DelStud_Click;
            myGrid.Children.Add(AddStud);
            myGrid.Children.Add(DelStud);
            Button Back2 = new Button();
            Back2.Background = new SolidColorBrush(Colors.DarkRed);
            Back2.Content = "На головну сторінку";
            Back2.Click += Back2_Click;
            Grid.SetRow(Back2, 12);
            Grid.SetColumn(Back2, 5);
            myGrid.Children.Add(Back2);
            window2.Content = myGrid;
            window2.Show();
        }
        struct student
        {
            private string id;
            private string pibg;
            public student(string ID, string prizv, string im, string pob, string grupa)
            {
                id = ID;
                pibg = prizv + " " + im + " " + pob + " " + grupa;
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
                    student stu = new student(stud[0], stud[1], stud[2], stud[3], stud[4]);
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
                if (Zalik.Text != "" && Prizvishe.Text != "" && Imia.Text != "" && Pobatkov.Text != "" && Grupa.Text != "")
                {
                    sw.WriteLine(Zalik.Text + " " + Prizvishe.Text + " " + Imia.Text + " " + Pobatkov.Text + " " + Grupa.Text);
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
                    sw.WriteLine(Zalik.Text + " " + Prizvishe.Text + " " + Imia.Text + " " + Pobatkov.Text + " " + Grupa.Text);
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
                student stu = new student(stud[0], stud[1], stud[2], stud[3], stud[4]);
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
            foreach (student s in st)
            {
                sw.WriteLine(s.GetId() + " " + s.GetPIBG());
            }
            MessageBox.Show("Студент успішно видалений");
            sw.Close();
        }

        private void Back2_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            window2.Hide();
            mw.Show();
        }
    }
}
