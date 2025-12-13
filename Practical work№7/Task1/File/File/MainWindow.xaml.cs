using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using File;
using Microsoft.Win32;

namespace FileApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Создаём файл
        private void ChooseFile_Click(object sender, RoutedEventArgs e)
        { 
            //Выбираем путь хранения файла
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            dialog.FileName = "";
            if(dialog.ShowDialog() == true)
            {
                FilePath.Text = dialog.FileName;
            }

            //Создадим текстовый файл
            string path = dialog.FileName;
            FilePath.Text = path;
            try
            {
                using (FileStream file = System.IO.File.Create(path))
                {
                    //Записанный текст
                    byte[] info = new System.Text.UTF8Encoding(true).GetBytes("C# Привет");
                    file.Write(info, 0, info.Length);
                    MessageBox.Show($"Файл создан {path}");
                }
           }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка при создании файла!{ex.Message}");
            }
        }

        //Чтение файла
        private void Read_Click(object sender, RoutedEventArgs e)
        {
            //Выбираем файл, который будем чиать
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if(dialog.ShowDialog() == true)
            {
                FilePath.Text = dialog.FileName;
            }
            string path = dialog.FileName;
            FilePath.Text = path;

            try
            {
                //Читаем файл
                using (StreamReader reader = new StreamReader(path))
                {
                    Answer.Text = reader.ReadToEnd();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка чтения: {ex.Message}");
            }
        }

        //Запись текста
        private void Write_Click(object sender, RoutedEventArgs e)
        {
            //Выбор файла для записи
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if(dialog.ShowDialog() == true)
            {
                FilePath.Text = dialog.FileName;
            }
            string path = dialog.FileName;
            FilePath.Text = path;
            try
            {
                using (StreamWriter writer = new StreamWriter(path, false))
                {
                    writer.Write(input.Text);
                }
                MessageBox.Show("Успешная запись!");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка! {ex.Message}");
            }
        }

        //Удаление
        private void Delete_Click(object obj, RoutedEventArgs e)
        {
            //Найдём файл
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                FilePath.Text = dialog.FileName;
            }
            string path = dialog.FileName;
            FilePath.Text = path;

            try
            {
                System.IO.File.Delete(path);
                MessageBox.Show("Успешное удаление");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        //Создание бинарного файла
        private void ChooseBin_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Бинарные файлы(*.bin) | *.bin | Все файлы(*.*) | *.* ";
            dialog.FileName = "";
            if (dialog.ShowDialog() == true)
            {
                using (BinaryWriter writer = new BinaryWriter(System.IO.File.Open(dialog.FileName, System.IO.FileMode.Create)))
                {
                    try
                    {
                        writer.Write(input.Text);
                        MessageBox.Show("Успешная запись бинарного файла");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}");
                    }
                }
            }
        }

        //Запись
        private void WriteBin_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Бинарные файлы (*.bin)|*.bin|Все файлы (*.*)|*.*";
            dialog.FileName = "people.bin";

            if (dialog.ShowDialog() != true)
                return;

            Person[] persons =
            {
                new Person("Tom", 47),
                new Person("Bob", 20),
                new Person("Man", 17)
    };

            try
            {
                using (BinaryWriter writer =
                       new BinaryWriter(System.IO.File.Open(dialog.FileName, FileMode.Create)))
                {
                    writer.Write(persons.Length);

                    foreach (Person p in persons)
                    {
                        writer.Write(p.Name);
                        writer.Write(p.Age);
                    }
                }

                MessageBox.Show("Бинарный файл успешно создан!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }


        //Чтение бинарника
        private void ReadBin_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Бинарные файлы (*.bin)|*.bin|Все файлы (*.*)|*.*";

            if (dialog.ShowDialog() != true)
                return;

            using (BinaryReader reader =
                   new BinaryReader(System.IO.File.Open(dialog.FileName, FileMode.Open)))
            {
                int count = reader.ReadInt32();
                Person[] persons = new Person[count];

                for (int i = 0; i < count; i++)
                {
                    string name = reader.ReadString();
                    int age = reader.ReadInt32();
                    persons[i] = new Person(name, age);
                }

                string result = "";
                foreach (Person p in persons)
                {
                    result += $"{p.Name}, {p.Age} лет\n";
                }

                MessageBox.Show(result);
            }
        }



    }
}