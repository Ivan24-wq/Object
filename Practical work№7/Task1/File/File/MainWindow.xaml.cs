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

            //Читаем файл
            using (StreamReader reader = new StreamReader(path))
            {
                Answer.Text = reader.ReadToEnd();
            }
        }

    }
}